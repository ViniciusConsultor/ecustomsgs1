using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;
using log4net;

namespace ECustoms.BOL
{
    public class GroupFactory : IDataModelCommand
    {
        public static  List<tblGroup> SelectAll()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            List < tblGroup >  list = db.tblGroups.ToList();
            db.Connection.Close();
            return list;
        }

        public static tblGroup SelectByID(int groupID)
        {
            return null;
        }

        public static int Insert(tblGroup group)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            group.CreatedDate = CommonFactory.GetCurrentDate();
            group.ModifiedDate = CommonFactory.GetCurrentDate();
            db.AddTotblGroups(group);
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        public static int Update(tblGroup group)
        {          
          var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
          var groupOrgin = db.tblGroups.Where(g => g.GroupID == group.GroupID).FirstOrDefault();
          if (groupOrgin == null) return -1;
          db.Attach(groupOrgin);
          db.ApplyPropertyChanges("tblGroups", group);
          int re = db.SaveChanges();
          db.Connection.Close();
          return re;
        }

        /// <summary>
        /// Check if the group name is exsiting
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public static bool IsExistingName(string groupName)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

            var group = db.tblGroups.Where(g => g.GroupName == groupName).ToList();
            db.Connection.Close();
            return group.Count != 0;
        }

        public static tblGroup getGroupByName(string groupName)
        {
          var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

          var group = db.tblGroups.Where(g => g.GroupName == groupName).FirstOrDefault();
          db.Connection.Close();
          return group;
        }

        public static tblGroup getGroupByID(int groupID)
        {
          var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

          var group = db.tblGroups.Where(g => g.GroupID == groupID).FirstOrDefault();
          db.Connection.Close();
          return group;
        }

        public static int DeleteGroupByGroupID(int groupID)
        {
          var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
          
          var group = db.tblGroups.Where(g => g.GroupID == groupID).FirstOrDefault();

          if (group == null)
          {
            return 0;
          }

          //delete group
          db.DeleteObject(group);

          //delete group's users in tblUserInGroup
          List<tblUserInGroup> listTblUserInGroup = db.tblUserInGroups.Where(g => g.GroupID == groupID).ToList();
          foreach (tblUserInGroup userInGroup in listTblUserInGroup)
          {
            db.DeleteObject(userInGroup);
          }

          //delete group's permission in tblUserGroupPermistion
          List<tblUserGroupPermission> listUserGroupPermission = db.tblUserGroupPermissions.Where(g => g.GroupID == groupID && g.PermissionType == UserGroupPermissionFactory.PERMISSION_TYPE_GROUP).ToList();
          foreach (tblUserGroupPermission userGroupPermission in listUserGroupPermission)
          {
            db.DeleteObject(userGroupPermission);
          }

          int re = db.SaveChanges();
          db.Connection.Close();
          return re;
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
                    _db.tblGroups.FirstOrDefault(
                        item => item.GroupID == id && item.BranchId == branchId);
                if (deleteItem != null)
                {
                    _db.DeleteDirectly(deleteItem);
                    _db.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                LogManager.GetLogger("ECustoms.GroupFactory").Error(exception.ToString());
                throw;
            }
            finally
            {
                _db.Connection.Close();
            }
        }

        public bool BatchInsert(object[] items)
        {
            throw new NotImplementedException();
        }

        public object[] GetUnSyncedItems()
        {
            throw new NotImplementedException();
        }

        public bool UpdatePatch(object[] items)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
