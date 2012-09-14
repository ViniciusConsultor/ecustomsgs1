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
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Timers;
using AbstractServerConsole;
using ExceptionHandler;
using ExceptionHandler.Logging;
using ServerConsole;

namespace TechLink.WindowsSync
{
    public partial class eCustomSyncSvc : ServiceBase
    {
        private static IServerConsole serverActivator = null;
        WindowsServiceLog logging = new WindowsServiceLog();
        ServiceHost deletionService = new ServiceHost(typeof(eCustomSyncWCF));
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        
        public eCustomSyncSvc()
        {
            new WindowsServiceLog().WriteEntry("Service Initialize");
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 5000;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            
        }

        protected override void OnStart(string[] args)
        {
            logging.WriteEntry("Service start");
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
                logging.WriteEntry(ex, "eCustomSyncSvc.OnStart(string[] args)");
                throw ex.InnerException;
            }

            try
            {
                serverActivator = (IServerConsole)objectHandle.Unwrap();
                //GlobalUsage.RemoteServerActivator = serverActivator;
            }
            catch (Exception e)
            {
                logging.WriteEntry(e, "eCustomSyncSvc.OnStart(string[] args)");
            }
            
            try
            {
                serverActivator.Start(args);
            }
            catch (Exception exception)
            {
                logging.WriteEntry(exception, "eCustomSyncSvc c-tor");
            }

            logging.WriteEntry("Starting the timer listener!");
            timer.Start();

            logging.WriteEntry("Starting Deletion Service!");
            deletionService.Open();

            logging.WriteEntry("All Services Started successfully!");
        }

        protected override void OnStop()
        {
            logging.WriteEntry("Service Stop");
        }
    }
}
