using ApplicationUtils.Logging;

namespace GenericRemoteServer.General
{
    public interface IRemoteServer
    {
        void Start();
        void Stop();
        void ReflectionCallOfMethodsOnServer(string methodName, object[] args, ILog log);
        void BackupDataBase();
    }
}
