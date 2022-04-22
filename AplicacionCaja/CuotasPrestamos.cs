using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCaja
{
    public class CuotasPrestamos
    {
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString);
        private SqlCommand command;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SqlConnection abrirConexion()
        {
            if(connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }
        public SqlConnection cerrarConexion()
        {
            if(connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            return connection;
        }
        public DataSet ConseguirPagos(int ID_prestamo)
        {
            DataSet dataSet = new DataSet();
            command = new SqlCommand();
            command.Connection = abrirConexion();
            command.CommandText = "ppGetCuotas";
            command.Parameters.AddWithValue("@ID_Prestamo", ID_prestamo);
            command.CommandType = CommandType.StoredProcedure;
            var da = new SqlDataAdapter(command);
            try
            {
                da.Fill(dataSet);
            }
            catch
            {
                log.Error("Ocurrio un error Buscando la informacion en la base de datos");
            }
            return dataSet;
        }
        public int Update(int ID_prestamo, string Prestamos)
        {
            int resultado = 0;
            command = new SqlCommand();
            command.Connection = abrirConexion();
            command.CommandText = "ppUpdatePrestamo";
            command.Parameters.AddWithValue("@ID_Prestamo", ID_prestamo);
            command.Parameters.AddWithValue("@Prestamos", Prestamos);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                resultado = command.ExecuteNonQuery();
            }
            catch
            {

            }
            return resultado;
        }
    }
}
