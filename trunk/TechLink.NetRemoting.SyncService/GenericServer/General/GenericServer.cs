using System;
using System.Collections.Generic;
using ApplicationUtils.ErrorReporting;
using ClientServerExchange.Interfaces;
using ECustoms.BOL;
using ECustoms.DAL;
using System.Linq;
using TechLink.SyncDataModel;

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
        private List<string> TokenList = new List<string>();

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

        public string StartSync(string branchId, string serial)
        {
            if (BranchFactory.IsExistingBranch(branchId, serial))
            {
                string token = Guid.NewGuid().ToString();
                lock (TokenList)
                {
                    TokenList.Add(token);
                }
                return token;
            }
            else
            {
                return string.Empty;
            }
        }

        public bool Sync(string token, string tableName, object[] itemsSync)
        {
            lock (TokenList)
            {
                if (TokenList.Contains(token) && DataModelConst.Tables.Contains(tableName))
                {
                    return DataModelManager.InsertItems(tableName, itemsSync);
                }
                else
                {
                    return false;
                }
            }

        }

        public void StopSync(string token)
        {
            lock (TokenList)
            {
                if (TokenList.Contains(token))
                {
                    TokenList.Remove(token);
                }
            }
        }

        #endregion
    }
}
