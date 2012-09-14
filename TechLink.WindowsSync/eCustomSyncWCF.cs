using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ECustoms.BOL;
using TechLink.SyncDataModel;

namespace TechLink.WindowsSync
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "eCustomSyncWCF" in both code and config file together.
    public class eCustomSyncWCF : IeCustomSyncWCF
    {
        #region Implementation of IeCustomSyncWCF

        public string VerifyBranch(string branchId, string brachSerial)
        {
            if (BranchFactory.IsExistingBranch(branchId, brachSerial))
            {
                string token = Guid.NewGuid().ToString();
                lock (SyncSessions.TokenList)
                {
                    SyncSessions.TokenList.Add(token);    
                }
                return token;
            }

            return string.Empty;
        }

        public bool DeleteItem(string token, string tableName, string[] itemParams)
        {
            lock (SyncSessions.TokenList)
            {
                if (SyncSessions.TokenList.Contains(token))
                {
                    return DataModelManager.DeleteItem(tableName, itemParams);
                }
                else
                {
                    return false;
                }
            }

        }

        public bool InsertItems(string token, string tableName, object[] items)
        {
            lock (SyncSessions.TokenList)
            {
                if (SyncSessions.TokenList.Contains(token))
                {
                    return DataModelManager.InsertItems(tableName, items);
                }
                else
                {
                    return false;
                }
            }
        }

        public void CloseSession(string token, string branchId, string brachSerial)
        {
            lock (SyncSessions.TokenList)
            {
                if (SyncSessions.TokenList.Contains(token))
                {
                    SyncSessions.TokenList.Remove(token);
                }
            }
        }

        #endregion
    }
}
