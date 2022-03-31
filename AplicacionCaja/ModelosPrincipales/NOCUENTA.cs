using AplicacionCaja.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCaja.ModelosPrincipales
{
    class NOCUENTA
    {
        nocuenta NoCuenta { get; set; }
        Transacciones[] Transacciones { get; set; }
        Pago[] Pagos { get; set; }
        Prestamo[] Prestamos { get; set; }

    }
}
