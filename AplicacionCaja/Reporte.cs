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
    public partial class Reporte : Form
    {
        private int NoCuenta;
        private decimal Monto;
        private decimal MontoTransaccion;
        private int DbCr;
        private int ID_TipoTransaccion;
        private string[] MensajeReporte = { "Cantidad Transferida: ", "Cantidad Depositada:", "Pago de Prestamo:", "Cantidad depositada: ", "Cantidad Retirada:" };
        private string[] TipoTransaccion = { "Transferencia a Terceros", "Deposito a Tercero", "Pago de Prestamo", "Deposito", "Retiro" };
        private string Tercero = "";
        public Reporte()
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("messagesReport", MensajeReporte[ID_TipoTransaccion - 1]));
            reportParameters.Add(new ReportParameter("typeTransaction", TipoTransaccion[ID_TipoTransaccion - 1]));
            reportParameters.Add(new ReportParameter("amountMessageReport", "DOP $ " + MontoTransaccion.ToString()));
            reportParameters.Add(new ReportParameter("numberAcount", NoCuenta.ToString()));
            reportParameters.Add(new ReportParameter("availableBalance", "DOP $ " + Monto.ToString()));
            if(Tercero != "")
            {
                reportParameters.Add(new ReportParameter("anotherPerson", Tercero));
                reportParameters.Add(new ReportParameter("messageT", "Tercero:"));
            }
            else
            {
                reportParameters.Add(new ReportParameter("anotherPerson", ""));
                reportParameters.Add(new ReportParameter("messageT", ""));
            }
            reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
        }

        private void Reporte_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
        public void EnviarDatos(int noCuenta, decimal monto, decimal montoTransaccion, int dbCr, int id_TipoTransaccion)
        {
            NoCuenta = noCuenta;
            Monto = monto;
            MontoTransaccion = montoTransaccion;
            DbCr = dbCr;
            ID_TipoTransaccion = id_TipoTransaccion;
        }
        public void EnviarDatos(int noCuenta, decimal monto, decimal montoTransaccion, int dbCr, int id_TipoTransaccion, string tercero)
        {
            NoCuenta = noCuenta;
            Monto = monto;
            MontoTransaccion = montoTransaccion;
            DbCr = dbCr;
            ID_TipoTransaccion = id_TipoTransaccion;
            Tercero = tercero;
        }
    }
}
