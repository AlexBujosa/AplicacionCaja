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
    public partial class Monto : Form
    {
        public Form Form;
        private decimal monto;
        private int ID_TipoTransaccion;
        private int DbCr;
        private string Comentario;
        private int NoCuenta;
        private DataRow Row;
        private DataSet Auth;

        public Monto()
        {
            InitializeComponent();
        }

        private void Monto_Load(object sender, EventArgs e)
        {
            if (DbCr == 0)
                label3.Text = "Monto a Retirar:";
            else
                label3.Text = "Monto a Depositar:";
        }
        public void EnviarDatos(Form form, int id_TipoTransaccion, int dbCr, string comentario, int noCuenta, DataRow row, DataSet auth)
        {
            Form = form;
            ID_TipoTransaccion = id_TipoTransaccion;
            DbCr = dbCr;
            Comentario = comentario;
            NoCuenta = noCuenta;
            Row = row;
            Auth = auth;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                monto = decimal.Parse(textBox1.Text);
                Integracion ASM = new Integracion();
                if (monto > decimal.Parse(Row[1].ToString()) && DbCr == 0)
                    MessageBox.Show("No tiene dinero suficiente para retirar");
                else
                {
                    DataSet data = ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, monto);
                    
                }
                    
            }
            catch(Exception)
            {
                MessageBox.Show("No se permite convertir un numero no decimal");
                textBox1.Text = "";
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form.Enabled = true;
            this.Dispose();
        }
    }
}
