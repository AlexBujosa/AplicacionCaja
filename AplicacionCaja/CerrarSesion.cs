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
    public partial class CerrarSesion : Form
    {
        public Form Form;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public CerrarSesion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form.Dispose();
            Form1 form1 = new Form1();
            form1.Show();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form.Enabled = true;
            this.Dispose();
        }
        public void EnviarDatos(Form form)
        {
            Form = form;
            Form.Enabled = false;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
