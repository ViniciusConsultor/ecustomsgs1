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
