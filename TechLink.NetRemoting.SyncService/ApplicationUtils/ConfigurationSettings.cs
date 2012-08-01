using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml;

namespace ApplicationUtils.Utils
{
	/// <summary>
	/// Summary description for ConfigurationSettings.
	/// </summary>
	public class ConfigurationSettings
	{
		private const string APPSETTINGS_SECTION_NAME = "appSettings";
		private const string CONFIG_SECTIONS_PATH = "/configuration/configSections";
		private const string CONFIG_SECTIONS_GROUP_PATH = "sectionGroup";
		private const string CONFIG_SECTION_PATH = "section";
		private static Assembly _callingAssembly = null;

		private ConfigurationSettings()
		{
		}

		public static object GetConfig(string sectionName, string configFileName)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(configFileName);

			IConfigurationSectionHandler handler = GetHandler(sectionName, xmlDoc);
			object config = null;

			if (sectionName == APPSETTINGS_SECTION_NAME)
			{
				config = GetAppSettingsFileHandler(sectionName, handler, xmlDoc);
			}
			else
			{
				XmlNode node = xmlDoc.SelectSingleNode("//" + sectionName);
				config = handler.Create(null, null, node);
			}

			return config;
		}

		public static object GetConfig(string sectionName)
		{
			Assembly asm = Assembly.GetCallingAssembly();
			if (_callingAssembly != null && _callingAssembly != asm)
			{
				asm = _callingAssembly;
			}

			string filePath = Path.GetDirectoryName(asm.CodeBase);
			string asmName = Path.GetFileName(asm.Location);

			string configFileName = Path.Combine(filePath, asmName + ".config");

			return GetConfig(sectionName, configFileName);
		}

		public static NameValueCollection GetAppSettings(string configFileName)
		{
			NameValueCollection appSettings = (NameValueCollection) GetConfig(APPSETTINGS_SECTION_NAME, configFileName);
			if (appSettings == null)
			{
				appSettings = new NameValueCollection();
			}

			return appSettings;
		}

		public static NameValueCollection AppSettings
		{
			get
			{
				//Store the calling assembly because we are about to call ourselves
				_callingAssembly = Assembly.GetCallingAssembly();

				NameValueCollection appSettings = (NameValueCollection) GetConfig(APPSETTINGS_SECTION_NAME);
				if (appSettings == null)
				{
					appSettings = new NameValueCollection();
				}

				return appSettings;
			}
		}

		protected static IConfigurationSectionHandler GetHandler(string sectionName, XmlDocument xmlDoc)
		{
			IConfigurationSectionHandler handler = null;

			if (sectionName == APPSETTINGS_SECTION_NAME)
			{
				handler = new NameValueSectionHandler();
				return handler;
			}

			string[] sections = sectionName.Split('/');
			string sectionGroup = string.Empty;
			string section = string.Empty;
			string xPath = string.Empty;

			//see if we have a section group that we have to go through
			if (sections.Length > 1)
			{
				sectionGroup = sections[0];
				section = sections[1];

				xPath = string.Format(CONFIG_SECTIONS_PATH + "/" +
				                      CONFIG_SECTIONS_GROUP_PATH + "[@name='" + sectionGroup + "']/" +
				                      CONFIG_SECTION_PATH + "[@name='" + section + "']");
			}
			else
			{
				section = sections[0];

				xPath = string.Format(CONFIG_SECTIONS_PATH + "/" +
				                      CONFIG_SECTION_PATH + "[@name='" + section + "']");
			}

			XmlNode node = xmlDoc.SelectSingleNode(xPath);

			string typeName = node.Attributes["type", ""].Value;

			if (typeName == null || typeName.Length == 0)
				return handler;

			Type handlerType = Type.GetType(typeName);
			handler = (IConfigurationSectionHandler) Activator.CreateInstance(handlerType);

			return handler;
		}

		protected static object GetAppSettingsFileHandler(string sectionName, IConfigurationSectionHandler parentHandler, XmlDocument xmlDoc)
		{
			object handler = null;
			XmlNode node = xmlDoc.SelectSingleNode("//" + sectionName);
			if (node == null)
			{
				return null;
			}
			XmlAttribute att = (XmlAttribute) node.Attributes.RemoveNamedItem("file");

			if (att == null || att.Value == null || att.Value.Length == 0)
			{
				return parentHandler.Create(null, null, node);
			}
			else
			{
				string fileName = att.Value;
				string dir = Path.GetDirectoryName(fileName);
				string fullName = Path.Combine(dir, fileName);
				XmlDocument xmlDoc2 = new XmlDocument();
				xmlDoc2.Load(fullName);

				object parent = parentHandler.Create(null, null, node);
				IConfigurationSectionHandler h = new NameValueSectionHandler();
				handler = h.Create(parent, null, xmlDoc2.DocumentElement);
			}

			return handler;
		}
	}
}