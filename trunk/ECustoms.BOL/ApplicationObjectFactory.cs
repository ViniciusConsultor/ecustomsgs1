using System;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Configuration;
using log4net;

namespace ECustoms.BOL
{
  public class ApplicationObjectFactory
  {
    public const string TOTAL_TICKET_IN_DATE = "TOTAL_TICKET_IN_DATE";

    public static dbEcustomEntities _db =
        new dbEcustomEntities(
            Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
    private static ILog logger = LogManager.GetLogger("ECustoms.UserFactory");

    public static tblApplicationObject getByName(String objectName)
    {
        try
        {
            _db.Connection.Open();
            tblApplicationObject obj = _db.tblApplicationObjects.Where(g => g.ApplicationObjectName == objectName).FirstOrDefault();
            return obj;      
        }
        catch (Exception ex)
        {
            logger.Error(ex.ToString());
            throw;
        }
        finally
        {
            _db.Connection.Close();
        }           
    }

    public static void Insert(tblApplicationObject appObject)
    {
        try
        {
            _db.Connection.Open();
            _db.AddTotblApplicationObjects(appObject);
            _db.SaveChanges();
        }
        catch (Exception ex)
        {
            logger.Error(ex.ToString());
            throw;
        }
        finally
        {
            _db.Connection.Close();
        }
    }

    public static int Update(tblApplicationObject appObject)
    {
        try
        {
            _db.Connection.Open();
            var updateAppObject = new tblApplicationObject();
            updateAppObject = _db.tblApplicationObjects.Where(g => g.ApplicationObjectID == appObject.ApplicationObjectID).FirstOrDefault();
            updateAppObject.ApplicationObjectValueFloat = appObject.ApplicationObjectValueFloat;
            updateAppObject.ApplicationObjectValueLong = appObject.ApplicationObjectValueLong;
            updateAppObject.ApplicationObjectValueString = appObject.ApplicationObjectValueString;
            updateAppObject.ApplicationObjectValueDatetime = appObject.ApplicationObjectValueDatetime;
            return _db.SaveChanges();
        }
        catch (Exception ex)
        {
            logger.Error(ex.ToString());
            throw;
        }
        finally
        {
            _db.Connection.Close();
        }
    }
  }
}
