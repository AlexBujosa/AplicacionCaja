using IntegracionAplicacion;
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
    public partial class Retiro : Form
    {
        public RDPT RDPT;
        public int ID_TipoCuenta;
        public int NoCuenta;
        public DataSet Authentication;
        public string Nombres;
        public decimal Monto;
        public DataRow row;
        private int DbCr;
        private decimal montoRetiro;
        private int ID_TipoTransaccion;
        private string Comentario;
        public Retiro()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion sesion = new CerrarSesion();
            sesion.EnviarDatos(this);
            sesion.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            montoRetiro = 500;
            Integracion ASM = new Integracion();
            if (montoRetiro > decimal.Parse(row[1].ToString()))
                MessageBox.Show("No tiene dinero suficiente para retirar");
            else
            {
                DataSet data = ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, montoRetiro);
                ActualizarAuth(data);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            montoRetiro = 1000;
            Integracion ASM = new Integracion();
            if (montoRetiro > decimal.Parse(row[1].ToString()))
                MessageBox.Show("No tiene dinero suficiente para retirar");
            else
            {
                DataSet data = ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, montoRetiro);
                ActualizarAuth(data);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            montoRetiro = 1500;
            Integracion ASM = new Integracion();
            if (montoRetiro > decimal.Parse(row[1].ToString()))
                MessageBox.Show("No tiene dinero suficiente para retirar");
            else
            {
                DataSet data = ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, montoRetiro);
                ActualizarAuth(data);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            montoRetiro = 2000;
            Integracion ASM = new Integracion();
            if (montoRetiro > decimal.Parse(row[1].ToString()))
                MessageBox.Show("No tiene dinero suficiente para retirar");
            else
            {
                DataSet data = ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, montoRetiro);
                ActualizarAuth(data);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            montoRetiro = 2500;
            Integracion ASM = new Integracion();
            if (montoRetiro > decimal.Parse(row[1].ToString()))
                MessageBox.Show("No tiene dinero suficiente para retirar");
            else
            {
                DataSet data = ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, montoRetiro);
                ActualizarAuth(data);
            }
                
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Monto monto = new Monto();
            monto.EnviarDatos(this,ID_TipoTransaccion, DbCr, Comentario, NoCuenta, row, Authentication);
            monto.Show();
        }

        private void Retiro_Load(object sender, EventArgs e)
        {
            DataTable table = Authentication.Tables[0];
            for (int i = 0; i<table.Rows.Count; i++)
            {
                if (int.Parse(table.Rows[i][0].ToString()) == NoCuenta)
                    row = table.Rows[i]; 
            }
            DbCr = 0;
            ID_TipoTransaccion = 5;
            Comentario = "Retiro de dinero realizado por " + Nombres ;
        }
        public void EnviarDatos(RDPT rdpt, int id_TipoCuenta, int noCuenta, DataSet auth, string nombres, decimal monto)
        {
            RDPT= rdpt;
            ID_TipoCuenta = id_TipoCuenta;
            NoCuenta = noCuenta;
            Authentication = auth;
            Nombres = nombres;
            Monto = monto;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RDPT.RecibirActualizacion(Authentication, Monto);
            RDPT.Show();
            this.Dispose();
        }
        public void RecibirActualizacion(DataSet Auth, DataRow Row)
        {
            Authentication = Auth;
            row = Row;
        }
        public void ActualizarAuth(DataSet data)
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
            //Authentication.Tables[3].Rows.Add(data.Tables[1].Rows[0]);
        }
    }
}
