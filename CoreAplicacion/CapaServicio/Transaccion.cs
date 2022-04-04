using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CoreAplicacion.CapaServicio
{
    public class Transaccion
    {
        public string ConnectionStrings;
        SqlConnection Connection;
        SqlTransaction transaction;
        SqlCommand sqlCommand;
        public DataSet transaccion(int ID_TipoTransaccion, int DbCr, string Comentario, int NoCuenta, decimal Monto)
        {
            DataSet dataSet = null;
            Connection = new SqlConnection();
            Controlador controlador = new Controlador();
            ConnectionStrings = controlador.ObtenerConexion();
            Connection.ConnectionString = ConnectionStrings;
            Connection.Open();
            transaction = Connection.BeginTransaction();
            int completado = InsertarTransaccion(ID_TipoTransaccion, DbCr, Comentario, NoCuenta, Monto);
            if(completado == 1)
            {
                completado = UpdateNoCuenta(NoCuenta, Monto, DbCr);  
                if(completado == 1)
                {
                    DataSet dataSet1 = ConseguirUltimaActualizacion(NoCuenta);
                    int ID_Transacciones  = int.Parse(dataSet1.Tables[0].Rows[0][0].ToString());
                    dataSet = ConseguirTBL(NoCuenta, ID_Transacciones);
                }
            }
            
            Connection.Close();
            return dataSet;
        }
        public int UpdateNoCuenta(int NoCuenta, decimal Monto, int DbCr)
        {
            int respuesta = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppUpdateNoCuenta";
            sqlCommand.Parameters.AddWithValue("@NoCuenta", NoCuenta);
            sqlCommand.Parameters.AddWithValue("@Monto", Monto);
            sqlCommand.Parameters.AddWithValue("@DbCr", DbCr);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Connection = Connection;
            sqlCommand.Transaction = transaction;
            try
            {
                respuesta = sqlCommand.ExecuteNonQuery();
                transaction.Commit();
            }
            catch{
                transaction.Rollback();
            }
            return respuesta;
        }
        public int InsertarTransaccion(int ID_TipoTransaccion, int DbCr, string Comentario, int NoCuenta, decimal Monto)
        {
            int respuesta = 0;
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppInsertTransaccion";
            sqlCommand.Parameters.AddWithValue("@Monto", Monto);
            sqlCommand.Parameters.AddWithValue("@ID_TipoTransaccion", ID_TipoTransaccion);
            sqlCommand.Parameters.AddWithValue("@DbCr", DbCr);
            sqlCommand.Parameters.AddWithValue("@Comentario", Comentario);
            sqlCommand.Parameters.AddWithValue("@NoCuenta", NoCuenta);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Connection = Connection;
            sqlCommand.Transaction = transaction;
            try
            {
                respuesta = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            return respuesta;
        }
        public DataSet ConseguirUltimaActualizacion(int NoCuenta)
        {
            DataSet dataset = new DataSet();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetLastTransaction";
            sqlCommand.Parameters.AddWithValue("@NoCuenta", NoCuenta);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Connection = Connection;
            var da = new SqlDataAdapter(sqlCommand);
            da.Fill(dataset);
            return dataset;
        }
        public DataSet ConseguirTBL(int NoCuenta, int ID_Transacciones)
        {
            DataSet dataset = new DataSet();
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "ppGetTbl";
            sqlCommand.Parameters.AddWithValue("@NoCuenta", NoCuenta);
            sqlCommand.Parameters.AddWithValue("@ID_Transacciones", ID_Transacciones);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Connection = Connection;
            var da = new SqlDataAdapter(sqlCommand);
            da.Fill(dataset);
            return dataset;
        }
    }
}