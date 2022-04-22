using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplicacionCaja.ABControls;

namespace AplicacionCaja
{
    public partial class pagoPrestamo : Form
    {
        public RDPT RDPT;
        public int ID_TipoCuenta;
        public int NoCuenta;
        public DataSet Authentication;
        public List<int> ID_Prestamos;
        public string Nombres;
        public decimal Monto;
        public List<decimal> Montos;
        public List<decimal> MontoPlazoMax;
        public List<int> TipoPrestamo;
        public List<decimal> Tasa;
        public List<int> Duracion;
        public List<string> FechaPrestamo;
        private List<Button> Buttons;
        public pagoPrestamo()
        {
            InitializeComponent();
        }

        private void pagoPrestamo_Load(object sender, EventArgs e)
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
        public void AgregarBotones()
        {
            int distancia = 0;
            int x = 367;
            int y = 200;
            renderButton renderButton = new renderButton();
            Buttons = new List<Button>();
            Montos = new List<decimal>();
            MontoPlazoMax = new List<decimal>();
            TipoPrestamo = new List<int>();
            Tasa = new List<decimal>();
            Duracion = new  List<int>();
            FechaPrestamo = new List<string>();
            ID_Prestamos = new List<int>();

            for (int i = 0; i < Authentication.Tables[5].Rows.Count; i++)
            {
                if(int.Parse(Authentication.Tables[5].Rows[i][4].ToString()) == NoCuenta)
                {
                    Button newButton = renderButton.CrearBoton();
                    newButton.Text = "Prestamo " + Authentication.Tables[5].Rows[i][0].ToString();
                    newButton.Location = new Point(x, y + distancia);
                    Buttons.Add(newButton);
                    ID_Prestamos.Add(int.Parse(Authentication.Tables[5].Rows[i][0].ToString()));
                    Montos.Add(decimal.Parse(Authentication.Tables[5].Rows[i][1].ToString()));
                    MontoPlazoMax.Add(decimal.Parse(Authentication.Tables[5].Rows[i][2].ToString()));
                    TipoPrestamo.Add(int.Parse(Authentication.Tables[5].Rows[i][3].ToString()));
                    Tasa.Add(decimal.Parse(Authentication.Tables[5].Rows[i][5].ToString()));
                    Duracion.Add(int.Parse(Authentication.Tables[5].Rows[i][6].ToString()));
                    FechaPrestamo.Add(Authentication.Tables[5].Rows[i][7].ToString());
                    this.Controls.Add(newButton);
                    newButton.Name = "button" + (i + 1).ToString();
                    if (newButton.Name == "button1")
                    {
                        newButton.Click += button1_Click;
                    }
                    else if (newButton.Name == "button2")
                    {
                        newButton.Click += button2_Click;
                    }
                    else if (newButton.Name == "button3")
                    {
                        newButton.Click += button3_Click;
                    }
                    else if (newButton.Name == "button4")
                    {
                        newButton.Click += button4_Click;
                    }
                    distancia += 86;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Prestamo prestamo = new Prestamo();
            prestamo.EnviarDatos(this, ID_TipoCuenta, NoCuenta, Authentication, Nombres, Monto,ID_Prestamos[0], Montos[0], MontoPlazoMax[0], TipoPrestamo[0], Tasa[0], Duracion[0], FechaPrestamo[0]);
            prestamo.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Prestamo prestamo = new Prestamo();
            prestamo.EnviarDatos(this, ID_TipoCuenta, NoCuenta, Authentication, Nombres, Monto, ID_Prestamos[1], Montos[1], MontoPlazoMax[1], TipoPrestamo[1], Tasa[1], Duracion[1], FechaPrestamo[1]);
            prestamo.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Prestamo prestamo = new Prestamo();
            prestamo.EnviarDatos(this, ID_TipoCuenta, NoCuenta, Authentication, Nombres, Monto, ID_Prestamos[2], Montos[2], MontoPlazoMax[2], TipoPrestamo[2], Tasa[2], Duracion[2], FechaPrestamo[2]);
            prestamo.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Prestamo prestamo = new Prestamo();
            prestamo.EnviarDatos(this, ID_TipoCuenta, NoCuenta, Authentication, Nombres, Monto, ID_Prestamos[3], Montos[3], MontoPlazoMax[3], TipoPrestamo[3], Tasa[3], Duracion[3], FechaPrestamo[3]);
            prestamo.Show();
        }

        private void CerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion sesion = new CerrarSesion();
            sesion.EnviarDatos(this);
            sesion.Show();
            this.Enabled = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RDPT.RecibirActualizacion(Authentication, Monto);
            RDPT.Show();
            this.Dispose();
        }
        public void RecibirActualizacion(DataSet Auth, decimal monto)
        {
            Authentication = Auth;
            Monto = monto;
        }
    }
}
