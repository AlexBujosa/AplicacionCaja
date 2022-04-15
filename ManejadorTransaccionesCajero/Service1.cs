using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using AplicacionCaja;

namespace ManejadorTransaccionesCajero
{
    public partial class ServicioManejadorCuadre : ServiceBase
    {
        public Process Process = new Process();
        public Process[] processes;
        int a = 0;
        public ServicioManejadorCuadre()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string process = (@"C:\Users\david\source\repos\AlexBujosa\AplicacionCaja\AplicacionCaja\bin\Debug\AplicacionCaja.exe");
            Process.Start(process);
            timer1.Enabled = true;
            timer1.Interval = 5000;
        }

        protected override void OnStop()
        {
            timer1.Stop();
        }
        static bool isRunning(string name)
        {
            try
            {
                Process.GetProcessesByName(name);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int hora = DateTime.Now.Hour;
            int minuto = DateTime.Now.Minute;
            int segundo = DateTime.Now.Second;
            string process = (@"C:\Users\david\source\repos\AlexBujosa\AplicacionCaja\AplicacionCaja\bin\Debug\AplicacionCaja.exe");
            if (hora == 16 && minuto == 32 && segundo >= 50)
            {
                
                if (!isRunning(process) && a == 0)
                {
                    a++;
                    Process.Start(process);
                    CuadreTransaccional ct = new CuadreTransaccional();
                    ct.Show();

                }
                else
                {
                    Process.Start(process);
                    CuadreTransaccional ct = new CuadreTransaccional();
                    ct.Show();
                }
            }
        }
    }
}
