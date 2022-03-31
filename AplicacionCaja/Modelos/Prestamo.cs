using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCaja.Modelos
{
    class Prestamo
    {
        public int ID_Prestamo { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoPlazoMax { get; set; }
        public int TipoPrestamo { get; set; }
        public int NoCuenta { get; set; }
        public decimal Tasa { get; set; }
        public int Duracion { get; set; }
        public string FechaPrestamo { get; set; }
    }
}
