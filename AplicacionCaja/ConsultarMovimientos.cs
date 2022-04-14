using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace AplicacionCaja
{
    public partial class ConsultarMovimientos : Form
    {
        public RDPT RDPT;
        public DataSet Authentication;
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
            var joinResult = (from t in Authentication.Tables[3].AsEnumerable()
                              join p in Authentication.Tables[4].AsEnumerable()
                              on t.Field<string>("ID_Transacciones") equals p.Field<string>("ID_Transacciones")
                              select new
                              {
                                  NoCuenta = t.Field<int>("NoCuenta"),
                                  Monto = t.Field<decimal>("Monto"),

                              }).ToList();


        }
        public void EnviarDatos(RDPT rdpt, DataSet auth)
        {
            RDPT = rdpt;
            Authentication = auth;
        }
    }
}
