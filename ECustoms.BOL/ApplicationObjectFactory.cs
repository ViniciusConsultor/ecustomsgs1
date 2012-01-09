using System;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Configuration;

namespace ECustoms.BOL
{
  public class ApplicationObjectFactory
  {
    public const string TOTAL_TICKET_IN_DATE = "TOTAL_TICKET_IN_DATE";

    public static tblApplicationObject getByName(String objectName)
    {
      var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
      tblApplicationObject obj= db.tblApplicationObjects.Where(g => g.ApplicationObjectName == objectName).FirstOrDefault();
      return obj;
    }

    public static void Insert(tblApplicationObject appObject)
    {
      var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
      db.AddTotblApplicationObjects(appObject);
      db.SaveChanges();
    }

    public static int Update(tblApplicationObject appObject)
    {
      var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
      var updateAppObject = new tblApplicationObject();
      updateAppObject = db.tblApplicationObjects.Where(g => g.ApplicationObjectID == appObject.ApplicationObjectID).FirstOrDefault();
      updateAppObject.ApplicationObjectValueFloat = appObject.ApplicationObjectValueFloat;
      updateAppObject.ApplicationObjectValueLong = appObject.ApplicationObjectValueLong;
      updateAppObject.ApplicationObjectValueString = appObject.ApplicationObjectValueString;
      updateAppObject.ApplicationObjectValueDatetime = appObject.ApplicationObjectValueDatetime;
      return db.SaveChanges();
    }
  }
}
