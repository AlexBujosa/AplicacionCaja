using AplicacionCaja.integracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionCaja
{
    public partial class MontoTercero : Form
    {
        public Form Form;
        private DataSet Authentication;
        private decimal monto;
        private int ID_TipoTransaccion;
        private int DbCr;
        private string Comentario;
        private int NoCuenta;
        private DataRow Row;
        private int Entidad;
        private string Nombres;
        private int ID_TipoEntidad;
        private decimal Monto;
        public MontoTercero()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                monto = decimal.Parse(textBox1.Text);
                if (monto > decimal.Parse(Row[1].ToString()) && DbCr == 0)
                    MessageBox.Show("No tiene dinero suficiente para retirar");
                else if(monto < 100)
                    MessageBox.Show("Error: No montos menores que 100");
                else
                {
                    IntegracionASMXSoapClient ASM = new IntegracionASMXSoapClient();
                    DialogResult dialogResult = MessageBox.Show("¿Realmente deseas realizar esta transacción?", "Transaccion A Terceros", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Comentario = Comentario == null ? "Transferencia hecha por " + Nombres : Comentario;
                        DataSet dataSet = ASM.TransaccionATercero(NoCuenta, Entidad, ID_TipoEntidad, ID_TipoTransaccion, DbCr, Comentario, monto);
                        Actualizaciones(dataSet);
                        
                    }
                    if (Form.GetType().ToString() == "AplicacionCaja.Transferencia")
                    {
                        Transferencia transferencia = new Transferencia();
                        transferencia = (Transferencia)Form;
                        transferencia.RecibirActualizacion(Authentication, Monto);
                    }
                    else
                    {
                        DepositoATerceros deposito = new DepositoATerceros();
                        deposito = (DepositoATerceros)Form;
                        deposito.RecibirActualizacion(Authentication, Monto);
                       
                        
                    }
                    Form.Enabled = true;
                    this.Dispose();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No se permite convertir un numero no decimal");
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form.Enabled = true;
            this.Dispose();
        }

        private void MontoTercero_Load(object sender, EventArgs e)
        {
            if (DbCr == 0)
                label3.Text = "Monto a Tranferencia:";
            else if(DbCr == 2)
                label3.Text = "Monto a Depositar:";
        }
        public void EnviarDatos(Form form, DataRow row,DataSet Auth, int noCuenta, int entidad, int id_TipoEntidad, int id_TipoTransaccion, int dbCr, string comentario, string nombres)
        {
            Form = form;
            Row = row;
            NoCuenta = noCuenta;
            Entidad = entidad;
            ID_TipoEntidad = id_TipoEntidad;
            ID_TipoTransaccion = id_TipoTransaccion;
            DbCr = dbCr;
            Comentario = comentario ;
            Nombres = nombres;
            Authentication = Auth;
        }
        public void Actualizaciones(DataSet dataSet)
        {
            ActualizarNoCuenta(dataSet);
            AgregarTransacciones(dataSet);
            AgregarPago(dataSet);
            TransaccionProcesada();
            DeseaHacerReporte();
            if (Form.GetType().ToString() != "AplicacionCaja.Transferencia")
            {
                InsertarCajero(dataSet);
            }

        }
        public void InsertarCajero(DataSet dataset)
        {
            Cajero cajero = new Cajero();
            cajero.InsertarTransaccionCaja(int.Parse(dataset.Tables[1].Rows[0][0].ToString()), monto, DbCr);
            cajero.UpdateCaja(monto, DbCr);
        }
        public void DeseaHacerReporte()
        {
            DialogResult dialogResult = MessageBox.Show(($"¿Deseas {Nombres} imprimir la transaccion?"), "Reporte", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Reporte reporte = new Reporte();
                reporte.EnviarDatos(NoCuenta, Monto, monto, DbCr, ID_TipoTransaccion, Entidad.ToString());
                reporte.Show();
            }
        }
        public void ActualizarNoCuenta(DataSet DATASET)
        {
            Row = DATASET.Tables[0].Rows[0];
            for (int i = 0; i < Authentication.Tables[0].Rows.Count; i++)
            {
                if (int.Parse(Authentication.Tables[0].Rows[i][0].ToString()) == NoCuenta)
                {
                    Authentication.Tables[0].Rows[i][0] = Row[0];
                    Authentication.Tables[0].Rows[i][1] = Row[1];
                    Authentication.Tables[0].Rows[i][2] = Row[2];
                    Authentication.Tables[0].Rows[i][2] = Row[3];
                    Authentication.Tables[0].Rows[i][4] = Row[4];
                    Monto = decimal.Parse(Row[1].ToString());
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

        private void button1_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
