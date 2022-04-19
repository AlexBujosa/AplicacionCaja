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
using AplicacionCaja.integracion;

namespace AplicacionCaja
{
    public partial class Pin : Form
    {
        string usuario, clave;
        int pin;
        Form1 Form;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
                IntegracionASMXSoapClient ASM = new IntegracionASMXSoapClient();
                DataSet Auth = new DataSet();
                Auth = ASM.Autenticacion(usuario, clave, pin);
                if (Auth.Tables[2].Rows.Count > 0)
                {
                    Cajero cajero = new Cajero();
                    log.Info($"Usuario {Auth.Tables[2].Rows[0][1]} ha ingresado exitosamente. Hora: {DateTime.Now} Numero del cajero: {cajero.ID_Cajero} ");
                    if (Auth.Tables[2].Rows[0][2].ToString() == "Admin")
                    {
                        CuadreTransaccional cuadre = new CuadreTransaccional();
                        cuadre.Show();
                        this.Dispose();
                    }
                    else
                    {
                        General general = new General();
                        general.Enviar(Auth);
                        general.AgregarBotones();
                        general.Show();
                        this.Dispose();
                    }
                    
                }
                else
                {
                    MessageBox.Show("No existe ese usuario. Vuelve a intentarlo");
                    Form.Show();
                    this.Dispose();
                }
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

        private void button1_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
