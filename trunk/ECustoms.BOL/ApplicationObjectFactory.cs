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
    public const string TOTAL_EXPORT_PARK_TICKET_IN_DATE = "TOTAL_EXPORT_PARK_TICKET_IN_DATE";
    public const string TOTAL_TEMP_RECEIVE_NUMBER_IN_YEAR = "TOTAL_TEMP_RECEIVE_NUMBER_IN_YEAR"; //so tiep nhan tam nhap tai xuat trong nam

    public static dbEcustomEntities _db =
        new dbEcustomEntities(
            Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
    private static ILog logger = LogManager.GetLogger("ECustoms.UserFactory");

    //cap nhat so thu tu cua ticket
    //day la tong so lan in ticket trong 1 ngay
    public static long updateTotalTicketPrint(string ticketType)
    {
        tblApplicationObject appObj = ApplicationObjectFactory.getByName(ticketType);
        DateTime currentDate = CommonFactory.GetCurrentDate();
        if (appObj == null)
        {
            appObj = new tblApplicationObject();
            appObj.ApplicationObjectName = ticketType;
            appObj.ApplicationObjectValueDatetime = CommonFactory.GetCurrentDate();
            appObj.ApplicationObjectValueLong = 1;
            ApplicationObjectFactory.Insert(appObj);
        }
        else
        {
            if (currentDate.DayOfYear != ((DateTime)appObj.ApplicationObjectValueDatetime).DayOfYear)
            {
                appObj.ApplicationObjectValueDatetime = currentDate;
                appObj.ApplicationObjectValueLong = 1;
            }
            else
            {
                appObj.ApplicationObjectValueLong = appObj.ApplicationObjectValueLong + 1;
            }
            ApplicationObjectFactory.Update(appObj);
        }
        long applicationObjectValueLong = appObj.ApplicationObjectValueLong.GetValueOrDefault();
        return applicationObjectValueLong;
    }


    //cap nhat so tiep nhap TNTX trong nam
    //day la tong so tiep nhap TNTX trong nam
    public static long updateTotalReceiveNumber()
    {
        tblApplicationObject appObj = ApplicationObjectFactory.getByName(TOTAL_TEMP_RECEIVE_NUMBER_IN_YEAR);
        DateTime currentDate = CommonFactory.GetCurrentDate();
        if (appObj == null)
        {
            appObj = new tblApplicationObject();
            appObj.ApplicationObjectName = TOTAL_TEMP_RECEIVE_NUMBER_IN_YEAR;
            appObj.ApplicationObjectValueDatetime = CommonFactory.GetCurrentDate();
            appObj.ApplicationObjectValueLong = 1;
            ApplicationObjectFactory.Insert(appObj);
        }
        else
        {
            if (currentDate.Year != ((DateTime)appObj.ApplicationObjectValueDatetime).Year)
            {
                appObj.ApplicationObjectValueDatetime = currentDate;
                appObj.ApplicationObjectValueLong = 1;
            }
            else
            {
                appObj.ApplicationObjectValueLong = appObj.ApplicationObjectValueLong + 1;
            }
            ApplicationObjectFactory.Update(appObj);
        }
        long applicationObjectValueLong = appObj.ApplicationObjectValueLong.GetValueOrDefault();
        return applicationObjectValueLong;
    }

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
