using System;
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
    public class VehicleFeeSettingFactory : IDataModelCommand
    {

        public static List<tblVehicleFeeSetting> getAllVehicleFeeSetting()
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblVehicleFeeSettings.ToList();
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


        public static List<tblVehicleFeeSetting> search(int vehicleTypeId, int goodsTypeId)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                List<tblVehicleFeeSetting> list = new List<tblVehicleFeeSetting>();
                if (vehicleTypeId > 0 && goodsTypeId > 0)
                {
                    list= _db.tblVehicleFeeSettings.Where(g => g.VehicleTypeId == vehicleTypeId && g.GoodsTypeId == goodsTypeId).OrderByDescending(g => g.UpdatedDate).ToList();
                }
                else
                    if (vehicleTypeId > 0 && goodsTypeId == 0)
                    {
                        list = _db.tblVehicleFeeSettings.Where(g => g.VehicleTypeId == vehicleTypeId).OrderByDescending(g => g.UpdatedDate).ToList();
                    }
                    else
                        if (vehicleTypeId == 0 && goodsTypeId > 0)
                        {
                            list = _db.tblVehicleFeeSettings.Where(g => g.GoodsTypeId == goodsTypeId).OrderByDescending(g => g.UpdatedDate).ToList();
                        }
                        else
                        {
                            list = _db.tblVehicleFeeSettings.OrderByDescending(g => g.UpdatedDate).ToList();
                        }


                return list;
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


        public static tblVehicleFeeSetting find(int vehicleTypeId, int goodsTypeId)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblVehicleFeeSettings.Where(g => g.VehicleTypeId == vehicleTypeId && g.GoodsTypeId == goodsTypeId).FirstOrDefault();
              
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

        public static int Insert(tblVehicleFeeSetting vehicleFee)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();
            vehicleFee.CreatedDate = CommonFactory.GetCurrentDate();
            vehicleFee.UpdatedDate = CommonFactory.GetCurrentDate();
            _db.AddTotblVehicleFeeSettings(vehicleFee);
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                _db.Connection.Close();
            }
        }

        public static int Update(tblVehicleFeeSetting vehicleFee)
        {
            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();
            var _vehicleFee = _db.tblVehicleFeeSettings.Where(g => g.VehicleTypeId == vehicleFee.VehicleTypeId && g.GoodsTypeId == vehicleFee.GoodsTypeId).FirstOrDefault();
            if (vehicleFee != null)
            {
                _vehicleFee.Fee = vehicleFee.Fee;
                _vehicleFee.Description = vehicleFee.Description;
                _vehicleFee.UpdatedDate = CommonFactory.GetCurrentDate();
                try
                {
                    if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                    return _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return 0;
                }
                finally
                {
                    _db.Connection.Close();
                }
            }
            return 0;
        }

        public static int Delete (tblVehicleFeeSetting vehicleFee)
        {
            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();
            var _vehicleFee = _db.tblVehicleFeeSettings.Where(g => g.VehicleTypeId == vehicleFee.VehicleTypeId && g.GoodsTypeId == vehicleFee.GoodsTypeId).FirstOrDefault();
            if (vehicleFee != null)
            {
                try
                {
                    if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                    _db.DeleteObject(_vehicleFee);
                    return _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return 0;
                }
                finally
                {
                    _db.Connection.Close();
                }
            }
            return 0;
        }

        #region Implementation of IDataModelCommand

        public bool DeleteItem(string[] itemParams)
        {
            if (itemParams.Length < 3) return false;

            int id = itemParams[0].StringToInt();
            int goodType = itemParams[1].StringToInt();
            string branchId = itemParams[2];

            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

            try
            {
                var deleteItem =
                    _db.tblVehicleFeeSettings.FirstOrDefault(
                        item => item.VehicleTypeId == id && item.GoodsTypeId == goodType && item.BranchId == branchId);
                if (deleteItem != null)
                {
                    _db.DeleteDirectly(deleteItem);
                    _db.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                LogManager.GetLogger("ECustoms.VehicleFeeSettingFactory").Error(exception.ToString());
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
