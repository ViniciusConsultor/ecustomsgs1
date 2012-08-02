#define USE_TRACING
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using ApplicationUtils.Utils;
using ExceptionHandler;
using log4net;


namespace GenericRemoteServer.General
{
  /// <summary>
  /// Summary description for ServerStaticData.
  /// </summary>
  public class ServerStaticData
  {
    #region singleton & constructor

    private static ServerStaticData instance = null;
    private static ServerSettings settings = null;
    private static readonly ConfigFilesChangesWatcher changesWatcher = new ConfigFilesChangesWatcher();

    public static GenericServer GenericServer;

    public static event FileSystemEventHandler SettingsChanged;
    public static event EventHandler AfterSettingsRead;

    private static void OnSettingsChanged(FileSystemEventArgs ev)
    {
      if (SettingsChanged != null)
      {
        SettingsChanged(null, ev);
      }
    }

    private static void OnAfterSettingsRead()
    {
      if (AfterSettingsRead != null)
      {
        AfterSettingsRead(null, EventArgs.Empty);
      }
    }

    internal static ConfigFilesChangesWatcher ChangesWatcher
    {
      get
      {
        return changesWatcher;
      }
    }

    private ServerStaticData()
    {
      changesWatcher.Changed += delegate(object sender, FileSystemEventArgs e) { OnSettingsChanged(e); };
    }

    public static void Initialize()
    {
      if (instance == null)
      {
        instance = new ServerStaticData();
        instance.InitStaticData();
        instance.InitSystemOptions();
      }
    }

    public static ServerStaticData Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new ServerStaticData();
          instance.InitStaticData();
          instance.InitSystemOptions();
        }
        else if (changesWatcher.FilesChanged)
        {
          ServerStaticData backup = instance;

          Tracing.TraceCall();
          try
          {
            instance = new ServerStaticData();
            string retMessage = instance.InitStaticData();
            if (retMessage != string.Empty)
            {
              ProcessException.Handle(retMessage);
              ProcessException.Handle("The configuration files were changed, but there was an error while reading them.");
              ProcessException.ErrorNotify.NotifyUser(retMessage);
              instance = backup;
            }
          }
          catch (Exception e)
          {
            ProcessException.Handle(e);
            ProcessException.ErrorNotify.NotifyUser(e.ToString());
            ProcessException.Handle("The configuration files were changed, but there was an error while reading them.");
            instance = backup;
          }
          finally
          {
            changesWatcher.Reset();
            if (instance != backup)
            {
              OnAfterSettingsRead();
            }
          }
        }


        return instance;
      }
    }

    public static ServerSettings Settings
    {
      set
      {
        settings = value;
      }
      get
      {
        return settings;
      }
    }

    #endregion

    #region members
    private IDictionary<string, IDictionary<string, string>> resourceManager = new Dictionary<string, IDictionary<string, string>>();
    private string configFileErrors = string.Empty;

    #endregion

    #region properties

    public string ConfigFileErrors
    {
      get
      {
        return configFileErrors;
      }
    }

    public IDictionary<string, IDictionary<string, string>> ResourceManager
    {
      get
      {
        return resourceManager;
      }
    }

    #endregion

    #region private functions

    private void InitSystemOptions()
    {
      if(GenericServer!=null)
      {
        Trace.WriteLine("Begin init system options");
        GenericServer.InitSystemOptions();
        Trace.WriteLine("End init system options");
      }
    }

    private string InitStaticData()
    {
      string result = "";
      //ReadNrMaxConcurentUsers();

      if (resourceManager == null)
      {
        resourceManager = new Dictionary<string, IDictionary<string, string>>();
      }
      InitLanguagesMap();
      string ipAddress = NetHelper.GetIpAddress();
      return result;
    }

    private void ReadNrMaxConcurentUsers()
    {
      string fileFullPath = Path.Combine("", Settings.LicenseFile);
      if (File.Exists(fileFullPath))
      {
        using (FileStream fileStream = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read))
        {
          using (BinaryReader reader = new BinaryReader(fileStream))
          {
            byte[] inputBytes = new byte[fileStream.Length];
            inputBytes = reader.ReadBytes((int)fileStream.Length);
            reader.Close();
            fileStream.Close();
            byte[] resultBytes = DecryptBytes(inputBytes);
            using (MemoryStream memoryStream = new MemoryStream(resultBytes))
            {
              XmlDocument doc = new XmlDocument();
              doc.Load(memoryStream);

              XmlNode xmlNode = doc.SelectSingleNode("//License/NrMaxConcurrentUsers");
              if (xmlNode != null)
              {
                int maxConcurentUsers = -1;
                int.TryParse(xmlNode.InnerText.Trim(), out maxConcurentUsers);
                //ApplicationDefinitionData.GeneralSettings.NrMaxConcurrentUsers = maxConcurentUsers;
              }
            }
          }
        }
      }
      else
      {
        //ApplicationDefinitionData.GeneralSettings.NrMaxConcurrentUsers = 1000;
        ProcessException.Handle("License File is missing, NrMaxConcurentUsers is set to 1000 !!!");
      }
    }

    private byte[] DecryptBytes(byte[] bytes)
    {
      return bytes;
    }


    private void InitLanguagesMap()
    {
      resourceManager.Clear();
      ReadCultureXML("generalTranslations.xml");
      ReadCultureXML("customTranslations.xml");
    }

    public static IList<XmlNode> ReadCulture(string file)
    {
      List<XmlNode> culture = new List<XmlNode>();

      string fileFullPath = file;

      ProcessException.Handle("Loading translation file " + fileFullPath);

      if (file == null)
      {
        return null;
      }
      if (!File.Exists(fileFullPath))
      {
        ProcessException.Handle("Translation file " + fileFullPath + " not found.");
        return null;
      }
      if (fileFullPath != "")
      {
        XmlTextReader reader = null;
        try
        {
          reader = new XmlTextReader(fileFullPath);
          XmlDocument doc = new XmlDocument();
          doc.Load(reader);

          XmlNode root = doc.FirstChild;
          root = root.NextSibling;
          if (root.Name == "Translations")
          {
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
              XmlNode item = root.ChildNodes[i];
              if (item.Attributes == null ||
                  (item.Attributes != null && item.Attributes["Key"] == null))
              {
                continue;
              }

              culture.Add(item);
            }
          }
        }
        catch (Exception e)
        {
          ProcessException.Handle("Error loading translation file " + fileFullPath, e);
        }
        finally
        {
          if (reader != null)
          {
            reader.Close();
          }
        }
      }
      return culture;
    }

    private static void ReadCultureXML(string file)
    {
      string fileFullPath =
        Path.Combine("", file);

      ProcessException.Handle("Loading translation file " + fileFullPath);

      if (file == null)
      {
        return;
      }
      if (!File.Exists(fileFullPath))
      {
        ProcessException.Handle("Translation file " + fileFullPath + " not found.");
        return;
      }
      if (fileFullPath != "")
      {
        XmlTextReader reader = null;
        try
        {
          reader = new XmlTextReader(fileFullPath);
          XmlDocument doc = new XmlDocument();
          doc.Load(reader);

          XmlNode root = doc.FirstChild;
          root = root.NextSibling;
          if (root.Name == "Translations")
          {
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
              XmlNode item = root.ChildNodes[i];
              if (item.Attributes == null ||
                  (item.Attributes != null && item.Attributes["Key"] == null))
              {
                continue;
              }

              for (int j = 0; j < item.Attributes.Count; j++)
              {
                if (item.Attributes[j].Name != "Key")
                {
                  string cultureKey = item.Attributes[j].Name;
                  if (!instance.ResourceManager.ContainsKey(cultureKey))
                  {
                    instance.ResourceManager[cultureKey] = new Dictionary<string, string>();
                  }
                  IDictionary<string, string> languageResources = instance.ResourceManager[cultureKey];
                  languageResources[item.Attributes["Key"].Value] = item.Attributes[cultureKey].Value;
                }
              }
            }
          }
        }
        catch (Exception e)
        {
          ProcessException.Handle("Error loading translation file " + fileFullPath, e);
        }
        finally
        {
          if (reader != null)
          {
            reader.Close();
          }
        }
      }
    }

    #endregion


  }
}