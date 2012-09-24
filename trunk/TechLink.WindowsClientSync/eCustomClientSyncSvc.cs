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
        private System.Timers.Timer timer = new System.Timers.Timer();

        private string seri = string.Empty;
        private string branchid = string.Empty;
        private bool isSyncing = false;

        public eCustomClientSyncSvc()
        {
            InitializeComponent();
            logging.WriteEntry("Initialize Service");

            timer.Interval = 5000;
            //timer.Tick += new EventHandler(timer_Tick);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);

            string strd = System.IO.Path.Combine(FDHelper.AppDir(),
                                                     System.IO.Path.GetFileName(
                                                         FDHelper.RgGetUserProfilePath()));

            logging.WriteEntry("Initialize Service. Dat dir:" + strd);

            var coccyx =
                BoneReader.GetBoneInfo(strd);
            var coc = XRayController.TranslateBoneInformation(coccyx);
            string[] sss = coc.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            seri = new Guid(sss[0]).ToString();
            branchid = FDHelper.RgCodeOfUnit();

            logging.WriteEntry("Initialize Service. seri:" + seri + ", branchid:" + branchid);

        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!isSyncing)
                timer_Tick(this, new EventArgs());
        }

        void timer_Tick(object sender, EventArgs e)
        {
            isSyncing = true;

            logging.WriteEntry("Timer tick");

            var ProxyGenericServer = serverInterfacesHelper.ServerInterfacesDispatcher.GenericServer;

            var token =
                ProxyGenericServer.StartSync(branchid, seri);
            if (string.IsNullOrEmpty(token))
            {
                timer.Stop();
                logging.WriteError("Cannot get a token to transfer");
                return;
            }

            logging.WriteEntry("Start syncing");
            
            #region Sync tblDeclaration
            var declarations = DataModelManager.GetUnSyncedItems("tblDeclaration");

            if (declarations.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (declarations.Count() / 1000) + (declarations.Count() % 1000 > 0 ? 1 : 0);

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

            logging.WriteEntry("The tblDeclaration is Synced");

            #region Sync tblVehicle
            var vehicles = DataModelManager.GetUnSyncedItems("tblVehicle");

            if (vehicles.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (vehicles.Count() / 1000) + (vehicles.Count() % 1000 > 0 ? 1 : 0);

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

            logging.WriteEntry("The tblVehicle is Synced");
            
            #region Sync tblDeclarationVehicle
            var declarationVehicles = DataModelManager.GetUnSyncedItems("tblDeclarationVehicle");

            if (declarationVehicles.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (declarationVehicles.Count() / 1000) + (declarationVehicles.Count() % 1000 > 0 ? 1 : 0);

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

            logging.WriteEntry("The tblDeclarationVehicle is Synced");

            #region Sync Company
            var companies = DataModelManager.GetUnSyncedItems("tblCompany");

            if (companies.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (companies.Count() / 1000) + (companies.Count() % 1000 > 0 ? 1 : 0);

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

            logging.WriteEntry("The tblCompany is Synced");

            #region Sync tblApplicationObject
            var applicationObjects = DataModelManager.GetUnSyncedItems("tblApplicationObject");

            if (applicationObjects.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (applicationObjects.Count() / 1000) + (applicationObjects.Count() % 1000 > 0 ? 1 : 0);

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

            logging.WriteEntry("The tblApplicationObject is Synced");

            #region Sync tblCheck
            var checks = DataModelManager.GetUnSyncedItems("tblCheck");

            if (checks.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (checks.Count() / 1000) + (checks.Count() % 1000 > 0 ? 1 : 0);

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

            logging.WriteEntry("The tblCheck is Synced");

            #region Sync tblCustoms
            var customs = DataModelManager.GetUnSyncedItems("tblCustoms");

            if (customs.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (customs.Count() / 1000) + (customs.Count() % 1000 > 0 ? 1 : 0);

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

            logging.WriteEntry("The tblCustoms is Synced");

            #region Sync tblDeclarationLoan
            var declarationLoans = DataModelManager.GetUnSyncedItems("tblDeclarationLoan");

            if (declarationLoans.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (declarationLoans.Count() / 1000) + (declarationLoans.Count() % 1000 > 0 ? 1 : 0);

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

            logging.WriteEntry("The tblDeclarationLoan is Synced");

            #region Sync tblGate
            var gates = DataModelManager.GetUnSyncedItems("tblGate");

            if (gates.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (gates.Count() / 1000) + (gates.Count() % 1000 > 0 ? 1 : 0);

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

            logging.WriteEntry("The tblGate is Synced");

            #region Sync tblGoodsType
            var goodsTypes = DataModelManager.GetUnSyncedItems("tblGoodsType");

            if (goodsTypes.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (goodsTypes.Count() / 1000) + (goodsTypes.Count() % 1000 > 0 ? 1 : 0);

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

            logging.WriteEntry("The tblGoodsType is Synced");

            #region Sync tblGroup
            var groups = DataModelManager.GetUnSyncedItems("tblGroup");

            if (groups.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (groups.Count() / 1000) + (groups.Count() % 1000 > 0 ? 1 : 0);

                while (!finished)
                {
                    var n = (from item in groups
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblGroup", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblGroup).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblGroup", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (groups.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblGroup", groups))
                {
                    foreach (object obj in groups)
                    {
                        (obj as tblGroup).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblGroup", groups);
                }
            }
            #endregion

            logging.WriteEntry("The tblGroup is Synced");

            #region Sync tblPermission
            var permissions = DataModelManager.GetUnSyncedItems("tblPermission");

            if (permissions.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (permissions.Count() / 1000) + (permissions.Count() % 1000 > 0 ? 1 : 0);

                while (!finished)
                {
                    var n = (from item in permissions
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblPermission", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblPermission).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblPermission", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (permissions.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblPermission", permissions))
                {
                    foreach (object obj in permissions)
                    {
                        (obj as tblPermission).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblPermission", permissions);
                }
            }
            #endregion

            logging.WriteEntry("The tblPermission is Synced");

            #region Sync tblPermissionType
            var permissionTypes = DataModelManager.GetUnSyncedItems("tblPermissionType");

            if (permissionTypes.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (permissionTypes.Count() / 1000) + (permissionTypes.Count() % 1000 > 0 ? 1 : 0);

                while (!finished)
                {
                    var n = (from item in permissionTypes
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblPermissionType", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblPermissionType).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblPermissionType", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (permissionTypes.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblPermissionType", permissionTypes))
                {
                    foreach (object obj in permissionTypes)
                    {
                        (obj as tblPermissionType).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblPermissionType", permissionTypes);
                }
            }
            #endregion

            logging.WriteEntry("The tblPermissionType is Synced");

            #region Sync tblProfileConfig
            var profileConfigs = DataModelManager.GetUnSyncedItems("tblProfileConfig");

            if (profileConfigs.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (profileConfigs.Count() / 1000) + (profileConfigs.Count() % 1000 > 0 ? 1 : 0);

                while (!finished)
                {
                    var n = (from item in profileConfigs
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblProfileConfig", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblPermissionType).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblProfileConfig", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (profileConfigs.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblProfileConfig", profileConfigs))
                {
                    foreach (object obj in profileConfigs)
                    {
                        (obj as tblProfileConfig).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblProfileConfig", profileConfigs);
                }
            }
            #endregion

            logging.WriteEntry("The tblProfileConfig is Synced");

            #region Sync tblRoleInGroup
            var roleInGroups = DataModelManager.GetUnSyncedItems("tblRoleInGroup");

            if (roleInGroups.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (roleInGroups.Count() / 1000) + (roleInGroups.Count() % 1000 > 0 ? 1 : 0);

                while (!finished)
                {
                    var n = (from item in roleInGroups
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblRoleInGroup", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblRoleInGroup).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblRoleInGroup", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (roleInGroups.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblRoleInGroup", roleInGroups))
                {
                    foreach (object obj in roleInGroups)
                    {
                        (obj as tblRoleInGroup).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblRoleInGroup", roleInGroups);
                }
            }
            #endregion

            logging.WriteEntry("The tblRoleInGroup is Synced");

            #region Sync tblType
            var types = DataModelManager.GetUnSyncedItems("tblType");

            if (types.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (types.Count() / 1000) + (types.Count() % 1000 > 0 ? 1 : 0);

                while (!finished)
                {
                    var n = (from item in types
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblType", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblType).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblType", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (types.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblType", types))
                {
                    foreach (object obj in types)
                    {
                        (obj as tblType).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblType", types);
                }
            }
            #endregion

            logging.WriteEntry("The tblType is Synced");

            #region Sync tblUser
            var users = DataModelManager.GetUnSyncedItems("tblUser");

            if (users.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (users.Count() / 1000) + (users.Count() % 1000 > 0 ? 1 : 0);

                while (!finished)
                {
                    var n = (from item in users
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblUser", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblUser).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblUser", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (users.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblUser", users))
                {
                    foreach (object obj in users)
                    {
                        (obj as tblUser).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblUser", users);
                }
            }
            #endregion

            logging.WriteEntry("The tblUser is Synced");

            #region Sync tblUserGroupPermission
            var groupPermissions = DataModelManager.GetUnSyncedItems("tblUserGroupPermission");

            if (groupPermissions.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (groupPermissions.Count() / 1000) + (groupPermissions.Count() % 1000 > 0 ? 1 : 0);

                while (!finished)
                {
                    var n = (from item in groupPermissions
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblUserGroupPermission", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblUserGroupPermission).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblUserGroupPermission", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (groupPermissions.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblUserGroupPermission", groupPermissions))
                {
                    foreach (object obj in groupPermissions)
                    {
                        (obj as tblUserGroupPermission).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblUserGroupPermission", groupPermissions);
                }
            }
            #endregion

            logging.WriteEntry("The tblUserGroupPermission is Synced");

            #region Sync tblUserInGroup
            var userInGroups = DataModelManager.GetUnSyncedItems("tblUserInGroup");

            if (userInGroups.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (userInGroups.Count() / 1000) + (userInGroups.Count() % 1000 > 0 ? 1 : 0);

                while (!finished)
                {
                    var n = (from item in userInGroups
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblUserInGroup", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblUserInGroup).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblUserInGroup", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (userInGroups.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblUserInGroup", userInGroups))
                {
                    foreach (object obj in userInGroups)
                    {
                        (obj as tblUserInGroup).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblUserInGroup", userInGroups);
                }
            }
            #endregion

            logging.WriteEntry("The tblRoleInGroup is Synced");

            #region Sync tblVehicleCheck
            var vehicleChecks = DataModelManager.GetUnSyncedItems("tblVehicleCheck");

            if (vehicleChecks.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (vehicleChecks.Count() / 1000) + (vehicleChecks.Count() % 1000 > 0 ? 1 : 0);

                while (!finished)
                {
                    var n = (from item in vehicleChecks
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblVehicleCheck", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblVehicleCheck).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblVehicleCheck", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (vehicleChecks.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblVehicleCheck", vehicleChecks))
                {
                    foreach (object obj in vehicleChecks)
                    {
                        (obj as tblVehicleCheck).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblVehicleCheck", vehicleChecks);
                }
            }
            #endregion

            logging.WriteEntry("The tblVehicleCheck is Synced");

            #region Sync tblVehicleFeeSetting
            var vehicleFeeSettings = DataModelManager.GetUnSyncedItems("tblVehicleFeeSetting");

            if (vehicleFeeSettings.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (vehicleFeeSettings.Count() / 1000) + (vehicleFeeSettings.Count() % 1000 > 0 ? 1 : 0);

                while (!finished)
                {
                    var n = (from item in vehicleFeeSettings
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblVehicleFeeSetting", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblVehicleFeeSetting).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblVehicleFeeSetting", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (vehicleFeeSettings.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblVehicleFeeSetting", vehicleFeeSettings))
                {
                    foreach (object obj in vehicleFeeSettings)
                    {
                        (obj as tblVehicleFeeSetting).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblVehicleFeeSetting", vehicleFeeSettings);
                }
            }
            #endregion

            logging.WriteEntry("The tblVehicleFeeSetting is Synced");

            #region Sync tblVehicleType
            var vehicleTypes = DataModelManager.GetUnSyncedItems("tblVehicleType");

            if (vehicleTypes.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (vehicleTypes.Count() / 1000) + (vehicleTypes.Count() % 1000 > 0 ? 1 : 0);

                while (!finished)
                {
                    var n = (from item in vehicleTypes
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tblVehicleType", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tblVehicleType).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tblVehicleType", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (vehicleTypes.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tblVehicleType", vehicleTypes))
                {
                    foreach (object obj in vehicleTypes)
                    {
                        (obj as tblVehicleType).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tblVehicleType", vehicleTypes);
                }
            }
            #endregion

            logging.WriteEntry("The tblVehicleType is Synced");

            #region Sync tlbRole
            var roles = DataModelManager.GetUnSyncedItems("tlbRole");

            if (roles.Count() > 1000)
            {
                int ncount = 0;
                bool finished = false;

                int max = (roles.Count() / 1000) + (roles.Count() % 1000 > 0 ? 1 : 0);

                while (!finished)
                {
                    var n = (from item in roles
                             select item).Skip(ncount * 1000).Take(1000).ToArray();

                    if (ProxyGenericServer.Sync(token, "tlbRole", n))
                    {
                        foreach (object obj in n)
                        {
                            (obj as tlbRole).IsSynced = true;
                        }

                        var updated = DataModelManager.UpdateBatchItems("tlbRole", n);
                        ncount++;
                    }
                    if (ncount > max)
                        finished = true;
                }

            }
            else if (roles.Count() > 0)
            {
                if (ProxyGenericServer.Sync(token, "tlbRole", roles))
                {
                    foreach (object obj in roles)
                    {
                        (obj as tlbRole).IsSynced = true;
                    }

                    var updated = DataModelManager.UpdateBatchItems("tlbRole", roles);
                }
            }
            #endregion

            logging.WriteEntry("The tlbRole is Synced");

            logging.WriteSuccessAudit("Sync all data is completed!");

            isSyncing = false;
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

            logging.WriteEntry("Starting timer");
            timer.Start();
            logging.WriteEntry("Timer is started");

        }

        protected override void OnStop()
        {
            logging.WriteEntry("OnStop Service");
        }
    }
}
