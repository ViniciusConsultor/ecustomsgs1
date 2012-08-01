#define USE_TRACING
using System.ComponentModel;

namespace GenericRemoteServer.General
{
    /// <summary>
    /// Summary description for ServerFolders.
    /// </summary>
    public enum ServerFolders
    {
        [Description("Server Assemblies/NotVital")]
        ServerAssemblies,
        [Description("ReportsCodeBehind/NotVital")]
        CodeBehind,
        [Description("Client Assemblies")]
        ClientAssemblies,
        [Description("Common Assemblies")]
        CommonAssemblies,
        [Description("Data Migration Files")]
        DataMigrationFiles,
        [Description("Logs/NotVital")]
        Logs,
        [Description("ErrorReports/NotVital")]
        ErrorReports,
        [Description("Utils/NotVital")]
        Utils,
        [Description("Installations/NotVital")]
        InstallationsBasePath,
				[Description("ConnectionString/NotVital")]
				ConnectionString,
        [Description("CustomDictionaries/NotVital")]
        CustomDictionaries,
        [Description("Installations/NotVital")]
        DefaulInstallationsBasePath,
        [Description("System/Server/Config/NotVital")]
        SystemConfigFiles,
        [Description("UserData/NotVital")]
        UserData
    }
}