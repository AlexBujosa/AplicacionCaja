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
    public partial class Deposito : Form
    {
        public Depositos Depositos;
        public int ID_TipoCuenta;
        public int NoCuenta;
        public DataSet Authentication;
        public string Nombres;
        public decimal Monto;
        public DataRow row;
        private int DbCr;
        private decimal montoDeposito;
        private int ID_TipoTransaccion;
        private string Comentario;
        public Deposito()
        {
            InitializeComponent();
        }

        private void CerrarSesion_Click(object sender, EventArgs e)
        {            
            CerrarSesion sesion = new CerrarSesion();
            sesion.EnviarDatos(this);
            sesion.Show();
            this.Enabled = false;
        }

        private void Deposito_Load(object sender, EventArgs e)
        {
            DataTable table = Authentication.Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (int.Parse(table.Rows[i][0].ToString()) == NoCuenta)
                    row = table.Rows[i];
            }
            DbCr = 1;
            ID_TipoTransaccion = 4;
            Comentario = "Deposito de dinero realizado por " +Nombres;
        }
        public void EnviarDatos(Depositos depositos, int id_TipoCuenta, int noCuenta, DataSet auth, string nombres, decimal monto)
        {
            Depositos = depositos;
            ID_TipoCuenta = id_TipoCuenta;
            NoCuenta = noCuenta;
            Authentication = auth;
            Nombres = nombres;
            Monto = monto;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Depositos.RecibirActualizacion(Authentication, Monto);
            Depositos.Show();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            montoDeposito = 500;
            IntegracionASMXSoapClient ASM = new IntegracionASMXSoapClient();
            DataSet data = ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, montoDeposito);
            ActualizarAuth(data);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            montoDeposito = 1000;
            IntegracionASMXSoapClient ASM = new IntegracionASMXSoapClient();
            DataSet data = ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, montoDeposito);
            ActualizarAuth(data);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            montoDeposito = 1500;
            IntegracionASMXSoapClient ASM = new IntegracionASMXSoapClient();
            DataSet data = ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, montoDeposito);
            ActualizarAuth(data);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            montoDeposito = 2000;
            IntegracionASMXSoapClient ASM = new IntegracionASMXSoapClient();
            DataSet data = ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, montoDeposito);
            ActualizarAuth(data);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            montoDeposito = 2500;
            IntegracionASMXSoapClient ASM = new IntegracionASMXSoapClient();
            DataSet data = ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, montoDeposito);
            ActualizarAuth(data);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Monto monto = new Monto();
            monto.EnviarDatos(this, ID_TipoTransaccion, DbCr, Comentario, NoCuenta,row);
            monto.Show();
        }
        public void RecibirActualizacion(DataSet Auth, DataRow Row)
        {
            Authentication = Auth;
            row = Row;
        }
        public void ActualizarAuth(DataSet data)
        {
            try
            {
                row = data.Tables[0].Rows[0];
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
                Authentication.Tables[3].Rows.Add(data.Tables[1].Rows[0].ItemArray);
                TransaccionProcesada();
                DeseaHacerReporte();
                InsertarCajero(data);
                
            }
            catch(Exception){
                TransaccionNoProcesada();
            }
            
        }
        public void InsertarCajero(DataSet data)
        {
            Cajero cajero = new Cajero();
            cajero.InsertarTransaccionCaja(int.Parse(data.Tables[1].Rows[0][0].ToString()), montoDeposito, DbCr);
            cajero.UpdateCaja(montoDeposito, DbCr);
        }
        public void DeseaHacerReporte()
        {
            DialogResult dialogResult = MessageBox.Show(($"¿Deseas {Nombres} imprimir la transaccion?"), "Reporte", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                Reporte reporte = new Reporte();
                reporte.EnviarDatos(NoCuenta, Monto, montoDeposito, DbCr, ID_TipoTransaccion);
                reporte.Show();
            }
        }
        public void EnviarDeposito(decimal MontoDeposito)
        {
            montoDeposito = MontoDeposito;
        }
        public void TransaccionProcesada()
        {
            MessageBox.Show("Transaccion Procesada");
        }
        public void TransaccionNoProcesada()
        {
            MessageBox.Show("Transaccion No Procesada");
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void CerrarSesion_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
