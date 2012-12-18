using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Configuration;
using System.Data;
using ECustoms.Utilities.Enums;
using log4net;

namespace ECustoms.BOL
{
    public class TrainFactory : IDataModelCommand
    {
        public static List<tblTrain> GetAll()
        {
            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblTrains.ToList();
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

        public static int Insert(tblTrain train)
        {
            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();
            train.CreatedDate = CommonFactory.GetCurrentDate();
            train.BranchId= FDHelper.RgCodeOfUnit();
            _db.AddTotblTrains(train);
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

        public static int Update(tblTrain train)
        {
            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            train.ModifiedDate = CommonFactory.GetCurrentDate();
            var originTrain = _db.tblTrains.Where(g => g.TrainID == train.TrainID).FirstOrDefault();

            if (originTrain == null)
            {
                return -1;
            }
            _db.Attach(originTrain);
            _db.ApplyPropertyChanges("tblTrains", train);
            
            return _db.SaveChanges();
        }

        public static int Delete(long trainId)
        {
            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                var train = _db.tblTrains.FirstOrDefault(g => g.TrainID == trainId);
                _db.DeleteObject(train);
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

        public static List<tblTrain> SearchTrain(string numberTrain, int type, DateTime date)
        {
            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                IQueryable<tblTrain> lst = _db.tblTrains;//.Where(x => (x.DateExport == date) || (x.DateImport == date));
                if (!string.IsNullOrEmpty(numberTrain)) lst = lst.Where(x => x.Number.Contains(numberTrain));
                if (type >= 0) lst = lst.Where(x => x.Type == type);
                else if (type == -1) // search tau hang 
                {
                    lst = lst.Where(x => x.Type == (short)TrainType.TypeExportNormal || x.Type == (short)TrainType.TypeExportChange || x.Type == (short)TrainType.TypeImportNormal || x.Type == (short)TrainType.TypeImportChange);
                }
                else
                {
                    //search tau khach
                    lst = lst.Where(x => x.Type == (short)TrainType.TypeExport || x.Type == (short)TrainType.TypeImport);
                }

                return lst.ToList();
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

        public static int InsertToKhai(tblToKhaiTau tokhai)
        {
            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();
            tokhai.CreatedDate = CommonFactory.GetCurrentDate();
            tokhai.BranchId = FDHelper.RgCodeOfUnit();
            _db.AddTotblToKhaiTaus(tokhai);
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

        public static int InsertToaTau(tblToaTau toaTau)
        {
            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();
            toaTau.CreatedDate = CommonFactory.GetCurrentDate();
            toaTau.BranchId = FDHelper.RgCodeOfUnit();
            _db.AddTotblToaTaus(toaTau);
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
        
        public static int InsertToaTau(List<tblToaTau> listToaTau)
        {
            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();
            foreach (var toaTau in listToaTau)
            {
                toaTau.CreatedDate = CommonFactory.GetCurrentDate();
                _db.AddTotblToaTaus(toaTau);   
            }
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

        #region Implementation of IDataModelCommand
        
        public bool DeleteItem(string[] itemParams)
        {
            throw new NotImplementedException();
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
