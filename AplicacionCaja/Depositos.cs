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
    public partial class Depositos : Form
    {
        public RDPT RDPT;
        public int ID_TipoCuenta;
        public int NoCuenta;
        public DataSet Authentication;
        public string Nombres;
        public decimal Monto;
        public DataRow row;
        public Depositos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deposito deposito = new Deposito();
            this.Visible = false;
            deposito.EnviarDatos(this, ID_TipoCuenta, NoCuenta, Authentication, Nombres, Monto);
            deposito.Show();
        }
        public void RecibirActualizacion(DataSet Auth, DataRow Row)
        {
            Authentication = Auth;
            row = Row;
        }
        public void RecibirActualizacion(DataSet Auth, decimal monto) 
        {
            Authentication = Auth;
            Monto = monto;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DepositoATerceros depositoA = new DepositoATerceros();
            this.Visible = false;
            depositoA.EnviarDatos(this, ID_TipoCuenta, NoCuenta, Authentication, Nombres, Monto);
            depositoA.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RDPT.RecibirActualizacion(Authentication, Monto);
            RDPT.Visible = true;
            this.Dispose();
        }

        private void CerrarSesion_Click(object sender, EventArgs e)
        {
            RDPT.Dispose();
            CerrarSesion sesion = new CerrarSesion();
            sesion.EnviarDatos(this);
            sesion.Show();
        }

        private void Depositos_Load(object sender, EventArgs e)
        {

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
    }
}
