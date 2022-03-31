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

namespace AplicacionCaja
{
    public partial class Form1 : Form
    {
        Controlador controlador;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            General general = new General();
            general.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controlador = new Controlador();
            if (textBox1.TextLength < 8)
            {
                MessageBox.Show("No se acepta menos 8 caracteres en el Usuario");
                textBox1.Clear();
            }
            else if (textBox2.TextLength < 8)
            {
                MessageBox.Show("No se acepta menos 8 caracteres en la contraseña");
                textBox2.Clear();
            }
            else if (controlador.AlgoritmoCombinacionSegura(textBox1.Text) && controlador.AlgoritmoCombinacionSegura(textBox2.Text))
            {
                Pin pin = new Pin();
                pin.Enviar(textBox1.Text, textBox2.Text, this);
                pin.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("No contiene las combinaciones indicadas en el Usuario o Contraseña(Mayuscula, Minuscula y Numero)");
            }
        }
    }
}
