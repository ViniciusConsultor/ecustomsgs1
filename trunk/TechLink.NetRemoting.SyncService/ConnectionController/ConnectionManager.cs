using System;
using System.Collections.Generic;
using System.Linq;
using ExceptionHandler;
using ExceptionHandler.Logging;

namespace ConnectionController
{
    public class ConnectionManager
    {
        public static ServerInterfacesHelper ConnectToServer(string serverURL, string serverPORT, string applicationHandle, string clientPort)
        {
            ConnectionBuilder connectionBuilder = null;
            try
            {
                connectionBuilder = new ConnectionBuilder(serverURL, serverPORT, applicationHandle, clientPort);
                connectionBuilder.Connect();
                TestServerConnection(connectionBuilder);
            }
            catch (Exception e)
            {
                //ProcessException.Handle(e);
                //Console.Write(e);
                new WindowsServiceLog().WriteEntry(e, "ServerInterfacesHelper::ConnectToServer");
                return null;
            }
            ServerInterfacesDispatcher serverInterfacesDispatcher = new ServerInterfacesDispatcher(connectionBuilder.RemoteServer, connectionBuilder.ProxyRemoteServer);
            return new ServerInterfacesHelper(serverInterfacesDispatcher);
        }

        private static void TestServerConnection(ConnectionBuilder connectionBuilder)
        {
            //any server opecation call will do
            //bool securityEnabled = connectionBuilder.RemoteServer.SecurityEnabled;
            //connectionBuilder.RemoteServer.SyncUserInfo();
        }

    }
}
