using System;
using System.Collections;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using ApplicationUtils.Utils;
using ClientServerExchange.Interfaces;

namespace ConnectionController
{
    public class ConnectionBuilder
    {
        private IGenericServer genericServer = null;
        private IGenericServer myProxyGenericServer = null;

        private int timeOut = 30;
        private readonly string applicationHandler = "";
        private static string ipAddress = "";

        private readonly string server = "";
        private readonly string clientPort = "";
        private readonly string serverPort = "";

        private TcpChannel chan = null;

        public ConnectionBuilder(string server, string serverPort, string applicationHandler, string clientPort)
        {
            this.applicationHandler = applicationHandler;
            this.server = server;
            this.serverPort = serverPort;
            this.clientPort = clientPort;
        }

        public void Connect()
        {
            RegisterChannels();
            RetrieveRemoteObject();
        }
        public void Disconnect()
        {
            if (chan != null)
            {
                ChannelServices.UnregisterChannel(chan);
            }
        }

        private void RegisterChannels()
        {
            BinaryServerFormatterSinkProvider binaryServerProv = new BinaryServerFormatterSinkProvider();
            binaryServerProv.TypeFilterLevel = TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider binaryClientProv = new BinaryClientFormatterSinkProvider();
            IDictionary props = new Hashtable();
            props["port"] = clientPort;
            props["name"] = server + ":" + serverPort;
            IPAddress[] serverIpAddresses = Dns.GetHostAddresses(server);
            IPAddress serverSelectedIP = null;
            foreach (IPAddress address in serverIpAddresses)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    serverSelectedIP = address;
                }
            }
            if (serverSelectedIP != null)
            {
                IPAddress address = NetHelper.GetIpAddressFromTheSameNetworkAs(serverSelectedIP);
                if (address != null)
                {
                    props["machineName"] = address.ToString();
                }
            }
            else
            {
                throw new Exception("Could not select an IP address for the server.");
            }
            chan = new TcpChannel(props, binaryClientProv, binaryServerProv);
            ChannelServices.RegisterChannel(chan);
        }


        private static string IPAddress
        {
            get
            {
                if (ipAddress == "")
                {
                    ipAddress = NetHelper.GetIpAddress();
                }
                return ipAddress;
            }
        }


        public IGenericServer ProxyRemoteServer
        {
            get
            {
                return this.myProxyGenericServer;
            }
        }

        public IGenericServer RemoteServer
        {
            get
            {
                return this.genericServer;
            }
        }


        private void RetrieveRemoteObject()
        {
            Trace.TraceInformation("ConnectionBuilder.RetrieveRemoteObject");
            genericServer = Activator.GetObject(typeof(IGenericServer), "tcp://" + server + ":" + serverPort + "/GenericServer") as IGenericServer;
            this.myProxyGenericServer = new ProxyGenericServer(genericServer);
        }

        #region AbstractBuilder Members

        public int TimeOut
        {
            get
            {
                return this.timeOut;
            }
            set
            {
                this.timeOut = value;
            }
        }

        #endregion
    }
}
