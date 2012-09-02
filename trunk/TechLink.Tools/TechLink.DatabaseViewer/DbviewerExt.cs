using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechLink.DatabaseViewer.DataTransferObjects;

namespace TechLink.DatabaseViewer
{
    public static class DbviewerExt
    {
        public static string ToConnectionString(this DatabaseInfo value)
        {
            StringBuilder sqlConnectionStr = new StringBuilder();

            // sets the server.
            sqlConnectionStr.Append("Data Source=");
            sqlConnectionStr.Append(value.Server);
            sqlConnectionStr.Append("; ");

            // sets the database.
            if (value.Name.Length != 0)
            {
                sqlConnectionStr.Append("Initial Catalog=");
                sqlConnectionStr.Append(value.Name);
                sqlConnectionStr.Append("; ");
            }
            /* sets the user name and the password. 
             * (the password isn't required, 
             * but if the name exists then the user tries to authenticate throught sql authentication)
             **/
            if (!value.IsIntergratedSecurityMode)
            {
                sqlConnectionStr.Append("User Id=");
                sqlConnectionStr.Append(value.Username);
                sqlConnectionStr.Append("; Password=");
                sqlConnectionStr.Append(value.Password);
                sqlConnectionStr.Append(";");
            }
            else
            {
                sqlConnectionStr.Append("Integrated Security=SSPI;");
            }

            return sqlConnectionStr.ToString();
        }

        public static bool ObjectNullOrEmpty(this object value)
        {
            return value == null || value.ToString().Trim().Length == 0;
        }

        public static bool ObjectToBoolean(this object value)
        {
            if(value.ObjectNullOrEmpty())
            {
                return false;
            }
            else if (value.ToString().Equals("no") || value.ToString().Equals("false") || value.ToString().Equals("0"))
            {
                return false;
            }
            else if (value.ToString().Equals("yes") || value.ToString().Equals("true") || value.ToString().Equals("1"))
            {
                return true;
            }

            return false;
        }
    }
}
