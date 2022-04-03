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
    public partial class Deposito : Form
    {
        public RDPT RDPT;
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
        public void EnviarDatos(RDPT rdpt, int id_TipoCuenta, int noCuenta, DataSet auth, string nombres, decimal monto)
        {
            RDPT = rdpt;
            ID_TipoCuenta = id_TipoCuenta;
            NoCuenta = noCuenta;
            Authentication = auth;
            Nombres = nombres;
            Monto = monto;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RDPT.Show();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            montoDeposito = 500;
            Integracion ASM = new Integracion();
            ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, montoDeposito);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            montoDeposito = 1000;
            Integracion ASM = new Integracion();
            ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, montoDeposito);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            montoDeposito = 1500;
            Integracion ASM = new Integracion();
            ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, montoDeposito);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            montoDeposito = 2000;
            Integracion ASM = new Integracion();
            ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, montoDeposito);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            montoDeposito = 2500;
            Integracion ASM = new Integracion();
            ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, montoDeposito);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Monto monto = new Monto();
            monto.EnviarDatos(this, ID_TipoTransaccion, DbCr, Comentario, NoCuenta, row, Authentication);
            monto.Show();
        }
        public void RecibirActualizacion(DataSet Auth, DataRow Row)
        {
            Authentication = Auth;
            row = Row;
        }
    }
}
