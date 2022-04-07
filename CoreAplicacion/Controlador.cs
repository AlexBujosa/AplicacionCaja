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
            string connection = @"workstation id=NationalBank.mssql.somee.com;packet size=4096;user id=BujosaRey_SQLLogin_1;pwd=38ctzqy9qa;data source=NationalBank.mssql.somee.com;persist security info=False;initial catalog=NationalBank";
            return connection;
        }
    }
}