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
    public partial class ConsultarMovimientos : Form
    {
        public RDPT RDPT;
        public DataSet Authentication;
        public int NoCuenta;
        public ConsultarMovimientos()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ConsultarMovimientos_Load(object sender, EventArgs e)
        {
            string[] TiposTransacciones = { "TransferenciaTercero", "DepositoTercero", "PagoPrestamo", "Deposito", "Retiro"};
            var joinResult = (from p in Authentication.Tables[4].AsEnumerable()
                              join t in Authentication.Tables[3].AsEnumerable()
                              on p.Field<int>("ID_Transacciones") equals t.Field<int>("ID_Transacciones")
                              where p.Field<int>("NoCuenta") == NoCuenta
                              select new
                              {
                                  NoCuenta = t.Field<int>("NoCuenta"),
                                  Monto = t.Field<decimal>("Monto"),
                                  Tercero = p.Field<int>("Entidad"),
                                  Comentario = t.Field<string>("Comentario"),
                                  Transaccion = TiposTransacciones[int.Parse(t.Field<int>("ID_TipoTransaccion").ToString()) - 1],
                                  FechaTransaccion = t.Field<DateTime>("FechaTransaccion")

                              }).ToList();
            var joinResultRD = (from t in Authentication.Tables[3].AsEnumerable()
                                where t.Field<int>("Nocuenta") == NoCuenta && (t.Field<int>("ID_TipoTransaccion") == 4 || t.Field<int>("ID_TipoTransaccion") == 5)
                                select new
                                {
                                    NoCuenta = t.Field<int>("NoCuenta"),
                                    Monto = t.Field<decimal>("Monto"),
                                    Comentario = t.Field<string>("Comentario"),
                                    Transaccion = TiposTransacciones[int.Parse(t.Field<int>("ID_TipoTransaccion").ToString()) - 1],
                                    FechaTransaccion = t.Field<DateTime>("FechaTransaccion")
                                }).ToList();

            dataGridView1.DataSource = joinResult;
            dataGridView2.DataSource = joinResultRD;
        }
        public void EnviarDatos(RDPT rdpt, DataSet auth, int noCuenta)
        {
            RDPT = rdpt;
            Authentication = auth;
            NoCuenta = noCuenta;
        }

        private void ConsultarMovimientos_FormClosing(object sender, FormClosingEventArgs e)
        {
            RDPT.Show();
            this.Dispose();
        }
    }
}
