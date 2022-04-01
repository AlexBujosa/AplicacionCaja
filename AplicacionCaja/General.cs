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
    public partial class General : Form
    {
        public DataSet Authentication;
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
    }
}
