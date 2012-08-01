using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ApplicationUtils.Utils.XMLProcessing
{
	public static class XmlSerializationUtils<T> where T : class, new()
	{
		public static bool Serialize(T obj, string path)
		{
			XmlSerializer serializer = new XmlSerializer(obj.GetType());
			string tmpPath = Path.GetTempFileName();
			using (TextWriter xmlTextWriter = File.CreateText(tmpPath))
			{
				serializer.Serialize(xmlTextWriter, obj);
			}
			if(!Directory.Exists(Path.GetDirectoryName(path)))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(path));
			}
			File.Copy(tmpPath, path, true);
			File.Delete(tmpPath);
			return true;
		}

		public static T DeserializeObj(string path)
		{
			if (!File.Exists(path))
			{
				return new T();
			}

			T inst = null;

			XmlSerializer serializer = new XmlSerializer(typeof (T));

			using (TextReader xmlTextWriter = File.OpenText(path))
			{
				inst = (T) serializer.Deserialize(xmlTextWriter);
			}

			return inst;
		}

    public static T DeserializeObjFromXmlString(string xmlString)
    {
      T inst = null;
      XmlSerializer serializer = new XmlSerializer(typeof(T));

      using(MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xmlString)))
      {
        inst = (T)serializer.Deserialize(memoryStream);
      }
      return inst;
    }
    
    private static byte[] StringToUTF8ByteArray(string xmlString)
    {
      UTF8Encoding encoding = new UTF8Encoding();
      Byte[] byteArray = encoding.GetBytes(xmlString);
      return byteArray;
    }
	}
}