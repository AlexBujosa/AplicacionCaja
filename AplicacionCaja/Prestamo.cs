using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplicacionCaja.integracion;
using Newtonsoft.Json;

namespace AplicacionCaja
{
    public partial class Prestamo : Form
    {
        public CuotasPrestamos cuotasPrestamos;
        public pagoPrestamo PagoPrestamo;
        public int ID_TipoCuenta;
        public int NoCuenta;
        public DataSet Authentication;
        public string Nombres;
        public decimal Monto;
        public int ID_Prestamo;
        public decimal MontoPrestamo;
        public decimal MontoPlazoMax;
        public int TipoPrestamo;
        public decimal Tasa;
        public int Duracion;
        public string FechaPrestamo;
        public List<CuotasModelo> cuotas;
        public int DbCr;
        public int ID_TipoTransaccion;
        public string Comentario;
        public DataRow row;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Prestamo()
        {
            InitializeComponent();
        }
        public void ActualizarDgvCuotas()
        {
            cuotasPrestamos = new CuotasPrestamos();
            DataSet dt = cuotasPrestamos.ConseguirPagos(ID_Prestamo);
            cuotas = JsonConvert.DeserializeObject<List<CuotasModelo>>(dt.Tables[0].Rows[0][1].ToString());
            dgvCuotas.Columns.Add("Periodo", "Periodo");
            dgvCuotas.Columns.Add("DiaPago", "Dia de Pago");
            dgvCuotas.Columns.Add("CantidadPago", "Cantidad de Pago");
            dgvCuotas.Columns.Add("BalanceActual", "Balance Actual");
            dgvCuotas.Columns.Add("Vigencia", "Vigencia");

            for (int i = 0; i < cuotas.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dgvCuotas.Rows[i].Clone();
                row.Cells[0].Value = cuotas[i].Periodo;
                row.Cells[1].Value = cuotas[i].DiaPago;
                row.Cells[2].Value = cuotas[i].CantidadPago;
                row.Cells[3].Value = cuotas[i].BalanceActual;
                row.Cells[4].Value = cuotas[i].Vigencia;
                dgvCuotas.Rows.Add(row);
            }
        }

        private void Prestamo_Load(object sender, EventArgs e)
        {
            DbCr = 0;
            ID_TipoTransaccion = 3;
            Comentario = "Pago de Prestamo realizado por " + Nombres.ToString();
            ActualizarDgvCuotas();
            
        }
        public void EnviarDatos(pagoPrestamo pagoPrestamo, int id_TipoCuenta, int noCuenta, DataSet auth, string nombres, decimal monto,int id_Prestamo, decimal montoPrestamo, decimal montoPlazoMax, int tipoPrestamo, decimal tasa, int duracion, string fechaPrestamo)
        {
            PagoPrestamo = pagoPrestamo;
            ID_TipoCuenta = id_TipoCuenta;
            NoCuenta = noCuenta;
            Authentication = auth;
            Nombres = nombres;
            Monto = monto;
            ID_Prestamo = id_Prestamo;
            MontoPrestamo = montoPrestamo;
            MontoPlazoMax = montoPlazoMax;
            TipoPrestamo = tipoPrestamo;
            Tasa = tasa;
            Duracion = duracion;
            FechaPrestamo = fechaPrestamo;
        }

        private void CerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion sesion = new CerrarSesion();
            sesion.EnviarDatos(this);
            sesion.Show();
            this.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PagoPrestamo.RecibirActualizacion(Authentication, Monto);
            PagoPrestamo.Show();
            this.Dispose();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            CuotasModelo CM = new CuotasModelo();
            for(int i = 0; i < cuotas.Count; i++)
            {
                if(cuotas[i].Vigencia == 1)
                {
                    CM = cuotas[i];
                    break;
                }
            }
            if(CM != null)
            {
                IntegracionASMXSoapClient ASM = new IntegracionASMXSoapClient();
                DataSet dataSet = ASM.TransaccionATercero(NoCuenta, ID_Prestamo, 2, ID_TipoTransaccion, DbCr, Comentario, CM.CantidadPago, "Droog ethereal develop 269138");
                Actualizaciones(dataSet, CM.CantidadPago);
                for (int i = 0; i < cuotas.Count; i++)
                {
                    if (cuotas[i].Vigencia == 1)
                    {
                        cuotas[i].Vigencia = 0;
                        break;
                    }
                }
                cuotasPrestamos = new CuotasPrestamos();
                string jsonString = JsonConvert.SerializeObject(cuotas);
                cuotasPrestamos.Update(ID_Prestamo, jsonString);
                ActualizarDgvCuotas();
            }

        }
        public void Actualizaciones(DataSet dataSet, decimal monto)
        {
            try
            {
                ActualizarNoCuenta(dataSet);
                AgregarTransacciones(dataSet);
                AgregarPago(dataSet);
                TransaccionProcesada();
                DeseaHacerReporte(monto);
                Cajero cajero = new Cajero();
                log.Info($"El usuario {Authentication.Tables[2].Rows[0][1]} ha pagado prestamo de monto {monto}. Numero de Cajero: {cajero.ID_Cajero} Hora: {DateTime.Now}   ");

            }
            catch (Exception)
            {
                TransaccionNoProcesada();
            }


        }
        public void DeseaHacerReporte(decimal monto)
        {
            DialogResult dialogResult = MessageBox.Show(($"¿Deseas {Nombres} imprimir la transaccion?"), "Reporte", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Reporte reporte = new Reporte();
                reporte.EnviarDatos(NoCuenta, Monto, monto, DbCr, ID_TipoTransaccion, ID_Prestamo.ToString());
                reporte.Show();
                Cajero cajero = new Cajero();
                log.Info($"El usuario ha {Authentication.Tables[2].Rows[0][1]} realizado el reporte del prestamo {monto}. Hora: {DateTime.Now} Cajero: {cajero.ID_Cajero}");

            }
        }
        public void ActualizarNoCuenta(DataSet DATASET)
        {
            row = DATASET.Tables[0].Rows[0];
            for (int i = 0; i < Authentication.Tables[0].Rows.Count; i++)
            {
                if (int.Parse(Authentication.Tables[0].Rows[i][0].ToString()) == NoCuenta)
                {
                    Authentication.Tables[0].Rows[i][0] = row[0];
                    Authentication.Tables[0].Rows[i][1] = row[1];
                    Authentication.Tables[0].Rows[i][2] = row[2];
                    Authentication.Tables[0].Rows[i][2] = row[3];
                    Authentication.Tables[0].Rows[i][4] = row[4];
                    Monto = decimal.Parse(row[1].ToString());
                }
            }
        }
        public void AgregarTransacciones(DataSet DATASET)
        {
            Authentication.Tables[3].Rows.Add(DATASET.Tables[1].Rows[0].ItemArray);
        }
        public void AgregarPago(DataSet DATASET)
        {
            Authentication.Tables[4].Rows.Add(DATASET.Tables[2].Rows[0].ItemArray);
        }
        public void TransaccionProcesada()
        {
            MessageBox.Show("Transaccion Procesada");
        }
        public void TransaccionNoProcesada()
        {
            MessageBox.Show("Transaccion No Procesada");
        }
        public void RecibirActualizacion(DataSet auth, decimal monto)
        {
            Authentication = auth;
            Monto = monto;
        }
    }

    public class CuotasModelo
    {
        public int Periodo;
        public DateTime DiaPago;
        public decimal CantidadPago;
        public decimal BalanceActual;
        public int Vigencia;
    }
}
