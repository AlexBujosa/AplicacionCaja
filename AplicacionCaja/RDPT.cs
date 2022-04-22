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
    public partial class RDPT : Form
    {
        public General General;
        public int ID_TipoCuenta;
        public int NoCuenta;
        public DataSet Authentication;
        public string Nombres;
        public decimal Monto;
        public RDPT()
        {
            InitializeComponent();
        }
        public void EnviarDatos(General general, int id_TipoCuenta, int noCuenta, DataSet auth, string nombres, decimal monto)
        {
            General = general;
            ID_TipoCuenta = id_TipoCuenta;
            NoCuenta = noCuenta;
            Authentication = auth;
            Nombres = nombres;
            Monto = monto;
        }

        private void RDPT_Load(object sender, EventArgs e)
        {
            if(ID_TipoCuenta == 1)
            {
                label3.Text = "Cuenta de Ahorro " + NoCuenta.ToString();
            }
            else if(ID_TipoCuenta == 2)
            {
                label3.Text = "Cuenta de Credito " + NoCuenta.ToString();
            }
            else
            {
                label3.Text = "Cuenta Corriente " + NoCuenta.ToString();
            }
            label2.Text = Nombres.ToString();
            label5.Text = "$ " + Monto.ToString();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(DateTime.Now.Hour >= 7 && DateTime.Now.Hour < 12)
            {
                label1.Text = "Buenos dias,";
            }
            else if(DateTime.Now.Hour >= 12 && DateTime.Now.Hour <19)
            {
                label1.Text = "Buenas Tardes,";
            }
            else if (DateTime.Now.Hour >= 19)
            {
                label1.Text = "Buenas Noches,";
            }
            label5.Text = "$ " + Monto.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Retiro retiro = new Retiro();
            this.Visible = false;
            retiro.EnviarDatos(this, ID_TipoCuenta, NoCuenta, Authentication, Nombres, Monto);
            retiro.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Depositos depositos = new Depositos();
            this.Visible = false;
            depositos.EnviarDatos(this, ID_TipoCuenta, NoCuenta, Authentication, Nombres, Monto);
            depositos.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pagoPrestamo PagoPrestamo = new pagoPrestamo();
            this.Visible = false;
            PagoPrestamo.EnviarDatos(this, ID_TipoCuenta, NoCuenta, Authentication, Nombres, Monto);
            PagoPrestamo.AgregarBotones();
            PagoPrestamo.Show(); 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Transferencia transferencia = new Transferencia();
            this.Visible = false;
            transferencia.EnviarDatos(this,ID_TipoCuenta, NoCuenta, Authentication, Nombres, Monto);
            transferencia.Show();
        }

        private void CerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion sesion = new CerrarSesion();
            sesion.EnviarDatos(this);
            sesion.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            General.RecibirActualizacion(Authentication);
            General.Show();
            this.Dispose();
        }
        public void RecibirActualizacion(DataSet Auth, decimal monto)
        {
            Authentication = Auth;
            Monto = monto;
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

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ConsultarMovimientos mov = new ConsultarMovimientos();
            mov.EnviarDatos(this, Authentication, NoCuenta);
            mov.Show();
        }
    }
}
