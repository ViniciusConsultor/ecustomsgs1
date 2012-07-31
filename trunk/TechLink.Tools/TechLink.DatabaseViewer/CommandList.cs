using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechLink.DatabaseViewer.Commands;
using TechLink.DatabaseViewer.DataAccess;

namespace TechLink.DatabaseViewer
{
    public class CommandList
    {
        public string[] CommandNames = new string[] { "cmdMigrateUser" };
        public Dictionary<string, MigrateCommandBase> Commands = new Dictionary<string, MigrateCommandBase>();

        public void Initial(SqlCopier sqlSource,SqlCopier sqlDest, object param)
        {
            Commands.Clear();

            MigrateCommandBase cmd1 = new cmdMigrateUser(sqlSource, sqlDest, param);
            Commands.Add(CommandNames[0], cmd1);
        }

        public bool ExecuteCommand(string commandName)
        {
            return Commands[commandName].Execute();
        }
    }
}
