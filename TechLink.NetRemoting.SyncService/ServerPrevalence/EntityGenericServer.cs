using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECustoms.DAL;
using GenericRemoteServer.General;

namespace ServerPrevalence
{
    public class EntityGenericServer : GenericServer
    {
        public EntityGenericServer(IDataController dataController) : base(dataController)
        {

        }

        #region Overrides of GenericServer

        public override void Close()
        {
            
        }

        public override void InitSystemOptions()
        {
            
        }

        #endregion
    }
}
