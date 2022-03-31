using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCaja.Modelos
{
    class usuario
    {
        public int ID_Cliente { get; set; }
        public string Usuario { get; set; }
        public string Tipo_Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Pin { get; set; }
    }
}
