using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCaja.Modelos
{
    class Transacciones
    {
        public int ID_Transacciones { get; set; }
        public decimal Monto { get; set; }
        public int ID_TipoTransaccion { get; set; }
        public int DbCr { get; set; }
        public string Comentario { get; set; }
        public int NoCuenta { get; set; }
        public string FechaTransaccion { get; set; }
    }
}
