using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using ConnectionController;
using ECustoms.DAL;
using ExceptionHandler.Logging;

namespace TechLink.WindowsClientSync
{
    public partial class eCustomClientSyncSvc : ServiceBase
    {
        private WindowsServiceLog logging = new WindowsServiceLog();
        public static NameValueCollection Settings = null;
        private ClientConfigurableSettings clientConfigurableSettings = null;

        public eCustomClientSyncSvc()
        {
            InitializeComponent();
            logging.WriteEntry("Initialize Service");
        }

        protected override void OnStart(string[] args)
        {
            logging.WriteEntry("OnStart Service");
            #region GetSettings
            if (Settings == null)
            {
                Settings = ConfigurationManager.AppSettings;
            }

            clientConfigurableSettings = new ClientConfigurableSettings(Settings);
            #endregion

            #region Init Remote Connection

            ServerInterfacesHelper serverInterfacesHelper = null;
            try
            {
                serverInterfacesHelper = ConnectionManager.ConnectToServer(
                    clientConfigurableSettings.ServerURL, clientConfigurableSettings.ServerPORT, "100101",
                    clientConfigurableSettings.ClientPort);
            }
            catch (Exception ex)
            {
                logging.WriteEntry(
                    string.Format("Error connect to the server with paramates:\r\nServer URL: {0}\r\nServer port: {1}\r\n{2}\r\n{3}",
                    clientConfigurableSettings.ServerURL,
                    clientConfigurableSettings.ServerPORT,
                    ex.Message, ex.StackTrace));
                Process.GetCurrentProcess().Kill();
            }

            #endregion

            if (serverInterfacesHelper == null)
            {
                logging.WriteEntry(
                    string.Format("Can not connect to the server with paramaters url: {0}, port: {1}",
                    clientConfigurableSettings.ServerURL, clientConfigurableSettings.ServerPORT));
                Process.GetCurrentProcess().Kill();
            }

            var ProxyGenericServer = serverInterfacesHelper.ServerInterfacesDispatcher.GenericServer;
            
            logging.WriteEntry("Start Service successfully!");
        }

        protected override void OnStop()
        {
            logging.WriteEntry("OnStop Service");
        }
    }
}
