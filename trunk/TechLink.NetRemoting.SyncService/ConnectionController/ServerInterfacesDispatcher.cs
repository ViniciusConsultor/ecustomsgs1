using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationUtils.AssemblyProvider;
using ClientServerExchange.Interfaces;

namespace ConnectionController
{
	public class ServerInterfacesDispatcher
	{
		private readonly IGenericServer remoteServer = null;
		private readonly IGenericServer proxyRemoteServer = null;

		public ServerInterfacesDispatcher(IGenericServer remoteServer, IGenericServer proxyRemoteServer)
		{
			this.remoteServer = remoteServer;
			this.proxyRemoteServer = proxyRemoteServer;
		}
        
		public IGenericServer GenericServer
		{
			get { return proxyRemoteServer; }
		}
	}
}
