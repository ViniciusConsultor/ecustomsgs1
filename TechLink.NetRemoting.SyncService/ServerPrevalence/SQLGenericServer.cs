using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECustoms.DAL;
using GenericRemoteServer.General;

namespace ServerPrevalence
{
    public class SQLGenericServer : GenericServer
    {
        public SQLGenericServer(IDataController database)
            : base(database)
        {
        }

        #region Overrides of GenericServer

        public override void Close()
        {
            //DataController.Disconnect();
        }

        public override void InitSystemOptions()
        {
            //List<MedicineItem> medicineItems = DataController.GetAllMedicineItems();
        }

        #endregion
    }
}
