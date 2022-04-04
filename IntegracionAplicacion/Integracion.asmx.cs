using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CoreAplicacion;

namespace IntegracionAplicacion
{
    /// <summary>
    /// Summary description for Integracion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class Integracion : System.Web.Services.WebService
    {
        Core core = new Core();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public DataSet Autenticacion(string usuario, string contraseña, int pin)
        {
            DataSet auth = core.Autenticacion(usuario, contraseña, pin);
            return auth;
        }
        [WebMethod]
        public DataSet Transaccion(int ID_TipoTransaccion, int DbCr, string Comentario, int NoCuenta, decimal Monto)
        {
            DataSet dataset = core.Transaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, Monto);
            return dataset;
        }
    }
}
