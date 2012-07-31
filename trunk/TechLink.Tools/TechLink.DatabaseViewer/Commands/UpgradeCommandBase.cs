using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechLink.DatabaseViewer.DataAccess;

namespace TechLink.DatabaseViewer.Commands
{
    public class UpgradeCommandBase
    {
        private object _params;
        protected SqlCopier _SqlCopier;
        public string Version { get; set; }
        public object Parameters { get { return _params; } }
        public UpgradeCommandBase(SqlCopier sqlCopier)
        {
            Version = "1.0.0";
            _SqlCopier = sqlCopier;
        }

        public virtual bool DoUpgrade(object parameters)
        {
            _params = parameters;
            return false;
            
        }
    }
}
