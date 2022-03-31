using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
namespace CoreAplicacion
{
    
    public class Controlador
    {
        public string ObtenerConexion()
        {
            return ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }
    }
}