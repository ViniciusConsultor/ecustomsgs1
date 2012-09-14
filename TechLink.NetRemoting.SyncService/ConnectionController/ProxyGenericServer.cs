using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClientServerExchange.Args;
using ClientServerExchange.Delegates;
using ClientServerExchange.Interfaces;
using ECustoms.DAL;
using ECustoms.Utilities;
using EnumConstant.Enums;
using ExceptionHandler;

namespace ConnectionController
{
    public class ProxyGenericServer : IGenericServer
    {

        private readonly IGenericServer genericServer = null;
        public ProxyGenericServer(IGenericServer genericServer)
        {
            this.genericServer = genericServer;
        }

        #region Implementation of IGenericServer

        public string StartSync(string branchId, string serial)
        {
            return genericServer.StartSync(branchId, serial);
        }

        public bool Sync(string token, string tableName, object[] itemsSync)
        {
            return genericServer.Sync(token, tableName, itemsSync);
        }

        public void StopSync(string token)
        {
            genericServer.StopSync(token);
        }

        #endregion
    }
}
