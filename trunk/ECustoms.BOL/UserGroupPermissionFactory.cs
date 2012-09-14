using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;
using log4net;

namespace ECustoms.BOL
{
  public class UserGroupPermissionFactory : IDataModelCommand
  {
    public const int PERMISSION_TYPE_GROUP = 1;
    public const int PERMISSION_TYPE_USER = 2;

    public static List<tblUserGroupPermission> GetByGroupID(int groupID)
    {
      var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

      List < tblUserGroupPermission >  list = db.tblUserGroupPermissions.Where(g => g.GroupID == groupID && g.PermissionType == PERMISSION_TYPE_GROUP).ToList();
      db.Connection.Close();
      return list;
    }

    public static List<tblUserGroupPermission> GetByUserID(int userID)
    {
      var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

      List < tblUserGroupPermission >  list = db.tblUserGroupPermissions.Where(g => g.UserID == userID && g.PermissionType == PERMISSION_TYPE_USER).ToList();
      db.Connection.Close();
      return list;
    }

    public static int DeleteUserGroupPermissionByGroupID(int groupID)
    {
      var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
      List<tblUserGroupPermission> listUserGroupPermission = db.tblUserGroupPermissions.Where(g => g.GroupID == groupID && g.PermissionType == PERMISSION_TYPE_GROUP).ToList();
      foreach (tblUserGroupPermission userGroupPermission in listUserGroupPermission)
      {
        db.DeleteObject(userGroupPermission);
      }
      int re = db.SaveChanges();
      db.Connection.Close();
      return re;
    }

    public static int DeleteUserGroupPermissionByUserID(int userID)
    {
      var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
      List<tblUserGroupPermission> listUserGroupPermission = db.tblUserGroupPermissions.Where(g => g.UserID == userID && g.PermissionType == PERMISSION_TYPE_USER).ToList();
      foreach (tblUserGroupPermission userGroupPermission in listUserGroupPermission)
      {
        db.DeleteObject(userGroupPermission);
      }
      int re = db.SaveChanges();
      db.Connection.Close();
      return re;
    }

    public static int Insert(tblUserGroupPermission userGroupPermission)
    {
      var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
      db.AddTotblUserGroupPermissions(userGroupPermission);
      int re = db.SaveChanges();
      db.Connection.Close();
      return re;
    }

    public static int Insert(List<tblUserGroupPermission> listUserGroupPermission)
    {
      var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

      foreach (tblUserGroupPermission userGroupPermission in listUserGroupPermission)
      {
        db.AddTotblUserGroupPermissions(userGroupPermission);
      }
      int re = db.SaveChanges();
      db.Connection.Close();
      return re;
    }

    //get all permission of Users (user's permissions and permission of Groups that User in them)
    public static List<int> GetAllPermissionOfUser(int userID)
    {
      List<int> listAllPermission = new List<int>();
      List<tblUserGroupPermission> listUserPermission = GetByUserID(userID);
      foreach (tblUserGroupPermission userGroupPermission in listUserPermission)
      {
        var permissionID = userGroupPermission.PermissionID;
        listAllPermission.Add((int)permissionID);
      }
      List<ViewUserGroup> listUserInGroup = UserInGroupFactory.GetByUserID(userID);
      foreach (ViewUserGroup userGroup in listUserInGroup)
      {
        List<tblUserGroupPermission> listGroupPermission = GetByGroupID(userGroup.GroupID);
        foreach (tblUserGroupPermission userGroupPermission in listGroupPermission)
        {
          var permissionID = userGroupPermission.PermissionID;
          if (listAllPermission.Contains((int)permissionID) == false)
          {
            listAllPermission.Add((int)permissionID);
          }
        }
      }
       return listAllPermission;
    }

    public static List<int> GetAllPermissionForAdmin()
    {
      List<int> listAllPermission = new List<int>();
      List<tblPermission> listPermission = PermissionFactory.GetAllPermission();
      foreach (tblPermission permission in listPermission)
      {
        var permissionID = permission.PermissionID;
        listAllPermission.Add((int)permissionID);
      }
      return listAllPermission;
    }

    //Check permission of UserID
    public bool chectPermission(int userID, int permissionID)
    {
      List<int> listAllPermission = GetAllPermissionOfUser(userID);
      if(listAllPermission != null && listAllPermission.Count > 0)
      {
        return listAllPermission.Contains(permissionID);
      }
      return false;
    }

      #region Implementation of IDataModelCommand

      public bool DeleteItem(string[] itemParams)
      {
          if (itemParams.Length < 2) return false;

          int id = itemParams[0].StringToInt();
          string branchId = itemParams[1];

          var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

          try
          {
              var deleteItem =
                  _db.tblUserGroupPermissions.FirstOrDefault(
                      item => item.ID == id && item.BranchId == branchId);
              if (deleteItem != null)
              {
                  _db.DeleteDirectly(deleteItem);
                  _db.SaveChanges();
              }

              return true;
          }
          catch (Exception exception)
          {
              LogManager.GetLogger("ECustoms.UserGroupPermissionFactory").Error(exception.ToString());
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
                  _db.AddObjectDirectly("tblUserGroupPermissions", item);
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
              var lstUnSyncedItems = (from item in _db.tblUserGroupPermissions
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
              var updateItems = items.OfType<tblUserGroupPermission>().ToList();

              foreach (var updateItem in updateItems)
              {
                  var item =
                      _db.tblUserGroupPermissions.FirstOrDefault(
                          p => p.BranchId == updateItem.BranchId && p.ID == updateItem.ID);
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
