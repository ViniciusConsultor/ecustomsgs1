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
using TechLink.SyncDataModel;

namespace TechLink.WindowsClientSync
{
    public partial class eCustomClientSyncSvc : ServiceBase
    {
        private WindowsServiceLog logging = new WindowsServiceLog();
        public static NameValueCollection Settings = null;
        private ClientConfigurableSettings clientConfigurableSettings = null;
        ServerInterfacesHelper serverInterfacesHelper = null;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private string seri = string.Empty;
        private string branchid = string.Empty;

        public eCustomClientSyncSvc()
        {
            InitializeComponent();
            logging.WriteEntry("Initialize Service");
            timer.Interval = 5000;
            timer.Tick += new EventHandler(timer_Tick);

            string strd = System.IO.Path.Combine(FDHelper.AppDir(),
                                                     System.IO.Path.GetFileName(
                                                         FDHelper.RgGetUserProfilePath()));
            var coccyx =
                BoneReader.GetBoneInfo(strd);
            var coc = XRayController.TranslateBoneInformation(coccyx);
            string[] sss = coc.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            seri = new Guid(sss[0]).ToString();
            branchid = FDHelper.RgCodeOfUnit();

        }

        void timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            var ProxyGenericServer = serverInterfacesHelper.ServerInterfacesDispatcher.GenericServer;

            var token =
                ProxyGenericServer.StartSync(branchid, seri);
            if (string.IsNullOrEmpty(token))
            {
                timer.Stop();
                return;
            }

            //Sync Company
            var companies = DataModelManager.GetUnSyncedItems("tblCompany");

            if (companies.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (companies.Count() / 1000) + companies.Count() % 1000 > 0 ? 1 : 0;

                while (!finished)
                {
                    var n = (from item in companies
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblCompany", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblCompany).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblCompany", n);
                        ncount++;
                    }
                    if (ncount > max)

                        finished = true;
                }

            }
            else if (companies.Count()>0)
            {
                if (ProxyGenericServer.Sync(token, "tblCompany", companies))
                {
                    foreach (object obj in companies)
                    {
                        (obj as tblCompany).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblCompany", companies);
                }
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
