using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Configuration;
using System.Data;

namespace ECustoms.BOL
{
    public class CustomsFacory
    {
        public static List<tblCustom> getAll()
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblCustoms.ToList();
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


        public static tblCustom FindByCode(string code)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblCustoms.Where(g => g.CustomsCode == code).FirstOrDefault();
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

        public static int Insert(tblCustom customs)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();
            customs.CreatedDate = CommonFactory.GetCurrentDate();
            customs.ModifiedDate = CommonFactory.GetCurrentDate();
            _db.AddTotblCustoms(customs);
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

        public static int Update(tblCustom customsObj)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();

            tblCustom originCustoms = _db.tblCustoms.Where(g => g.CustomsCode == customsObj.CustomsCode).FirstOrDefault();

            if (originCustoms == null)
            {
                return -1;
            }

            originCustoms.CustomsName = customsObj.CustomsName;
            originCustoms.Description = customsObj.Description;
            originCustoms.ModifiedBy = customsObj.ModifiedBy;
            originCustoms.ModifiedDate = CommonFactory.GetCurrentDate();

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

        public static int Delete(String customsCode)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                var customs = _db.tblCustoms.FirstOrDefault(g => g.CustomsCode == customsCode);
                _db.DeleteObject(customs);
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
    }
}
