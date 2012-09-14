using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Configuration;
using log4net;

namespace ECustoms.BOL
{
  public class ApplicationObjectFactory:IDataModelCommand
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

      #region Implementation of IDataModelCommand

      public bool DeleteItem(string[] itemParams)
      {
          if (itemParams.Length < 2) return false;

          int id = itemParams[0].StringToInt();
          string branchId = itemParams[1];

          try
          {
              var deleteItem =
                  _db.tblApplicationObjects.FirstOrDefault(
                      item => item.ApplicationObjectID == id && item.BranchId == branchId);
              if(deleteItem!=null)
              {
                  _db.DeleteDirectly(deleteItem);
                  _db.SaveChanges();
              }

              return true;
          }
          catch (Exception exception)
          {
              logger.Error(exception.ToString());
              throw;
          }
          finally
          {
              _db.Connection.Close();
          }
      }

      public bool BatchInsert(object[] items)
      {
          try
          {
              _db.Connection.Open();
              foreach (object item in items)
              {
                  if (item is tblApplicationObject)
                  {
                      _db.AddObjectDirectly("tblApplicationObject", item);
                  }
              }

              _db.SaveChanges();
              return true;
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

          return false;
      }

      public object[] GetUnSyncedItems()
      {
          try
          {
              _db.Connection.Open();
              var lstUnSyncedItems = (from item in _db.tblApplicationObjects
                                      where item.IsSynced == false
                                      select item).ToArray();
              _db.Connection.Close();
              return lstUnSyncedItems;
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

      public bool UpdatePatch(object[] items)
      {
          throw new NotImplementedException();
      }

      #endregion
  }
}
