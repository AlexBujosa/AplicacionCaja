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
            int y = 149;
            renderButton renderButton = new renderButton();
            Buttons = new List<Button>();
            for (int i = 0; i<Authentication.Tables[0].Rows.Count; i++)
            {
                Button newButton = renderButton.CrearBoton();
                newButton.Text = "No Cuenta " + Authentication.Tables[0].Rows[i][0].ToString();
                newButton.Location = new Point(x, y + distancia);
                Buttons.Add(newButton);
                ID_TipoCuenta.Add(int.Parse(Authentication.Tables[0].Rows[i][3].ToString()));
                NoCuenta.Add(int.Parse(Authentication.Tables[0].Rows[i][0].ToString()));
                this.Controls.Add(newButton);
                newButton.Name = "button" + (i + 1).ToString();
                distancia += 86;
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            RDPT rdpt = new RDPT();
            rdpt.EnviarData(this, ID_TipoCuenta[0], NoCuenta[0]);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
