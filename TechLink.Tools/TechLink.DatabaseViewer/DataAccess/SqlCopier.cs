using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TechLink.DatabaseViewer.DataTransferObjects;

namespace TechLink.DatabaseViewer.DataAccess
{
    public class SqlCopier
    {
        private SqlConnection connection;
        private SqlCommand command;

        private string sqlConnection = string.Empty;

        public  SqlCopier(string connectionString)
        {
            sqlConnection = connectionString;
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;

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

            if(table==null) return new List<TableInfo>();

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

        private object InvokeCommand(string commandText, bool isGetData= true)
        {
            command.CommandText = commandText;
            command.CommandType = CommandType.Text;
            object returnValue = null;
            try
            {
                connection.Open();
                if (connection.State != ConnectionState.Open)
                {
                    throw new Exception("Cannot create a connection to database!");
                }

                if(isGetData)
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
                MessageBox.Show("Lỗi thực thi lệnh: " + commandText,"Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public bool RunSqlQuery(string sqlQuery)
        {
            var result = InvokeCommand(sqlQuery, false);
            return result != null;
        }
    }
}
