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
            
            #region Sync tblDeclaration
            var declarations = DataModelManager.GetUnSyncedItems("tblDeclaration");

            if (declarations.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (declarations.Count() / 1000) + declarations.Count() % 1000 > 0 ? 1 : 0;

                while (!finished)
                {
                    var n = (from item in declarations
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblDeclaration", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblDeclaration).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblDeclaration", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (declarations.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblDeclaration", declarations))
                {
                    foreach (object obj in declarations)
                    {
                        (obj as tblDeclaration).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblDeclaration", declarations);
                }
            }
            #endregion

            #region Sync tblVehicle
            var vehicles = DataModelManager.GetUnSyncedItems("tblVehicle");

            if (vehicles.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (vehicles.Count() / 1000) + vehicles.Count() % 1000 > 0 ? 1 : 0;

                while (!finished)
                {
                    var n = (from item in vehicles
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblVehicle", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblVehicle).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblVehicle", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (vehicles.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblVehicle", vehicles))
                {
                    foreach (object obj in vehicles)
                    {
                        (obj as tblVehicle).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblVehicle", vehicles);
                }
            }
            #endregion

            return;
            #region Sync tblDeclarationVehicle
            var declarationVehicles = DataModelManager.GetUnSyncedItems("tblDeclarationVehicle");

            if (declarationVehicles.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (declarationVehicles.Count() / 1000) + declarationVehicles.Count() % 1000 > 0 ? 1 : 0;

                while (!finished)
                {
                    var n = (from item in declarationVehicles
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblDeclarationVehicle", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblDeclarationVehicle).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblDeclarationVehicle", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (declarationVehicles.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblDeclarationVehicle", declarationVehicles))
                {
                    foreach (object obj in declarationVehicles)
                    {
                        (obj as tblDeclarationVehicle).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblDeclarationVehicle", declarationVehicles);
                }
            }
            #endregion

            #region Sync Company
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
            else if (companies.Count() > 0)
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

            #endregion

            #region Sync tblApplicationObject
            var applicationObjects = DataModelManager.GetUnSyncedItems("tblApplicationObject");

            if (applicationObjects.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (applicationObjects.Count() / 1000) + applicationObjects.Count() % 1000 > 0 ? 1 : 0;

                while (!finished)
                {
                    var n = (from item in applicationObjects
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblApplicationObject", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblApplicationObject).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblApplicationObject", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (applicationObjects.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblApplicationObject", applicationObjects))
                {
                    foreach (object obj in applicationObjects)
                    {
                        (obj as tblApplicationObject).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblApplicationObject", applicationObjects);
                }
            }
            #endregion

            #region Sync tblCheck
            var checks = DataModelManager.GetUnSyncedItems("tblCheck");

            if (checks.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (checks.Count() / 1000) + checks.Count() % 1000 > 0 ? 1 : 0;

                while (!finished)
                {
                    var n = (from item in checks
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblCheck", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblCheck).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblCheck", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (checks.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblCheck", checks))
                {
                    foreach (object obj in checks)
                    {
                        (obj as tblCheck).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblCheck", checks);
                }
            }
            #endregion

            #region Sync tblCustoms
            var customs = DataModelManager.GetUnSyncedItems("tblCustoms");

            if (customs.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (customs.Count() / 1000) + customs.Count() % 1000 > 0 ? 1 : 0;

                while (!finished)
                {
                    var n = (from item in customs
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblCustoms", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblCustom).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblCustoms", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (customs.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblCustoms", customs))
                {
                    foreach (object obj in customs)
                    {
                        (obj as tblCustom).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblCustoms", customs);
                }
            }
            #endregion

            #region Sync tblDeclarationLoan
            var declarationLoans = DataModelManager.GetUnSyncedItems("tblDeclarationLoan");

            if (declarationLoans.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (declarationLoans.Count() / 1000) + declarationLoans.Count() % 1000 > 0 ? 1 : 0;

                while (!finished)
                {
                    var n = (from item in declarationLoans
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblDeclarationLoan", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblDeclarationLoan).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblDeclarationLoan", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (declarationLoans.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblDeclarationLoan", declarationLoans))
                {
                    foreach (object obj in declarationLoans)
                    {
                        (obj as tblDeclarationLoan).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblDeclarationLoan", declarationLoans);
                }
            }
            #endregion

            #region Sync tblGate
            var gates = DataModelManager.GetUnSyncedItems("tblGate");

            if (gates.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (gates.Count() / 1000) + gates.Count() % 1000 > 0 ? 1 : 0;

                while (!finished)
                {
                    var n = (from item in gates
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblGate", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblDeclarationLoan).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblGate", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (gates.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblGate", gates))
                {
                    foreach (object obj in gates)
                    {
                        (obj as tblDeclarationLoan).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblGate", gates);
                }
            }
            #endregion

            #region Sync tblGoodsType
            var goodsTypes = DataModelManager.GetUnSyncedItems("tblGoodsType");

            if (goodsTypes.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (goodsTypes.Count() / 1000) + goodsTypes.Count() % 1000 > 0 ? 1 : 0;

                while (!finished)
                {
                    var n = (from item in goodsTypes
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblGoodsType", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblGoodsType).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblGoodsType", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (goodsTypes.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblGoodsType", goodsTypes))
                {
                    foreach (object obj in goodsTypes)
                    {
                        (obj as tblGoodsType).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblGoodsType", goodsTypes);
                }
            }
            #endregion
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
