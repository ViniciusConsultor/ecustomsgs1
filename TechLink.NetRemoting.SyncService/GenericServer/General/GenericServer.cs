using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Threading;
using ApplicationUtils.ErrorReporting;
using ApplicationUtils.Utils;
using ClientServerExchange.Args;
using ClientServerExchange.Delegates;
using ClientServerExchange.Interfaces;
using ECustoms.BOL;
using ECustoms.DAL;
using EnumConstant.Enums;
using ExceptionHandler;
using System.Linq;
using System.Linq.Expressions;

namespace GenericRemoteServer.General
{
    public abstract class GenericServer : MarshalByRefObject, IGenericServer
    {
        public abstract void Close();
        public abstract void InitSystemOptions();

        private IDataController _dataController = null;
        private bool _securityEnabled = false;
        private System.Timers.Timer GCCollectTimer = null;
        private List<ClientInfo> SyncingClients = new List<ClientInfo>();

        public GenericServer(IDataController dataController)
        {
            _dataController = dataController;
            ServerErrorReportingEngine.Instance.NewErrorReport += Instance_NewErrorReport;
            GCCollectTimer = new System.Timers.Timer(1000);
            GCCollectTimer.Elapsed += new System.Timers.ElapsedEventHandler(GCCollectTimer_Elapsed);
        }

        void GCCollectTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            GC.Collect();
            ((System.Timers.Timer)sender).Stop();
        }

        private void Instance_NewErrorReport(object sender, NewErrorReportEventArgs<ServerErrorReport> e)
        {
            //foreach (UserSessionData session in serverDynamicData.ClientSessionsLogic.Sessions)
            //{
            //  try
            //  {
            //    e.ErrorReport.AditionalInfo.Add(new ErrorReportBase.InfoItem("Session", session.ToString()));
            //  }
            //  catch (Exception e1)
            //  {
            //    Debug.WriteLine(e1);
            //  }

            //  e.ErrorReport.PromovaProfilingData = database.PromovaProfilingData.GetXmlSerializablePromovaProfilingData();
            //}
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }



        #region Implementation of IGenericServer

        public bool StartSync(ClientInfo clientInfo)
        {
            var result = BranchFactory.IsExistingBranch(clientInfo.Name, clientInfo.Serial);
            if (result)
            {
                if (SyncingClients.FirstOrDefault(item => item.Serial == clientInfo.Serial && item.Name == clientInfo.Name) == null)
                {
                    SyncingClients.Add(clientInfo);
                }
            }

            return result;
        }

        public void StopSync(ClientInfo clientInfo)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblUser(List<tblUser> users)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblVehicle(List<tblVehicle> vehicles)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblDeclaration(List<tblDeclaration> ceclarations)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tlbRole(List<tlbRole> roles)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblRoleInGroup(List<tblRoleInGroup> roleInGroups)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblApplicationObject(List<tblApplicationObject> applicationObjects)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblCheck(List<tblCheck> checks)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblCustoms(List<tblCustom> customses)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblDeclarationVehicle(List<tblDeclarationVehicle> declarationVehicles)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblGate(List<tblGate> gates)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblGoodsType(List<tblGoodsType> goodsTypes)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblGroup(List<tblGroup> groups)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblPermission(List<tblPermission> permissions)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblSettings(List<tblSetting> settings)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblUserGroupPermission(List<tblUserGroupPermission> groupPermissions)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblVehicleCheck(List<tblVehicleCheck> vehicleChecks)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblVehicleFeeSetting(List<tblVehicleFeeSetting> vehicleFeeSettings)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblVehicleType(List<tblVehicleType> vehicleTypes)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblUserInGroup(List<tblUserInGroup> userInGroups)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
