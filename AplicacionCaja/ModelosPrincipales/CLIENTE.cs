using AplicacionCaja.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCaja.ModelosPrincipales
{
    class CLIENTE
    {
        Cliente Cliente { get; set; }
        NOCUENTA[] NoCuentas { get; set; }
        usuario Usuario { get; set; }
    }
}
