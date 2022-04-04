﻿using CoreAplicacion.CapaServicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CoreAplicacion
{
    /// <summary>
    /// Summary description for Core
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class Core : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public DataSet Autenticacion(string usuario, string contraseña, int pin)
        {
            Autenticacion autenticacion = new Autenticacion();
            DataSet auth = autenticacion.Autenticarse(usuario, contraseña, pin);
            return auth;
        }
        [WebMethod]
        public DataSet Transaccion(int ID_TipoTransaccion, int DbCr, string Comentario, int NoCuenta, decimal Monto)
        {
            DataSet dataset = null;
            return dataset;
        }
    }
}
