
namespace ConnectionController
{
    public class ServerInterfacesHelper
    {
        private readonly ServerInterfacesDispatcher serverInterfacesDispatcher = null;

        public ServerInterfacesHelper(ServerInterfacesDispatcher serverInterfacesDispatcher)
        {
            this.serverInterfacesDispatcher = serverInterfacesDispatcher;
        }

        public ServerInterfacesDispatcher ServerInterfacesDispatcher
        {
            get
            {
                return serverInterfacesDispatcher;
            }
        }
    }
}
