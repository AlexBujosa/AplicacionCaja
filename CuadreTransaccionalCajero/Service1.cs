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

namespace CuadreTransaccionalCajero
{
    public partial class Service1 : ServiceBase
    {
        public Process Process = new Process();
        public Process[] processes;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
        static bool isRunning(int id)
        {
            try
            {
                Process.GetProcessById(id);
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
            string process = (@"C:\Users\david\source\repos\AlexBujosa\AplicacionCaja\AplicacionCaja\bin\Release\AplicacionCaja.exe");
            processes = Process.GetProcesses();
            
            if(hora == 13 && minuto == 50 && segundo >= 50)
            {
                foreach (Process IProcess in processes)
                {
                    if (IProcess.ProcessName.Contains(process))
                    {
                        Process = IProcess;
                    }
                }
                if (!isRunning(Process.Id))
                {
                    Process.Start(process);
                    CuadreTransaccional ct = new CuadreTransaccional();
                    ct.Show();

                }
                else
                {
                    CuadreTransaccional ct = new CuadreTransaccional();
                    ct.Show();
                }
                
            }
        }
    }
}
