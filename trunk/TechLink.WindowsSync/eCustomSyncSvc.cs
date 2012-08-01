using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.ServiceProcess;
using System.Text;
using AbstractServerConsole;
using ExceptionHandler;
using ServerConsole;

namespace TechLink.WindowsSync
{
    public partial class eCustomSyncSvc : ServiceBase
    {
        private static IServerConsole serverActivator = null;

        public eCustomSyncSvc()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            serverActivator = new RemoteServerActivator();

            string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            ServerConsoleSettings serverConsoleSettings = new ServerConsoleSettings(ConfigurationManager.AppSettings);
            string assemblyDirectory = Path.Combine(currentDirectory, serverConsoleSettings.ServerAssembliesFolder);
            string filePath = Path.Combine(assemblyDirectory, serverConsoleSettings.RemoteServerActivatorAssembly);
            ObjectHandle objectHandle = null;

            try
            {
                objectHandle =
                        Activator.CreateInstanceFrom(filePath, serverConsoleSettings.ActivatorName, true,
                                                                                                                                         BindingFlags.Instance | BindingFlags.Public, null, null, null, null,
                                                                                                                                         AppDomain.CurrentDomain.Evidence);
            }
            catch (Exception ex)
            {
                ProcessException.Handle(ex, "eCustomSyncSvc.OnStart(string[] args)");
                throw ex.InnerException;
            }

            try
            {
                serverActivator = (IServerConsole)objectHandle.Unwrap();
                //GlobalUsage.RemoteServerActivator = serverActivator;
            }
            catch (Exception e)
            {
                ProcessException.Handle(e, "eCustomSyncSvc.OnStart(string[] args)");
            }

            InitializeComponent();
            try
            {
                serverActivator.Start(args);
            }
            catch (Exception exception)
            {
                ProcessException.Handle(exception, "eCustomSyncSvc c-tor");
                ProcessException.ErrorNotify.NotifyUser(exception.Message + "\n" +
                        exception.InnerException.Message);
            }
        }

        protected override void OnStop()
        {
        }
    }
}
