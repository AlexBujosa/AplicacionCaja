using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCaja.Modelos
{
    class Pago
    {
        public int NoCuenta { get; set; }
        public string Entidad { get; set; }
        public int ID_TipoEntidad { get; set; }
        public int ID_Transacciones { get; set; }
    }
}
