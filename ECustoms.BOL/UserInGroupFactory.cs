using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;
using log4net;

namespace ECustoms.BOL
{
  public class UserInGroupFactory : IDataModelCommand
  {
    public static List<ViewUserGroup> GetByUserID(int userID)
    {
      var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
      List<ViewUserGroup> list= db.ViewUserGroups.Where(g => g.UserID == userID).ToList();
      db.Connection.Close();
      return list;
    }

    public static List<ViewUserGroup> GetByGroupID(int groupID)
    {
      var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
      var userGroups = db.ViewUserGroups.Where(g => g.GroupID == groupID).ToList();
      db.Connection.Close();
      return userGroups;
    }

    public static List<tblUserInGroup> GetTblUserInGroupByGroupID(int groupID)
    {
      var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
      var userGroups = db.tblUserInGroups.Where(g => g.GroupID == groupID).ToList();
      db.Connection.Close();
      return userGroups;
    }

    public static int Insert(tblUserInGroup userGroup)
    {
      var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
      db.AddTotblUserInGroups(userGroup);
      int re= db.SaveChanges();
      db.Connection.Close();
      return re;
    }

    public static int DeleteUserInGroupByUserID(int userID)
    {
      var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
      List<tblUserInGroup> listTblUserInGroup = db.tblUserInGroups.Where(g => g.UserID == userID).ToList();
      foreach (tblUserInGroup userInGroup in listTblUserInGroup)
      {
        db.DeleteObject(userInGroup);
      }
      int re = db.SaveChanges();
      db.Connection.Close();
      return re;
    }

    public static int DeleteUserInGroupByGroupID(Int32 groupID)
    {
      var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
      List<tblUserInGroup> listTblUserInGroup = db.tblUserInGroups.Where(g => g.GroupID == groupID).ToList();
      foreach (tblUserInGroup userInGroup in listTblUserInGroup)
      {
        db.DeleteObject(userInGroup);
      }
      int re = db.SaveChanges();
      db.Connection.Close();
      return re;
    }

    public static int DeleteUserInGroup(int groupID, int userID)
    {
      var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
      tblUserInGroup tblUserInGroup = db.tblUserInGroups.Where(g => g.GroupID == groupID && g.UserID == userID).FirstOrDefault();
      if(tblUserInGroup != null)
        db.DeleteObject(tblUserInGroup);
      int re = db.SaveChanges();
      db.Connection.Close();
      return re;
    }

      #region Implementation of IDataModelCommand

      public bool DeleteItem(string[] itemParams)
      {
          if (itemParams.Length < 3) return false;

          int id = itemParams[0].StringToInt();
          int groupid = itemParams[1].StringToInt();
          string branchId = itemParams[2];

          var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

          try
          {
              var deleteItem =
                  _db.tblUserInGroups.FirstOrDefault(
                      item => item.UserID == id && item.GroupID == groupid && item.BranchId == branchId);
              if (deleteItem != null)
              {
                  _db.DeleteDirectly(deleteItem);
                  _db.SaveChanges();
              }

              return true;
          }
          catch (Exception exception)
          {
              LogManager.GetLogger("ECustoms.UserInGroupFactory").Error(exception.ToString());
              throw;
          }
          finally
          {
              _db.Connection.Close();
          }
      }

      public bool BatchInsert(object[] items)
      {
          var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

          try
          {
              _db.Connection.Open();
              foreach (object item in items)
              {
                  _db.AddObjectDirectly("tblUserInGroups", item);
              }

              _db.SaveChanges();
              return true;
          }
          catch (Exception ex)
          {
              LogManager.GetLogger("ECustoms.AllFactory").Error(ex.ToString());
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

          var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
          try
          {
              _db.Connection.Open();
              var lstUnSyncedItems = (from item in _db.tblUserInGroups
                                      where item.IsSynced == false
                                      select item).ToArray();
              _db.Connection.Close();
              return lstUnSyncedItems;
          }
          catch (Exception ex)
          {
              LogManager.GetLogger("ECustoms.AllFactory").Error(ex.ToString());
              throw;
          }
          finally
          {
              _db.Connection.Close();
          }

      }

      public bool UpdatePatch(object[] items)
      {
          var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

          try
          {
              _db.Connection.Open();
              var updateItems = items.OfType<tblUserInGroup>().ToList();

              foreach (var updateItem in updateItems)
              {
                  var item =
                      _db.tblUserInGroups.FirstOrDefault(
                          p => p.BranchId == updateItem.BranchId && p.UserID == updateItem.UserID
                          && p.GroupID == updateItem.GroupID);
                  item.IsSynced = true;
              }
              _db.SaveChanges();
              _db.Connection.Close();
              return true;
          }
          catch (Exception ex)
          {
              LogManager.GetLogger("ECustoms.AllFactory").Error(ex.ToString());
              throw;
          }
          finally
          {
              _db.Connection.Close();
          }
      }

      #endregion
  }
}
