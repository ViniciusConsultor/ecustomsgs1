using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ECustoms.DAL
{
    public class DbConnection
    {
        private string connectionString;
        private SqlDataAdapter adapter;
        private SqlConnection conn;
        public DbConnection(string dbConnection)
        {
            connectionString = dbConnection;
            conn = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter();
        }


        private SqlConnection OpenConnection() {
            if (conn.State == ConnectionState.Closed || conn.State == System.Data.ConnectionState.Broken) {
                conn.Open();
            }
            return conn;
        }

        public DataTable ExecuteSelectQuery(string query) {
            
            return this.ExecuteSelectQuery(query, null);
        }

        /// <summary>
        /// Execute select query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public DataTable ExecuteSelectQuery(string query, params SqlParameter[] parameter){
            try
            {
                var command = new SqlCommand();
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                if (parameter != null) { 
                    command.Parameters.AddRange(parameter);
                }
                                              
                
                adapter.SelectCommand = command;
                var ds = new DataSet();
                adapter.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        /// <summary>
        /// Execute select query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public DataTable ExecuteSelectCommandText(string query)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                var ds = new DataSet();
                adapter.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception)
            {
                throw;
            }

        }


        public  int ExecuteNonQuery(string query)
        {
            return ExecuteNonQuery(query, null);
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                return command.ExecuteNonQuery(); ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object ExecuteScalar(string query)
        {
            return ExecuteScalar(query, null);
        }

        public object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                return command.ExecuteScalar(); ;
            }
            catch (Exception)
            {
                //TODO: Need to log here
                throw;
            }
        }
    }
}
