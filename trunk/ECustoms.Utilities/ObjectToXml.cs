using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace ECustoms.Utilities
{
  public class ObjectToXml
  {
    public static void ConvertObjectToXml(object obj, string path_to_xml)
    {
      //serialize and persist it to it's file
      FileStream fs = null;
      try
      {
        XmlSerializer ser = new XmlSerializer(obj.GetType());
        new FileInfo(path_to_xml).Directory.Create();
        fs = File.Open(
                path_to_xml,
                FileMode.Create,
                FileAccess.Write,
                FileShare.ReadWrite);
        ser.Serialize(fs, obj);
      }
      catch (Exception ex)
      {
        throw new Exception(
                "Could Not Serialize object to " + path_to_xml,
                ex);
      }
      finally
      {
        fs.Close();
      }
    }

    public static PrintTicketSetting GetTicketSetting(string filename)
    {
      // Create an instance of the XmlSerializer specifying type and namespace.
      XmlSerializer serializer = new
      XmlSerializer(typeof(PrintTicketSetting));
      try
      {
        // A FileStream is needed to read the XML document.
        FileStream fs = new FileStream(filename, FileMode.Open);
        XmlReader reader = new XmlTextReader(fs);

        // Declare an object variable of the type to be deserialized.
        PrintTicketSetting i;

        // Use the Deserialize method to restore the object's state.
        i = (PrintTicketSetting)serializer.Deserialize(reader);
        fs.Close();
        return i;
      }
      catch (Exception e)
      {
        return null;
      }
    }

  }
}
