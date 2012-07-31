using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechLink.DatabaseViewer.DataAccess;

namespace TechLink.DatabaseViewer.Commands
{
    public class MigrateCommandBase
    {
        protected SqlCopier SqlSourceCopier = null;
        protected SqlCopier SqlDestCopier = null;
        protected object Parameters = null;
        public MigrateCommandBase(SqlCopier sqlSourceCopier, SqlCopier sqlDestCopier, object parameters)
        {
            this.Name = "commandName";
            SqlSourceCopier = sqlSourceCopier;
            SqlDestCopier = sqlDestCopier;
            Parameters = parameters;
        }

        public string Name { get; set; }
        
        public virtual bool Execute()
        {
            return false;
        }

        public virtual void SetNewParams(object param)
        {
            Parameters = param;
        }

    }
}
