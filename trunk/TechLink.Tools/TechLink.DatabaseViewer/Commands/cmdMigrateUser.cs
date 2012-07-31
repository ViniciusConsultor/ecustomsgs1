using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TechLink.DatabaseViewer.DataAccess;

namespace TechLink.DatabaseViewer.Commands
{
    public class cmdMigrateUser : MigrateCommandBase
    {
        public cmdMigrateUser(SqlCopier sqlSourceCopier, SqlCopier sqlDestCopier, object parameters)
            : base(sqlSourceCopier, sqlDestCopier, parameters)
        {
            this.Name = "cmdMigrateUser";
        }

        public override bool Execute()
        {
            DataTable tblSourceUser = SqlSourceCopier.GetDataFromTable("tblUser");
            if(tblSourceUser!=null && tblSourceUser.Rows.Count>0)
            {
                try
                {

                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
            //return base.Execute();
        }
    }
}
