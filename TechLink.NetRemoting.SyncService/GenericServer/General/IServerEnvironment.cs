namespace GenericRemoteServer.General
{
	public interface IServerEnvironment
	{
		string BasePath { get; }
		string GetPath(ServerFolders serverFolder);
		string GetFilePath(string fileName);
	}
}