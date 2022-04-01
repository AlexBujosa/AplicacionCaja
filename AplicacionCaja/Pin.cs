using AplicacionCaja.Capa_de_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IntegracionAplicacion;

namespace AplicacionCaja
{
    public partial class Pin : Form
    {
        string usuario, clave;
        int pin;
        Form1 Form;
        public Pin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int vr;
            if (textBox1.TextLength == 4 && int.TryParse(textBox1.Text, out vr))
            {
                pin = int.Parse(textBox1.Text);
                Integracion ASM = new Integracion();
                DataSet Auth = new DataSet();
                Auth = ASM.Autenticacion(usuario, clave, pin);

            }
            else
            {
                MessageBox.Show("El Pin debe tener solo numeros y 4 digitos");
                textBox1.Text = "";
            }
        }
        public void Enviar(string Usuario, string Clave, Form1 form)
        {
            usuario = Usuario;
            clave = Clave;
            Form = form;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pin_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form.Visible = true;
            this.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
