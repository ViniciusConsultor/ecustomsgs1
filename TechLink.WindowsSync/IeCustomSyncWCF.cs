using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TechLink.WindowsSync
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IeCustomSyncWCF" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IeCustomSyncWCF
    {
        [OperationContract(IsInitiating = true, IsOneWay = false)]
        string VerifyBranch(string branchId, string brachSerial);

        [OperationContract(IsInitiating = false, IsOneWay = false)]
        bool DeleteItem(string token, string tableName, string[] itemParams);

        [OperationContract(IsInitiating = false, IsOneWay = false)]
        bool InsertItems(string token, string tableName, object[] items);

        [OperationContract(IsTerminating = true, IsOneWay = false)]
        void CloseSession(string token, string branchId, string brachSerial);
    }
}
