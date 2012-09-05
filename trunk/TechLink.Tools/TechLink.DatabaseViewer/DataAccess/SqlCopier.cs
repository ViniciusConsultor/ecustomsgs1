using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TechLink.DatabaseViewer.DataTransferObjects;
using TechLink.DatabaseViewer.Subtext.Scripting;

namespace TechLink.DatabaseViewer.DataAccess
{
    public class SqlCopier
    {
        private SqlConnection connection;
        private SqlCommand command;

        private string sqlConnection = string.Empty;

        public SqlCopier(string connectionString)
        {
            sqlConnection = connectionString;
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }

        public string Database
        {
            get
            {
                if (connection != null)
                {
                    return connection.Database;
                }
                return string.Empty;
            }
        }

        public DataTable GetDataFromTable(string tableName)
        {
            string sqlQuery = "SELECT * FROM " + tableName;
            DataTable table = InvokeCommand(sqlQuery) as DataTable;

            return table;
        }

        public List<TableInfo> GetAllTables()
        {
            string sqlQuery = "SELECT * FROM INFORMATION_SCHEMA.Tables WHERE TABLE_TYPE='BASE TABLE'";
            DataTable table = InvokeCommand(sqlQuery) as DataTable;

            if (table == null) return new List<TableInfo>();

            List<TableInfo> lst = new List<TableInfo>();
            foreach (DataRow dataRow in table.Rows)
            {
                TableInfo tableInfo = new TableInfo()
                                          {
                                              Schema = dataRow["TABLE_SCHEMA"].ToString(),
                                              Name = dataRow["TABLE_NAME"].ToString(),
                                              Type = dataRow["TABLE_TYPE"].ToString()
                                          };
                lst.Add(tableInfo);
            }

            return (from item in lst orderby item.Name select item).ToList();
        }

        public List<FieldInfo> GetAllFieldsOfTable(string  tableName)
        {
            string sqlQuery = string.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='{0}'", tableName);
            DataTable table = InvokeCommand(sqlQuery) as DataTable;

            if (table == null) return new List<FieldInfo>();

            List<FieldInfo> lst = new List<FieldInfo>();
            foreach (DataRow dataRow in table.Rows)
            {
                FieldInfo fieldInfo = new FieldInfo()
                                          {
                                              Name = dataRow["COLUMN_NAME"].ToString(),
                                              Type = dataRow["DATA_TYPE"].ToString(),
                                              IsNullable = dataRow["IS_NULLABLE"].ObjectToBoolean(),
                                              MaxLength =
                                                  dataRow["CHARACTER_MAXIMUM_LENGTH"].ObjectNullOrEmpty()
                                                      ? -1
                                                      : Convert.ToInt32(dataRow["CHARACTER_MAXIMUM_LENGTH"])
                };
                lst.Add(fieldInfo);
            }

            return (from item in lst orderby item.Name select item).ToList();
        }

        public bool ExistingFieldInTable(string tableName, string fieldCheck)
        {
            string sqlQuery = string.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='{0}' AND column_name='{1}'", tableName, fieldCheck);
            DataTable table = InvokeCommand(sqlQuery) as DataTable;

            if (table == null) return false;

            return table.Rows.Count > 0;
        }

        private object InvokeCommand(string commandText, bool isGetData = true)
        {
            command.CommandText = commandText;
            command.CommandType = CommandType.Text;
            object returnValue = null;
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                if (connection.State != ConnectionState.Open)
                {
                    throw new Exception("Cannot create a connection to database!");
                }

                if (isGetData)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    returnValue = ConstructData(reader);
                }
                else
                {
                    returnValue = command.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Lỗi thực thi lệnh: \r\n" + commandText, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }


            return returnValue;
        }

        private DataTable ConstructData(SqlDataReader reader)
        {
            try
            {
                if (reader.IsClosed)
                    throw new InvalidOperationException("Attempt to use a closed SqlDataReader");

                DataTable dataTable = new DataTable();

                // constructs the columns data.
                for (int i = 0; i < reader.FieldCount; i++)
                    dataTable.Columns.Add(reader.GetName(i), reader.GetFieldType(i));

                // constructs the table's data.
                while (reader.Read())
                {
                    object[] row = new object[reader.FieldCount];
                    reader.GetValues(row);
                    dataTable.Rows.Add(row);
                }
                // Culture info.
                dataTable.Locale = CultureInfo.InvariantCulture;
                // Accepts changes.
                dataTable.AcceptChanges();

                return dataTable;
            }
            catch (Exception e)
            {
                Log.WriteErrorToLog(e.Message);
                throw;
            }
        }

        public object RunSqlQuery(string sqlQuery)
        {
            var result = InvokeCommand(sqlQuery, false);
            return result;
        }

        public object RunSqlReader(string sqlQuery)
        {
            var result = InvokeCommand(sqlQuery, true);
            return result;
        }

        public object RunScript(string tSqlScript)
        {
            object result = null;
            SqlScriptRunner runner = new SqlScriptRunner(tSqlScript);

            if (connection.State == ConnectionState.Closed)
                connection.Open();
            if (connection.State != ConnectionState.Open)
            {
                throw new Exception("Cannot create a connection to database!");
            }
            
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                result = runner.Execute(transaction);
                transaction.Commit();
            }
            
            return result;
        }

        public object RunStoreProc(string storedName, object paramerters, bool isGetData = false)
        {
            command.CommandText = storedName;
            command.CommandType = CommandType.StoredProcedure;
            object returnValue = null;
            if (paramerters != null)
            {
                object[] objects = paramerters as object[];
                CreateParameters(ref command, objects);
            }

            if (connection.State == ConnectionState.Closed)
                connection.Open();
            if (connection.State != ConnectionState.Open)
            {
                throw new Exception("Cannot create a connection to database!");
            }

            if (isGetData)
            {
                SqlDataReader reader = command.ExecuteReader();
                returnValue = ConstructData(reader);
            }
            else
            {
                returnValue = command.ExecuteNonQuery();
            }

            return returnValue;
        }

        private void CreateParameters(ref SqlCommand sqlCommand, object[] objects)
        {
            for (int i = 0; i < objects.Length; i += 2)
            {
                SqlParameter parameter = new SqlParameter(objects[i].ToString(), objects[i + 1]);
                sqlCommand.Parameters.Add(parameter);
            }
        }
    }
}
