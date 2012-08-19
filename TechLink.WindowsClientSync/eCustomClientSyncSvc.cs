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
using ECustoms.BOL;
using ECustoms.DAL;
using ECustoms.Utilities;
using ExceptionHandler.Logging;
using techlink.Digest;

namespace TechLink.WindowsClientSync
{
    public partial class eCustomClientSyncSvc : ServiceBase
    {
        private WindowsServiceLog logging = new WindowsServiceLog();
        public static NameValueCollection Settings = null;
        private ClientConfigurableSettings clientConfigurableSettings = null;
        ServerInterfacesHelper serverInterfacesHelper = null;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private ClientInfo clientInfo = null;
        public eCustomClientSyncSvc()
        {
            InitializeComponent();
            logging.WriteEntry("Initialize Service");
            timer.Interval = 5000;
            timer.Tick += new EventHandler(timer_Tick);
            clientInfo = new ClientInfo();
            var bone = BoneReader.GetBoneInfo(FDHelper.RgGetUserProfilePath());
            var s = XRayController.TranslateBoneInformation(bone);
            string[] ss = s.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                sb.AppendLine(ss[i]);
            }

            // Set company name
            if (ss[1] != null)
            {
                clientInfo.Name = ss[1].ToString();
            }


            //clientInfo.Serial = FDHelper.get
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            var ProxyGenericServer = serverInterfacesHelper.ServerInterfacesDispatcher.GenericServer;
            var UnSyncedUsers = UserFactory.SelectAllUnSyncedUser();

            if (UnSyncedUsers.Count <= 20)
            {

            }

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



            logging.WriteEntry("Start Service successfully!");
        }

        protected override void OnStop()
        {
            logging.WriteEntry("OnStop Service");
        }
    }
}
