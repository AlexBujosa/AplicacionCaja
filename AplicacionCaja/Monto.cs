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
        public void EnviarDatos(Form form, int id_TipoTransaccion, int dbCr, string comentario, int noCuenta, DataRow row)
        {
            Form = form;
            ID_TipoTransaccion = id_TipoTransaccion;
            DbCr = dbCr;
            Comentario = comentario;
            NoCuenta = noCuenta;
            Row = row;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                monto = decimal.Parse(textBox1.Text);
                Integracion ASM = new Integracion();
                if (monto > decimal.Parse(Row[1].ToString()) && DbCr == 0)
                    MessageBox.Show("No tiene dinero suficiente para retirar");
                else if (monto < 0)
                    MessageBox.Show("Error: No montos menores que 0");
                else
                {
                    DataSet data = ASM.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, monto);
                    if (Form.GetType().ToString() == "AplicacionCaja.Deposito")
                    {
                        Deposito deposito = new Deposito();
                        deposito = (Deposito)Form;
                        deposito.ActualizarAuth(data);
                    }
                    else
                    {
                        Retiro retiro = new Retiro();
                        retiro = (Retiro)Form;
                        retiro.ActualizarAuth(data);
                    }
                    Form.Enabled = true;
                    this.Dispose();
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
