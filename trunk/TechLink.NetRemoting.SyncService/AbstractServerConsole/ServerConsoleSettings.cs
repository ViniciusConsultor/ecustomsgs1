using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AbstractServerConsole
{
    public class ServerConsoleSettings
    {
        private string serverAssembliesFolder = "Server Assemblies";
        private string remoteServerActivatorAssembly = "ServerConsole.dll";
        private string activatorName = "ServerConsole.RemoteServerActivator";


        public ServerConsoleSettings(NameValueCollection configuration)
        {
            ReadConfiguration(configuration);
        }

        private void ReadConfiguration(NameValueCollection configuration)
        {
            if (configuration["ServerAssembliesFolder"] != null)
            {
                serverAssembliesFolder = configuration["ServerAssembliesFolder"];
            }
            if (configuration["RemoteServerActivatorAssembly"] != null)
            {
                remoteServerActivatorAssembly = configuration["RemoteServerActivatorAssembly"];
            }
            if (configuration["ActivatorName"] != null)
            {
                activatorName = configuration["ActivatorName"];
            }
        }

        public string ServerAssembliesFolder
        {
            get
            {
                return serverAssembliesFolder;
            }
        }

        public string RemoteServerActivatorAssembly
        {
            get
            {
                return remoteServerActivatorAssembly;
            }
        }

        public string ActivatorName
        {
            get
            {
                return activatorName;
            }
        }
    }
}
