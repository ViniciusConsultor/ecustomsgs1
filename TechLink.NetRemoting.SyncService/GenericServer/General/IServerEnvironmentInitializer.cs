namespace GenericRemoteServer.General
{
	public interface IServerEnvironmentInitializer
	{
		void SetExactPath(ServerFolders serverFolder, string path);

		/// <summary>
		/// Gets the exact path which was setted for the specefied serverFolder in the config file.
		/// Use GetPath()
		/// </summary>
		/// <param name="serverFolder">The server folder.</param>
		/// <returns></returns>
		string GetExactPath(ServerFolders serverFolder);

		void Validate();

		void CreateInstance(string basePath, bool validate);

		void CreateInstance(string basePath);

		bool IsInitialized { get; }
	}
}