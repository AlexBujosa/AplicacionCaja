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
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=NationalBank;Integrated Security=True";
            return connection;
        }
    }
}