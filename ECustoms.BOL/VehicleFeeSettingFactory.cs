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
    public class VehicleFeeSettingFactory
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

    }
}
