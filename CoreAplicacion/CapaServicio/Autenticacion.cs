using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace CoreAplicacion.CapaServicio
{
    public class Autenticacion
    {
        public string ConnectionStrings;
        SqlConnection connection;
        SqlCommand sqlCommand;
        public DataSet Autenticarse(string Usuario, string Contraseña, int Pin)
        {
            DataSet Auth = new DataSet();
            Controlador controlador = new Controlador();
            ConnectionStrings = controlador.ObtenerConexion();
            connection.ConnectionString = ConnectionStrings;
            connection.Open();
            SqlDataReader reader = Autenticar(Usuario, Contraseña, Pin);
            int ID_Cliente;

            if (reader.Read())
            {
                ID_Cliente = int.Parse(reader["ID_Cliente"].ToString());
            }

            return Auth;
        }
        public DataSet TodosDatoCliente(int ID_Cliente)
        {
            DataSet Auth = new DataSet();
            sqlCommand = new SqlCommand();
            return Auth;
        }
        public SqlDataReader Autenticar(string Usuario, string Contraseña, int Pin)
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetAutenticarse";
            sqlCommand.Parameters.AddWithValue("@Usuario", Usuario);
            sqlCommand.Parameters.AddWithValue("@Contra", Contraseña) ;
            sqlCommand.Parameters.AddWithValue("@Pin", Pin);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Connection = connection;
            SqlDataReader datareader = sqlCommand.ExecuteReader();
            return datareader;
        }
    }
}