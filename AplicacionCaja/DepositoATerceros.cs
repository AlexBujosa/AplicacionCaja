using AplicacionCaja.integracion;
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
    public partial class DepositoATerceros : Form
    {
        public Depositos Depositos;
        public int ID_TipoCuenta;
        public int NoCuenta;
        public DataSet Authentication;
        public string Nombres;
        public decimal Monto;
        public DataRow row;
        public DataRow Row;
        public DataSet data;
        private int DbCr;
        private decimal montoDeposito;
        private int ID_TipoTransaccion;
        private string Comentario;
        private List<string> valor;
        private int Entidad;
        private int ID_TipoEntidad;
        private string Tercero;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public DepositoATerceros()
        {
            InitializeComponent();
        }

        private void DepositoATerceros_Load(object sender, EventArgs e)
        {
            DataTable table = Authentication.Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (int.Parse(table.Rows[i][0].ToString()) == NoCuenta)
                    row = table.Rows[i];
            }
            DbCr = 2;
            ID_TipoTransaccion = 2;
            IntegracionASMXSoapClient ASM = new IntegracionASMXSoapClient();
            data = ASM.ObtenerTodasCuentasDiferentes(int.Parse(Authentication.Tables[1].Rows[0][0].ToString()), "Droog ethereal develop 269138");
            ChargeCmbx();
            //valor = new List<string>();
            //for (int i = 0; i < comboBox1.Items.Count; i++)
            //{
            //    valor.Add(comboBox1.Items[i].ToString());
            //}
            comboBox1.SelectedItem = comboBox1.Items[0];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem == null)
                {
                    comboBox1.SelectedItem = comboBox1.Items[0];
                }
                if (!comboBox1.DroppedDown && char.IsDigit(comboBox1.SelectedItem.ToString()[0]))
                {
                    int NoCuenta = int.Parse(comboBox1.SelectedItem.ToString());
                    foreach (DataRow R in data.Tables[0].Rows)
                    {
                        if (int.Parse(R[0].ToString()) == NoCuenta)
                        {
                            Row = R;
                            label2.Text = "NoCuenta: " + R[0].ToString();
                            label3.Text = "Sexo: " + R[1].ToString();
                            label4.Text = "Cedula: " + R[2].ToString();
                            label5.Text = "Nombres: " + R[3].ToString();
                            Tercero = R[3].ToString();
                        }
                    }
                    pictureBox1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = false;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;
                    button6.Visible = true;
                    label8.Visible = true;
                    textBox1.Visible = true;
                    this.Size = new Size(985, 659);
                    ID_TipoEntidad = 1;
                    Entidad = int.Parse(Row[0].ToString());
                }
                else
                {
                    pictureBox1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = true;
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    button5.Visible = false;
                    button6.Visible = false;
                    label8.Visible = false;
                    textBox1.Visible = false;
                    if (DateTime.Now.Second % 3 == 0)
                        label6.Text = "Seleccione el Numero de Cuenta .";
                    else if (DateTime.Now.Second % 3 == 1)
                        label6.Text = "Seleccione el Numero de Cuenta ..";
                    else if (DateTime.Now.Second % 3 == 2)
                        label6.Text = "Seleccione el Numero de Cuenta ...";
                    this.Size = new Size(985, 487);
                }
            }
            catch
            {

            }
           
        }
        public void EnviarDatos(Depositos depositos, int id_TipoCuenta, int noCuenta, DataSet auth, string nombres, decimal monto)
        {
            Depositos = depositos;
            ID_TipoCuenta = id_TipoCuenta;
            NoCuenta = noCuenta;
            Authentication = auth;
            Nombres = nombres;
            Monto = monto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            montoDeposito = 500;
            IntegracionASMXSoapClient ASM = new IntegracionASMXSoapClient();
            int Entidad = int.Parse(comboBox1.SelectedItem.ToString());
            DialogResult dialogResult = MessageBox.Show("¿Realmente deseas realizar esta transacción?", "Transaccion A Terceros", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Comentario = textBox1.Text == null ? "Deposito realizado por " + Nombres : textBox1.Text;
                DataSet dataSet = ASM.TransaccionATercero(NoCuenta, Entidad, 1, ID_TipoTransaccion, DbCr, Comentario, montoDeposito, "Droog ethereal develop 269138");
                Actualizaciones(dataSet);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            montoDeposito = 1000;
            IntegracionASMXSoapClient ASM = new IntegracionASMXSoapClient();
            int Entidad = int.Parse(comboBox1.SelectedItem.ToString());
            DialogResult dialogResult = MessageBox.Show("¿Realmente deseas realizar esta transacción?", "Transaccion A Terceros", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Comentario = textBox1.Text == null ? "Deposito realizado por "+ Nombres : textBox1.Text;
                DataSet dataSet = ASM.TransaccionATercero(NoCuenta, Entidad, 1, ID_TipoTransaccion, DbCr, Comentario, montoDeposito, "Droog ethereal develop 269138");
                Actualizaciones(dataSet);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            montoDeposito = 1500;
            IntegracionASMXSoapClient ASM = new IntegracionASMXSoapClient();
            int Entidad = int.Parse(comboBox1.SelectedItem.ToString());
            DialogResult dialogResult = MessageBox.Show("¿Realmente deseas realizar esta transacción?", "Transaccion A Terceros", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Comentario = textBox1.Text == null ? "Deposito realizado por " + Nombres : textBox1.Text;
                DataSet dataSet = ASM.TransaccionATercero(NoCuenta, Entidad, 1, ID_TipoTransaccion, DbCr, Comentario, montoDeposito, "Droog ethereal develop 269138");
                Actualizaciones(dataSet);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            montoDeposito = 2000;
            IntegracionASMXSoapClient ASM = new IntegracionASMXSoapClient();
            int Entidad = int.Parse(comboBox1.SelectedItem.ToString());
            DialogResult dialogResult = MessageBox.Show("¿Realmente deseas realizar esta transacción?", "Transaccion A Terceros", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Comentario = textBox1.Text == null ? "Deposito realizado por " + Nombres : textBox1.Text;
                DataSet dataSet = ASM.TransaccionATercero(NoCuenta, Entidad, 1, ID_TipoTransaccion, DbCr, Comentario, montoDeposito, "Droog ethereal develop 269138");
                Actualizaciones(dataSet);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            montoDeposito = 2500;
            IntegracionASMXSoapClient ASM = new IntegracionASMXSoapClient();
            int Entidad = int.Parse(comboBox1.SelectedItem.ToString());
            DialogResult dialogResult = MessageBox.Show("¿Realmente deseas realizar esta transacción?", "Transaccion A Terceros", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                Comentario = textBox1.Text == null ? "Deposito realizado por " + Nombres.ToString() : textBox1.Text;
                DataSet dataSet = ASM.TransaccionATercero(NoCuenta, Entidad, 1, ID_TipoTransaccion, DbCr, Comentario, montoDeposito, "Droog ethereal develop 269138");
                Actualizaciones(dataSet);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MontoTercero montoTercero = new MontoTercero();
            montoTercero.EnviarDatos(this, row, Authentication, NoCuenta, Entidad, ID_TipoEntidad, ID_TipoTransaccion, DbCr, Comentario, Nombres);
            montoTercero.Show();
            this.Enabled = false;
        }
        public void ChargeCmbx()
        {
            DataTable table = data.Tables[0];
            comboBox1.Items.Add("Seleccione el numero de cuenta");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBox1.Items.Add(table.Rows[i][0].ToString());
            }
            
        }
        private void CerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion sesion = new CerrarSesion();
            sesion.EnviarDatos(this);
            sesion.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Depositos.RecibirActualizacion(Authentication, Monto);
            Depositos.Show();
            this.Dispose();
        }
        public void Actualizaciones(DataSet dataSet)
        {
            try
            {
                comboBox1.SelectedItem = comboBox1.Items[0];
                ActualizarNoCuenta(dataSet);
                AgregarTransacciones(dataSet);
                AgregarPago(dataSet);
                TransaccionProcesada();
                DeseaHacerReporte();
                InsertarCajero(dataSet);
                Cajero cajero = new Cajero();
                log.Info($"El usuario {Authentication.Tables[2].Rows[0][1]} ha depositado {montoDeposito} a {label5.Text}. Numero de Cajero: {cajero.ID_Cajero} Hora: {DateTime.Now}   ");

            }
            catch (Exception)
            {
                TransaccionNoProcesada();
            }
            
            
        }
        public void InsertarCajero(DataSet dataset)
        {
            Cajero cajero = new Cajero();
            cajero.InsertarTransaccionCaja(int.Parse(dataset.Tables[1].Rows[0][0].ToString()), montoDeposito, DbCr);
            cajero.UpdateCaja(montoDeposito, DbCr);
            log.Info($"Se ha registrado el deposito realizo por {Authentication.Tables[2].Rows[0][1]} a {label5.Text}. Hora: {DateTime.Now}");
        }
        public void DeseaHacerReporte()
        {
            DialogResult dialogResult = MessageBox.Show(($"¿Deseas {Nombres} imprimir la transaccion?"), "Reporte", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Reporte reporte = new Reporte();
                reporte.EnviarDatos(NoCuenta, Monto, montoDeposito, DbCr, ID_TipoTransaccion, Tercero);
                reporte.Show();
                Cajero cajero = new Cajero();
                log.Info($"El usuario ha {Authentication.Tables[2].Rows[0][1]} realizado el reporte del deposito {montoDeposito} a {label5.Text} Hora: {DateTime.Now} Cajero: {cajero.ID_Cajero}");
                
            }
        }
        public void ActualizarNoCuenta(DataSet DATASET)
        {
            row = DATASET.Tables[0].Rows[0];
            for (int i = 0; i < Authentication.Tables[0].Rows.Count; i++)
            {
                if (int.Parse(Authentication.Tables[0].Rows[i][0].ToString()) == NoCuenta)
                {
                    Authentication.Tables[0].Rows[i][0] = row[0];
                    Authentication.Tables[0].Rows[i][1] = row[1];
                    Authentication.Tables[0].Rows[i][2] = row[2];
                    Authentication.Tables[0].Rows[i][2] = row[3];
                    Authentication.Tables[0].Rows[i][4] = row[4];
                    Monto = decimal.Parse(row[1].ToString());
                }
            }
        }
        public void AgregarTransacciones(DataSet DATASET)
        {
            Authentication.Tables[3].Rows.Add(DATASET.Tables[1].Rows[0].ItemArray);
        }
        public void AgregarPago(DataSet DATASET)
        {
            Authentication.Tables[4].Rows.Add(DATASET.Tables[2].Rows[0].ItemArray);
        }
        public void TransaccionProcesada()
        {
            MessageBox.Show("Transaccion Procesada");
        }
        public void TransaccionNoProcesada()
        {
            MessageBox.Show("Transaccion No Procesada");
        }
        public void RecibirActualizacion(DataSet Auth, decimal monto)
        {
            Authentication = Auth;
            Monto = monto;
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void CerrarSesion_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
