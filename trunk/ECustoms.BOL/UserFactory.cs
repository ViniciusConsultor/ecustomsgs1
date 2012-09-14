﻿using System;
using System.Collections.Generic;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Configuration;
using log4net;

namespace ECustoms.BOL
{
    public class UserFactory : IDataModelCommand
    {
        private readonly string _dbConnectionString;

        public static dbEcustomEntities _db =
            new dbEcustomEntities(
                Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
        private static ILog logger = LogManager.GetLogger("ECustoms.UserFactory");

        /// <summary>
        /// Gets the user info.
        /// </summary>
        /// <param name="userInfo">The user info.</param>
        /// <returns></returns>
        public static tblUser GetUserInfo(tblUser userInfo)
        {
            try
            {
                _db.Connection.Open();
                // Encode the password & username
                userInfo.Password = Common.Encode(userInfo.Password);
                return
                    _db.tblUsers.Where(g => g.UserName.Equals(userInfo.UserName, StringComparison.OrdinalIgnoreCase) && g.Password.Equals(userInfo.Password) && g.IsActive == 1).
                        FirstOrDefault();
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

        /// <summary>
        /// Insert User
        /// </summary>
        /// <param name="userInfo">UserInfo object</param>
        /// <returns>Number of rows are effected</returns>
        public static int Insert(tblUser userInfo)
        {
            // Encode password & username
            userInfo.Password = Common.Encode(userInfo.Password);
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            db.AddTotblUsers(userInfo);
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        /// <summary>
        /// Checks the is user existing.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public static bool CheckIsUserExisting(string username)
        {
            try
            {
                _db.Connection.Open();
                var result = false;
                var users =
                    _db.tblUsers.Where(g => g.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)).ToList();
                if (users.Count > 0)
                {
                    result = true;
                }
                if (users.Count == 0) result = false;
                return result;
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

        public static tblUser GetByID(int userID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            tblUser user = db.tblUsers.Where(g => g.UserID.Equals(userID)).FirstOrDefault();
            db.Connection.Close();
            return user;
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="userInfo">userInfo object</param>
        /// <returns>Number of rows are effected</returns>
        public static int Update(tblUser userInfo)
        {
            // Encode password & username
            userInfo.Password = Common.Encode(userInfo.Password);

            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var usrOrgin = db.tblUsers.Where(g => g.UserID == userInfo.UserID).FirstOrDefault();
            if (usrOrgin == null) return -1;
            db.Attach(usrOrgin);
            db.ApplyPropertyChanges("tblUsers", userInfo);
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        /// <summary>
        /// Deletes the specified user ID.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public static int Delete(int userID)
        {
            try
            {
                _db.Connection.Open();
                var user = _db.tblUsers.Where(g => g.UserID.Equals(userID)).FirstOrDefault();
                _db.DeleteObject(user);
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


        public static List<tblUser> SelectAllUser()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            List<tblUser> list = db.tblUsers.OrderBy(g => g.Name).ToList();
            db.Connection.Close();
            return list;
        }

        public static List<tblUser> SelectAllUnSyncedUser()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            List<tblUser> list = (from item in db.tblUsers where item.IsSynced==false orderby item.Name select item).ToList();
            db.Connection.Close();
            return list;
        }

        public static List<tblUser> SearchByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return SelectAllUser();
            }
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            List<tblUser> list = db.tblUsers.Where(g => g.Name.Contains(name)).OrderByDescending(g => g.Name).ToList();
            db.Connection.Close();
            return list;
        }

        public static tblUser getUserByUserName(string userName)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            tblUser user = db.tblUsers.Where(g => g.UserName == userName).FirstOrDefault();
            db.Connection.Close();
            return user;
        }

        public static List<tblProfileConfig> GetProfileConfigByUserId(int userId)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var config = db.tblProfileConfigs.Where(g => g.UserID == userId).ToList();
            db.Connection.Close();
            return config;
        }

        public static void UpdateProfileConfig(int userId, List<tblProfileConfig> listProfileConfig) 
        {
            _db.Connection.Open();
            var listOldConfig = _db.tblProfileConfigs.Where(g => g.UserID == userId).ToList();
            foreach (var config in listProfileConfig)
            {
                var oldConfig = listOldConfig.Where(p => p.UserID == userId && p.Type == config.Type).FirstOrDefault();
                if (oldConfig != null)
                    oldConfig.Value = config.Value;
                else
                {
                    config.UserID = userId;
                    config.BranchId = FDHelper.RgCodeOfUnit();
                    _db.AddTotblProfileConfigs(config);    
                }
            }
            _db.SaveChanges();
            _db.Connection.Close();    
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
                    _db.tblUsers.FirstOrDefault(
                        item => item.UserID == id && item.BranchId == branchId);
                if (deleteItem != null)
                {
                    _db.DeleteDirectly(deleteItem);
                    _db.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                LogManager.GetLogger("ECustoms.UserFactory").Error(exception.ToString());
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
                    _db.AddObjectDirectly("tblUsers", item);
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
                var lstUnSyncedItems = (from item in _db.tblUsers
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
                var updateItems = items.OfType<tblUser>().ToList();

                foreach (var updateItem in updateItems)
                {
                    var item =
                        _db.tblUsers.FirstOrDefault(
                            p => p.BranchId == updateItem.BranchId && p.UserID == updateItem.UserID);
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
