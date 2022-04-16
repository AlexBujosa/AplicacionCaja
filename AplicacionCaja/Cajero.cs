using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AplicacionCaja
{
    
    class Cajero
    {
        public int ID_Cajero = 1;
        public string ConnectionStrings;
        public SqlConnection Connection;
        SqlCommand sqlCommand;
        public decimal ConseguirSaldo()
        {
            decimal resultado = 0;
            DataSet dataSet = new DataSet();
            Connection = new SqlConnection();
            ConnectionStrings = Conexion();
            Connection.ConnectionString = ConnectionStrings;
            Connection.Open();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetSaldo";
            sqlCommand.Parameters.AddWithValue("@ID_Cajero", ID_Cajero);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Connection = Connection;
            var da = new SqlDataAdapter(sqlCommand);
            da.Fill(dataSet);
            try
            {
                resultado = decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception)
            {

            }
            Connection.Close();
            return resultado;
        }
        public int InsertarTransaccionCaja(int ID_Transacciones, decimal Monto, int DbCr)
        {
            Connection = new SqlConnection();
            ConnectionStrings = Conexion();
            Connection.ConnectionString = ConnectionStrings;
            Connection.Open();
            int resultado = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppInsertTransaccionCaja";
            sqlCommand.Parameters.AddWithValue("@ID_Transacciones", ID_Transacciones);
            sqlCommand.Parameters.AddWithValue("@ID_Cajero", ID_Cajero);
            sqlCommand.Parameters.AddWithValue("@DbCr", DbCr);
            sqlCommand.Parameters.AddWithValue("@Monto", Monto);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Connection = Connection;
            try
            {
                resultado = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            Connection.Close();
            return resultado;
        }
        public int Cuadre()
        {
            Connection = new SqlConnection();
            ConnectionStrings = Conexion();
            Connection.ConnectionString = ConnectionStrings;
            Connection.Open();
            int resultado = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppCuadre";
            sqlCommand.Parameters.AddWithValue("@ID_Cajero", ID_Cajero);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Connection = Connection;
            try
            {
                resultado = sqlCommand.ExecuteNonQuery();

            }
            catch (Exception)
            {

            }
            Connection.Close();
            return resultado;
        }
        public int UpdateCaja(decimal Saldo_Cajero, int DbCr)
        {
            Connection = new SqlConnection();
            ConnectionStrings = Conexion();
            Connection.ConnectionString = ConnectionStrings;
            Connection.Open();
            int resultado = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppUpdateCajero";
            sqlCommand.Parameters.AddWithValue("@ID_Cajero", ID_Cajero);
            sqlCommand.Parameters.AddWithValue("@DbCr", DbCr);
            sqlCommand.Parameters.AddWithValue("@Saldo_Cajero", Saldo_Cajero);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Connection = Connection;
            try
            {
                resultado = sqlCommand.ExecuteNonQuery();
                
            }
            catch (Exception)
            {

            }
            Connection.Close();
            return resultado;
        }
        public string Conexion()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=NationalBankCajero;Integrated Security=True";
        }
    }
}
