using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCaja.Modelos
{
    class nocuenta
    {
        public int NoCuenta { get; set; }
        public decimal Monto { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_TipoCuenta { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaUltimaActualizacion { get; set; }
    }
}
