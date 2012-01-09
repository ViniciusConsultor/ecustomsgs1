using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;

namespace ECustoms.BOL
{
  public class UserInGroupFactory
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


  }
}
