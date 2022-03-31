using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCaja.Modelos
{
    class Cliente
    {
        public int ID_Cliente { get; set; }
        public string Cedula_Cliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Direccion_Cliente { get; set; }
        public string Sexo { get; set; }
        public string FechaNacimiento { get; set; }
        public int ID_Provincia { get; set; }
        public int ID_Municipio { get; set; }
        public int ID_Sector { get; set; }
        public decimal IngresosMensuales { get; set; }
        
    }
}
