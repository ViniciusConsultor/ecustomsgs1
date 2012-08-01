using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Remoting;
using AbstractServerConsole;
using ApplicationUtils.Logging;
using ApplicationUtils.Logging.Log4Net;
using ApplicationUtils.Utils;
using ExceptionHandler;
using GenericRemoteServer.General;
using ILog=log4net.ILog;

namespace ServerConsole
{
    public class RemoteServerActivator : IServerConsole
    {
        private IRemoteServer server = null;
        private bool started = false;
        private static readonly ILog log = Log4NetManager.GetLog("General");

        public RemoteServerActivator()
        {
            ServerInitializer.DoServerInitializations();
        }

        public bool Started
        {
            get
            {
                return started;
            }
        }

        public void Stop()
        {
            log.Info("RemoteServerActivator.Stop() -> TechLink Sync Server is shutting down.");
            server.Stop();
        }

        public string ServerPort
        {
            get { return ServerSettings.Instance.Port; }
        }

        public void CleanUpBeforeClosed()
        {
            ProcessException.ErrorNotify.NotifyUser("Implement RemoteServerActivator.CleanUpBeforeClosed()");
        }

        public void Start(string[] args)
        {
            ServerStaticData.Settings = ServerSettings.Instance;
            ServerStaticData.Initialize();
            log.Info("ServerStaticData.Initialize()");
            if (ServerStaticData.Instance.ConfigFileErrors == string.Empty)
            {
                LogCollection logsCollection = new LogCollection();
                TraceListenerToLogAdapter adapter = new TraceListenerToLogAdapter(logsCollection, TraceLevel.Info);
                

                object[] param = new object[] { ServerSettings.Instance };
                string dllName = "ServerPrevalence";
                string filePath = ServerEnvironment.Instance.GetFilePath(dllName + ".dll");
                ObjectHandle objectHandle = null;
                try
                {
                    objectHandle = Activator.CreateInstanceFrom(filePath, dllName + ".RemoteServer", true,
                                                                BindingFlags.Instance | BindingFlags.Public, null, param, null, null,
                                                                AppDomain.CurrentDomain.Evidence);
                }
                catch (TargetInvocationException ex)
                {
                    ProcessException.Handle(ex.InnerException);
                    Tracing.TraceErr(ex.InnerException);
                    throw ex.InnerException;
                }
                catch (Exception e)
                {
                    ProcessException.Handle(e);
                    Tracing.TraceErr(e);
                    throw e;
                }
                log.Info("Server remoting object created.");

                server = (IRemoteServer)objectHandle.Unwrap();
                server.Start();

                this.started = true;
            }
            else
            {
                ProcessException.ErrorNotify.NotifyUser("Could not start server, there are errors in the config files. \n" +
                                                 ServerStaticData.Instance.ConfigFileErrors);
            }
        }
    }
}
