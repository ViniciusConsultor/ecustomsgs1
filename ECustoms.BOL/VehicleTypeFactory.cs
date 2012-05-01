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
    class VehicleTypeFactory
    {
        public static int Insert(tblVehicleType vehicletype)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();
            vehicletype.CreatedDate = CommonFactory.GetCurrentDate();
            vehicletype.UpdatedDate = CommonFactory.GetCurrentDate();
            _db.AddTotblVehicleTypes(vehicletype);
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return 1;
            }
            finally
            {
                _db.Connection.Close();
            }
            return 0;
        }

        public static int Update(tblVehicleType vehicletype)
        {
            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            _db.Connection.Open();
            var _vehicletype = (from vt in _db.tblVehicleTypes
                                where vt.VehicleTypeID == vehicletype.VehicleTypeID
                                select vt).First();
            _vehicletype.Name = vehicletype.Name;
            _vehicletype.Capacity = vehicletype.Capacity;
            _vehicletype.Description = vehicletype.Description;
            _vehicletype.DayPrice = vehicletype.DayPrice;
            _vehicletype.HourPrice = vehicletype.HourPrice;
            vehicletype.UpdatedDate = CommonFactory.GetCurrentDate();
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return 1;
            }
            finally
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                _db.Connection.Close();
            }
            return 0;
        }

        public static tblVehicleType findByName(String vehicleTypeName)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblVehicleTypes.Where(g => g.Name == vehicleTypeName).FirstOrDefault();
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

        public static tblVehicleType FindById(int vehicleTypeID)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblVehicleTypes.Where(g => g.VehicleTypeID == vehicleTypeID).FirstOrDefault();
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

        public static tblVehicleType FindByCode(string code)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblVehicleTypes.Where(g => g.Code == code).FirstOrDefault();
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

        public static List<tblVehicleType> getAllVehicleType()
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblVehicleTypes.ToList();
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

        public static void DeleteVehicleType(int vehicleTypeID)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                var tblVehicleTypes = _db.tblVehicleTypes.FirstOrDefault(vt => vt.VehicleTypeID == vehicleTypeID);
                _db.DeleteObject(tblVehicleTypes);
                _db.SaveChanges();
            }
            catch
            {
            }
            finally
            {
                _db.Connection.Close();
            }
        }
    }

}
