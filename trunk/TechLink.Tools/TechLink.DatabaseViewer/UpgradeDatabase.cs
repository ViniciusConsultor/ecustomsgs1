using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechLink.DatabaseViewer.Commands;
using TechLink.DatabaseViewer.DataAccess;

namespace TechLink.DatabaseViewer
{
    public class UpgradeDatabase
    {
        public static string[] CommandNames = new string[] { "1.0.1" };

        public Dictionary<string, UpgradeCommandBase> UpgradeCommands =new Dictionary<string, UpgradeCommandBase>();
        public void InitialCommands(SqlCopier sqlCopier)
        {
            UpgradeCommandBase cmd1 = new UpgradeVersion100(sqlCopier);
            UpgradeCommands.Add(CommandNames[0], cmd1);
        }
    }
}
