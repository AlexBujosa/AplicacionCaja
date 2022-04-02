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
        public RDPT()
        {
            InitializeComponent();
        }
        public void EnviarData(General general, int id_TipoCuenta, int noCuenta)
        {
            General = general;
            ID_TipoCuenta = id_TipoCuenta;
            NoCuenta = noCuenta;
        }

        private void RDPT_Load(object sender, EventArgs e)
        {

        }
    }
}
