using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using ApplicationUtils.Utils;

namespace ApplicationUtils.ErrorReporting
{
	[Serializable]
	public class ErrorReportBase
	{
    private XmlSerializableException exception;

		private List<AssemblyInfo> loadedAssemblies = new List<AssemblyInfo>();

		private List<InfoItem> aditionalInfo = new List<InfoItem>();

		private string screenCaptureImageName = null;

		[XmlIgnore]
		private byte[] screenCaptureImageContent = null;

		public ErrorReportBase()
		{
			this.loadedAssemblies = new List<AssemblyInfo>(GetLoadedAssemblies());
		}

		protected virtual AssemblyInfo[] GetLoadedAssemblies()
		{
			AssemblyInfoExtractor assemblyInfoExtractor = new AssemblyInfoExtractor();
			SystemInfo.GetLoadedAssemblyInfo(assemblyInfoExtractor);
			return assemblyInfoExtractor.Assemblies.ToArray();
		}

		public virtual XmlSerializableException Exception
		{
			get
			{
				return exception;
			}
			set
			{
				exception = value;
			}
		}
    
		public string ScreenCaptureImageName
		{
			get
			{
				return screenCaptureImageName;
			}
			set
			{
				screenCaptureImageName = value;
			}
		}

		[XmlIgnore]
		public virtual byte[] ScreenCaptureImageContent
		{
			get
			{
				return screenCaptureImageContent;
			}
			set
			{
				screenCaptureImageContent = value;
			}
		}

		public virtual List<AssemblyInfo> LoadedAssemblies
		{
			get
			{
				return loadedAssemblies;
			}
			set
			{
				loadedAssemblies = value;
			}
		}

		public virtual List<InfoItem> AditionalInfo
		{
			get
			{
				return aditionalInfo;
			}
			set
			{
				aditionalInfo = value;
			}
		}


		public string GetAdditionalItemValue(string itemName)
		{
			InfoItem item = aditionalInfo.FindLast(delegate(InfoItem obj) { return obj.Key.ToLower().Trim() == itemName.ToLower().Trim(); });

			if (item != null)
			{
				return item.Value;
			}
			return string.Empty;
		}


		[XmlIgnore]
		public bool IsCrush
		{
			get
			{
				return GetAdditionalItemValue("IsCrush").ToLower() == "true";
			}
		}

		[XmlIgnore]
		public bool IsIssue
		{
			get
			{
				return GetAdditionalItemValue("IsIssue").ToLower() == "true";
			}
		}

    [XmlIgnore]
    public string IssueDescription
    {
      get
      {
        return GetAdditionalItemValue("Description");
      }
    }

		public void SetException(Exception exception)
		{
			XmlSerializableException serializableException = XmlSerializableException.GetXmlSerializableException(exception);
			XmlSerializableException lastException = serializableException;
			while (lastException.InnerExpcetion != null)
			{
				lastException = lastException.InnerExpcetion;
			}

			XmlSerializableException innerException = new XmlSerializableException();

			innerException.ErrorMesssage = "This exception is  manually added only to print the current stack trace of the client.";
			try
			{
				innerException.StackTrace = new StackTrace(true).ToString();
			}
			catch
			{
			}

			lastException.InnerExpcetion = innerException;
			this.exception = serializableException;
		}

		public void ToXml(string filePath)
		{
			XmlSerializer serializer = new XmlSerializer(this.GetType());
			using (TextWriter xmlTextWriter = File.CreateText(filePath))
			{

				using (MemoryStream memoryStream = new MemoryStream())
				{
					serializer.Serialize(memoryStream, this);
					memoryStream.Seek(0, SeekOrigin.Begin);
					using (StreamReader streamReader = new StreamReader(memoryStream, Encoding.UTF8))
					{
						xmlTextWriter.Write("<?xml version='1.0' encoding='utf-8'?>");
						xmlTextWriter.Write("\n");
						xmlTextWriter.Write("<?xml-stylesheet type='text/xsl' href='ReportDetails.xslt'?>");
						xmlTextWriter.Write("\n");
						streamReader.ReadLine();
						string xml = streamReader.ReadToEnd();
						xmlTextWriter.Write(xml);
					}
				}
			}
		}

		public void AddInfo(string key, string value)
		{
			this.aditionalInfo.Add(new InfoItem(key, value));
		}

		public override int GetHashCode()
		{
      if(this.IsIssue)
      {
        return this.IssueDescription.GetHashCode(); 
      }
			if (this.exception != null && this.exception.StackTrace!=null)
			{
				return this.exception.StackTrace.GetHashCode();
			}
			else if(this.exception != null && !string.IsNullOrEmpty(this.exception.ErrorMesssage))
			{
				return this.exception.ErrorMesssage.GetHashCode();
			}
			else
			{
				return base.GetHashCode();	
			}
		}

		public override string ToString()
		{
			return "Error report: " + GetHashCode();
		}

		#region inner classes

		[Serializable]
		public class AssemblyInfo
		{
			private string fullName = string.Empty;
			private string codeBase = string.Empty;
			private string imageVersion = string.Empty;


			public string FullName
			{
				get
				{
					return fullName;
				}
				set
				{
					fullName = value;
				}
			}

			public string CodeBase
			{
				get
				{
					return codeBase;
				}
				set
				{
					codeBase = value;
				}
			}

			public string ImageVersion
			{
				get
				{
					return imageVersion;
				}
				set
				{
					imageVersion = value;
				}
			}

			public static AssemblyInfo GetAssemblyInfo(Assembly assembly)
			{
				string fullName = string.Empty;

				try
				{
					fullName = assembly.FullName;
				}
				catch
				{
				}

				string codeBase = string.Empty;

				try
				{
					codeBase = assembly.CodeBase;
				}
				catch
				{
				}

				string imageVersion = string.Empty;

				try
				{
					imageVersion = assembly.ImageRuntimeVersion;
				}
				catch
				{
				}

				return new AssemblyInfo(fullName, codeBase, imageVersion);
			}


			public AssemblyInfo()
			{
			}

			public AssemblyInfo(string fullName, string codeBase, string imabeVersion)
			{
				this.fullName = fullName;
				this.codeBase = codeBase;
				this.imageVersion = imabeVersion;
			}
		}

		private class AssemblyInfoExtractor : IAssemblyInfoExtractor
		{
			#region IAssemblyInfoExtractor Members

			private readonly List<AssemblyInfo> assemblies = new List<AssemblyInfo>();

			public List<AssemblyInfo> Assemblies
			{
				get
				{
					return assemblies;
				}
			}

			public void ExtractInfo(Assembly assembly)
			{
				this.assemblies.Add(AssemblyInfo.GetAssemblyInfo(assembly));
			}

			#endregion
		}

		[Serializable]
		public class XmlSerializableException
		{
			private XmlSerializableException innerExpcetion = null;
			private List<InfoItem> additionalExceptionData = new List<InfoItem>();
			private string errorMesssage = string.Empty;
			private string stackTrace = string.Empty;

			public XmlSerializableException InnerExpcetion
			{
				get
				{
					return innerExpcetion;
				}
				set
				{
					innerExpcetion = value;
				}
			}


			public List<InfoItem> AdditionalExceptionData
			{
				get
				{
					return additionalExceptionData;
				}
				set
				{
					additionalExceptionData = value;
				}
			}

			public string ErrorMesssage
			{
				get
				{
					return errorMesssage;
				}
				set
				{
					errorMesssage = value;
				}
			}

			public string StackTrace
			{
				get
				{
					return stackTrace;
				}
				set
				{
					stackTrace = value;
				}
			}

			public static XmlSerializableException GetXmlSerializableException(Exception source)
			{
				XmlSerializableException exception = new XmlSerializableException();
				exception.ErrorMesssage = source.Message;

				//trnaslate german words to english, to have the same HashCode for both variants

				StringBuilder sb = new StringBuilder(source.StackTrace);
				sb.Replace("bei ", "at ");
				sb.Replace(":Zeile ", ":line ");
        exception.StackTrace = sb.ToString();
				
				foreach (DictionaryEntry dictionaryEntry in source.Data)
				{
					exception.AdditionalExceptionData.Add(new InfoItem(dictionaryEntry.Key.ToString(), dictionaryEntry.Value.ToString()));
				}
				if (source.InnerException != null)
				{
					exception.InnerExpcetion = GetXmlSerializableException(source.InnerException);
				}
				return exception;
			}
		}

		[Serializable]
		public class InfoItem
		{
			private string key = string.Empty;
			private string value = string.Empty;

			public InfoItem()
			{
			}

			[XmlAttribute]
			public string Key
			{
				get
				{
					return key;
				}
				set
				{
					key = value;
				}
			}

			[XmlText]
			public string Value
			{
				get
				{
					return value;
				}
				set
				{
					this.value = value;
				}
			}

			public InfoItem(string key, string value)
			{
				this.key = key;
				this.value = value;
			}
		}

		#endregion
	}
}