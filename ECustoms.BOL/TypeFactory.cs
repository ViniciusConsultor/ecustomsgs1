﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Configuration;
using System.Data;
using log4net;

namespace ECustoms.BOL
{
    public class TypeFactory : IDataModelCommand
    {

        public static List<tblType> getAllType()
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblTypes.ToList();
            }
            catch
            {
                return null;
            }
            finally
            {
                _db.Connection.Close();
            }
        }


        public static tblType FindByCode(string code)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblTypes.Where(g => g.TypeCode == code).FirstOrDefault();
            }
            catch
            {
                return null;
            }
            finally
            {
                _db.Connection.Close();
            }

        }

        public static int Insert(tblType type)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();
            type.CreatedDate = CommonFactory.GetCurrentDate();
            type.ModifiedDate = CommonFactory.GetCurrentDate();
            _db.AddTotblTypes(type);
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                _db.Connection.Close();
            }
        }

        public static int Update(tblType typeObj)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();

            tblType originType = _db.tblTypes.Where(g => g.TypeCode == typeObj.TypeCode).FirstOrDefault();

            if (originType == null)
            {
                return -1;
            }

            originType.TypeName = typeObj.TypeName;
            originType.Description = typeObj.Description;
            originType.ModifiedBy = typeObj.ModifiedBy;
            originType.ModifiedDate = CommonFactory.GetCurrentDate();

            try
            {
                return _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                _db.Connection.Close();
            }
        }

        public static int DeleteType(String typeCode)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                var type = _db.tblTypes.FirstOrDefault(vt => vt.TypeCode == typeCode);
                _db.DeleteObject(type);
                return _db.SaveChanges();
            }
            catch
            {
                return -1;
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

            string id = itemParams[0];
            string branchId = itemParams[1];

            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

            try
            {
                var deleteItem =
                    _db.tblTypes.FirstOrDefault(
                        item => item.TypeCode == id && item.BranchId == branchId);
                if (deleteItem != null)
                {
                    _db.DeleteDirectly(deleteItem);
                    _db.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                LogManager.GetLogger("ECustoms.TypeFactory").Error(exception.ToString());
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
