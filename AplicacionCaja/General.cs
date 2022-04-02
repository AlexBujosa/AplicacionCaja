using System;
using System.Data;
using System.Windows.Forms;
using AplicacionCaja.ABControls;
using System.Drawing;
using System.Collections.Generic;

namespace AplicacionCaja
{
    public partial class General : Form
    {
        public DataSet Authentication;
        private List<Button> Buttons;
        private List<int> ID_TipoCuenta;
        private List<int> NoCuenta;
        private string Nombres;
        private List<decimal> Monto;
        public General()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Hora: " + DateTime.Now.ToString();
        }
        public void Enviar(DataSet Auth)
        {
            Authentication = Auth;
        }
        private void General_Load(object sender, EventArgs e)
        {
            label3.Text = "Bienvenido " + Authentication.Tables[1].Rows[0][2].ToString();
        }
        public void AgregarBotones()
        {
            int distancia = 0;
            int x = 367;
            int y = 200;
            renderButton renderButton = new renderButton();
            Buttons = new List<Button>();
            ID_TipoCuenta = new List<int>();
            NoCuenta = new List<int>();
            Monto = new List<decimal>();
            for (int i = 0; i < Authentication.Tables[0].Rows.Count; i++)
            {
                Button newButton = renderButton.CrearBoton();
                newButton.Text = "No Cuenta " + Authentication.Tables[0].Rows[i][0].ToString();
                newButton.Location = new Point(x, y + distancia);
                Buttons.Add(newButton);
                ID_TipoCuenta.Add(int.Parse(Authentication.Tables[0].Rows[i][3].ToString()));
                NoCuenta.Add(int.Parse(Authentication.Tables[0].Rows[i][0].ToString()));
                Monto.Add(decimal.Parse(Authentication.Tables[0].Rows[i][1].ToString()));
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
            Nombres = Authentication.Tables[1].Rows[0][2].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            RDPT rdpt = new RDPT();
            rdpt.EnviarData(this, ID_TipoCuenta[0], NoCuenta[0], Authentication,Nombres, Monto[0]);
            rdpt.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            RDPT rdpt = new RDPT();
            rdpt.EnviarData(this, ID_TipoCuenta[1], NoCuenta[1], Authentication, Nombres, Monto[1]);
            rdpt.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            RDPT rdpt = new RDPT();
            rdpt.EnviarData(this, ID_TipoCuenta[2], NoCuenta[2], Authentication, Nombres, Monto[2]);
            rdpt.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            RDPT rdpt = new RDPT();
            rdpt.EnviarData(this, ID_TipoCuenta[3], NoCuenta[3], Authentication, Nombres, Monto[3]);
            rdpt.Show();
        }
    }
}
