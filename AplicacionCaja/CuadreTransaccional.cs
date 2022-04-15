using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace AplicacionCaja
{
    public partial class CuadreTransaccional : Form
    {
        public CuadreTransaccional()
        {
            InitializeComponent();
        }

        private void CuadreTransaccional_Load(object sender, EventArgs e)
        {
            string reducir = "";
            Cajero cajero = new Cajero();
            decimal monto = cajero.ConseguirSaldo();
            if (monto> 200000)
            {
                reducir = "Reducir DOP $" + (monto - 200000).ToString() + " para cuadrar";
            }
            else if(monto < 200000)
            {
                reducir = "Agregar DOP$ " + (200000 - monto).ToString() + " para cuadrar";
            }
            else
            {
                reducir = "Ya esta cuadrado";
            }

            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Total", monto.ToString()));
            reportParameters.Add(new ReportParameter("mensajeCuadre", reducir));
            this.reportViewer1.RefreshReport();
        }
    }
}
