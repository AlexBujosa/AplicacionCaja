using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
namespace Integracion
{
    /// <summary>
    /// Descripción breve de IntegracionASMX
    /// </summary>
    [WebService(Namespace = "http://integracionFigureBank.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class IntegracionASMX : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable Autenticacion(string usuario, string contraseña, int pin)
        {

            DataTable auth = new DataTable();
            auth = Autenticacion(string usuario, string contraseña, int pin) //autenticacion del core, que ejecutará el select
            return auth;
        }
    }
}
