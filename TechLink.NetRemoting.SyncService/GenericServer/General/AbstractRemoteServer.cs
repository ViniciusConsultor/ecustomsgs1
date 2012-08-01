using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using ApplicationUtils.Logging;
using ApplicationUtils.Logging.Log4Net;
using ClientServerExchange.Interfaces;
using ExceptionHandler;

namespace GenericRemoteServer.General
{
    public enum ConsoleHandlerEventCode : uint
    {
        CTRL_C_EVENT = 0,
        CTRL_BREAK_EVENT = 1,
        CTRL_CLOSE_EVENT = 2,
        // 3 is reserved!
        // 4 is reserved!
        CTRL_LOGOFF_EVENT = 5,
        CTRL_SHUTDOWN_EVENT = 6
    }

    public delegate bool ConsoleEventHandlerDelegate(ConsoleHandlerEventCode eventCode);

    public abstract class AbstractRemoteServer : IRemoteServer
    {
        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventHandlerDelegate handlerProc, bool add);

        private static readonly log4net.ILog log = Log4NetManager.GetLog("General");
        protected ServerSettings settings = null;
        protected ObjRef remotingDatabaseReference = null;
        protected GenericServer genericServer;
        public ConsoleEventHandlerDelegate consoleHandler;

        public AbstractRemoteServer(ServerSettings settings)
        {
            this.settings = settings;
            consoleHandler = ConsoleEventHandler;
            SetConsoleCtrlHandler(consoleHandler, true);
        }

        private bool ConsoleEventHandler(ConsoleHandlerEventCode eventCode)
        {
            // Handle close event here...
            switch (eventCode)
            {
                case ConsoleHandlerEventCode.CTRL_CLOSE_EVENT:
                    OnClose();
                    break;
            }
            return false;
        }

        private void CreateCommunicationChannel()
        {
            BinaryServerFormatterSinkProvider binaryServerProv = new BinaryServerFormatterSinkProvider();
            binaryServerProv.TypeFilterLevel = TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider binaryClientProv = new BinaryClientFormatterSinkProvider();

            IDictionary props = new Hashtable();
            props["port"] = settings.Port;
            props["authenticationMode"] = "IdentifyCallers";


            //HttpChannel chan = new HttpChannel(props, binaryClientProv, binaryServerProv); 
            try
            {
                TcpChannel chan = new TcpChannel(props, binaryClientProv, binaryServerProv);
                ChannelServices.RegisterChannel(chan, false);
                if (chan == null)
                {
                    ProcessException.ErrorNotify.NotifyUser(
                            string.Format("Could not start server with port {0}", settings.Port));
                    Process.GetCurrentProcess().Kill();
                }
            }
            catch (SocketException e)
            {
                ProcessException.ErrorNotify.NotifyUser(
                        string.Format("Could not start server. Application port {1} is using by another application. Error message: {0}",
                                                    e.Message, settings.Port));
                Process.GetCurrentProcess().Kill();
            }
        }

        private void MarshallGenericServer()
        {
            try
            {
                remotingDatabaseReference = RemotingServices.Marshal(genericServer, "GenericServer", typeof(IGenericServer));
            }
            catch (Exception ex)
            {
                ProcessException.Handle(ex, "AbstractRemoteServer.MarshallGenericServer()");
            }
        }

        protected virtual void OnClose()
        {
            log.Info("AbstractRemoteServer.OnClose()");
            this.genericServer.Close();
        }

        protected abstract void CreateDatabase();
        public abstract void BackupDatabase(string destinationFolder);
        public abstract void UpgradeDatabase();

        #region Implementation of IRemoteServer

        public void Start()
        {
            CreateDatabase();
            log.Info(string.Format("AbstractRemoteServer.Start() at {0}", settings.CurrentDate.ToLongDateString()));
            log.Info("------------------------------");
            log.Info("AbstractRemoteServer.CreateCommunicationChannel()");
            CreateCommunicationChannel();
            log.Info("------------------------------");
            log.Info("AbstractRemoteServer.MarshallGenericServer()");
            MarshallGenericServer();

            ServerStaticData.GenericServer = genericServer;
            //GlobalCache.SystemCacheData = new CacheData();
            //GlobalCache.IsInitialized = GlobalCache.SystemCacheData.InitCache(genericServer.DataController);
            ServerStaticData.GenericServer.InitSystemOptions();
            //KCExtensionMethods.InitExtension(genericServer, ClientAppState.Fake);

        }

        public void Stop()
        {
            log.Info(string.Format("AbstractRemoteServer.Stop()at {0}", settings.CurrentDate.ToLongDateString()));

            //BackupDatabase("");

            if (remotingDatabaseReference != null)
            {
                OnClose();
                RemotingServices.Unmarshal(remotingDatabaseReference);
            }
            log.Info("AbstractRemoteServer.Stop() " +
                             "-> The server and the remoting service is stoped");
        }

        public void ReflectionCallOfMethodsOnServer(string methodName, object[] args, ILog log)
        {
            ProcessException.ErrorNotify.NotifyUser("Implement AbstractRemoteServer.ReflectionCallOfMethodsOnServer()");
        }

        public void BackupDataBase()
        {
            BackupDatabase(Path.Combine(this.settings.ApplicationsPath, "DataPackup.bak"));
        }

        #endregion
    }
}
