using System;
using System.Collections.Generic;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Configuration;
using ECustoms.Utilities.Enums;

namespace ECustoms.BOL
{
    public class VehicleFactory
    {
        /// <summary>
        /// Hien lên những xe đã hoàn thành thủ tục và đã trả hồ sơ của ngày hiện tại
        /// </summary>
        /// <returns></returns>
        public static List<ViewAllVehicleHasGood> GetAllAllVehicleCompleted()
        {
            DateTime today = CommonFactory.GetCurrentDate();

            var startToday = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);
            var endToday = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59);

            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            //var data = db.ViewAllVehicleHasGoods.Where(g => g.ConfirmStatus != null && g.IsGoodsImported == true && g.IsCompleted == true && g.ConfirmDate >= startToday && g.ConfirmDate <= endToday).OrderByDescending(g => g.ImportDate).ToList();
            
            //tim cac xe da nhap canh co hang, nhung chua vao noi dia, va co to khai da xac nhan tra ho so, chi hien thi theo ngay tra so so = ngay hien tai
            List<ViewAllVehicleHasGood> data = db.ViewAllVehicleHasGoods.Where(g => g.HasGoodsImported == true && g.IsCompleted != true && g.ConfirmStatus != null && g.ConfirmDate >= startToday && g.ConfirmDate <= endToday).OrderByDescending(g => g.ConfirmDate).ToList();
            db.Connection.Close();
            List<ViewAllVehicleHasGood> list = new List<ViewAllVehicleHasGood>();
            HashSet<long> listVehicleId = new HashSet<long>();
            if (data != null && data.Count > 0)
            {
                foreach (ViewAllVehicleHasGood obj in data)
                {
                    if (listVehicleId.Add(obj.VehicleID))
                    {
                        list.Add(obj);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Search Vehicle
        /// </summary>
        /// <param name="plateNumber"></param>
        /// <param name="plateNumberPartner"></param>
        /// <param name="isExport">IsExport</param>
        /// <param name="isImport">IsImport</param>
        /// <param name="isNotImport">IsNotImport</param>
        /// <param name="importFrom">Import from date</param>
        /// <param name="importTo">Import to date</param>
        /// <param name="exportFrom">Export from date</param>
        /// <param name="exportTo">Export to date</param>
        /// <param name="isCompleted"></param>
        /// <returns>List vehicleInfo object</returns>
        public static List<ViewAllVehicleHasGood> SearchVehicle(bool isCompleted, string plateNumber, string plateNumberPartner, bool isExport, bool isImport, bool isNotImport, DateTime importFrom, DateTime importTo, DateTime exportFrom, DateTime exportTo, bool isChineseVehicle)
        {
            importFrom = new DateTime(importFrom.Year, importFrom.Month, importFrom.Day, 0, 0, 0);
            importTo = new DateTime(importTo.Year, importTo.Month, importTo.Day, 23, 59, 59);
            exportFrom = new DateTime(exportFrom.Year, exportFrom.Month, exportFrom.Day, 0, 0, 0);
            exportTo = new DateTime(exportTo.Year, exportTo.Month, exportTo.Day, 23, 59, 59);

            //List<ViewAllVehicleHasGood> result;
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

            IQueryable<ViewAllVehicleHasGood> _viewAllVehicle = db.ViewAllVehicleHasGoods;//.Where(g => g.PlateNumber.Contains(plateNumber));
            _viewAllVehicle = !string.IsNullOrEmpty(plateNumber) ? _viewAllVehicle.Where(g => g.PlateNumber != null && g.PlateNumber.Contains(plateNumber)) : _viewAllVehicle;
            // Check is Chinese vehicle
            if (isChineseVehicle)
            {
                _viewAllVehicle = _viewAllVehicle.Where(g => g.IsChineseVehicle == true);
            }
            else
            {
                _viewAllVehicle = _viewAllVehicle.Where(g => g.IsChineseVehicle == null || g.IsChineseVehicle == false);
                _viewAllVehicle = !string.IsNullOrEmpty(plateNumberPartner) ? _viewAllVehicle.Where(g => g.PlateNumberPartner != null && g.PlateNumberPartner.Contains(plateNumberPartner)) : _viewAllVehicle;
            }

            // Da hoan thanh: la xe co IsCompleted==true (nhap canh co hang va da vao noi dia)
            if (isCompleted)
            {
                // Da xuat
                if (isExport)
                {
                    _viewAllVehicle = _viewAllVehicle.Where(g => (g.IsGoodsImported == true || g.DeclarationID == 0));
                    // da nhap theo thoi gian
                    if (isImport)
                    {
                        // Lay nhung ban ghi da hoan thanh theo export va import
                        _viewAllVehicle = _viewAllVehicle.Where(g => (g.IsCompleted == true && g.IsExport == true && g.ExportDate >= exportFrom && g.ExportDate <= exportTo) && (g.IsImport == true && g.ImportDate >= importFrom && g.ImportDate <= importTo));
                        //result = db.ViewAllVehicleHasGoods.Where(g => (g.IsCompleted == true && g.IsExport == true && g.ExportDate >= exportFrom && g.ExportDate <= exportTo) && (g.IsImport == true && g.ImportDate >= importFrom && g.ImportDate <= importTo) && (g.IsGoodsImported == true || (g.DeclarationID == 0))).ToList();
                    }
                    // Khong quan tam toi thoi gian nhap
                    else
                    {
                        // Chi lay nhung ban ghi da xuat va isImprot = true
                        _viewAllVehicle = _viewAllVehicle.Where(g => (g.IsCompleted == true) && (g.IsExport == true) && (g.IsImport == true) && (g.ExportDate >= exportFrom) && (g.ExportDate <= exportTo));
                        //result = db.ViewAllVehicleHasGoods.Where(g => (g.IsCompleted == true) && (g.IsExport == true) && (g.IsImport == true) && (g.ExportDate >= exportFrom) && (g.ExportDate <= exportTo) && (g.IsGoodsImported == true || (g.DeclarationID == 0))).ToList();
                    }
                }
                // da xuat = uncheck
                else
                {
                    // Lay tat ca ban ghi ma da hoan tat, khong quan tam toi thoi gian
                    _viewAllVehicle = _viewAllVehicle.Where(g => (g.IsCompleted == true) && (g.IsExport == true) && (g.IsImport == true));
                    //result = db.ViewAllVehicleHasGoods.Where(g => (g.IsCompleted == true) && (g.IsExport == true) && (g.IsImport == true) && (g.IsGoodsImported == true || (g.DeclarationID == 0))).ToList();
                }
            }
            // Chua hoanthanh
            else
            {
                // Da xuat
                if (isExport)
                {
                    _viewAllVehicle = _viewAllVehicle.Where(g => (g.IsGoodsImported == null || g.IsGoodsImported == false));
                    // chua nhap canh
                    if (isNotImport)
                    {
                        // chi lay nhung ban ghi da xuat, ma chua nhap      
                        _viewAllVehicle = _viewAllVehicle.Where(g => g.IsExport == true && (g.IsImport == null || g.IsImport == false) && (g.ExportDate >= exportFrom) && (g.ExportDate <= exportTo));
                        //result = db.ViewAllVehicleHasGoods.Where(g => g.IsExport == true && (g.IsImport == null || g.IsImport == false) && (g.ExportDate >= exportFrom) && (g.ExportDate <= exportTo) && (g.IsGoodsImported == null || g.IsGoodsImported == false)).ToList();
                    }
                    else if (isImport)
                    {
                        _viewAllVehicle = _viewAllVehicle.Where(g => (g.IsExport == true && g.ExportDate >= exportFrom && g.ExportDate <= exportTo) && (g.IsImport == true && g.ImportDate >= importFrom && g.ImportDate <= importTo));
                        //result = db.ViewAllVehicleHasGoods.Where(g => (g.IsExport == true && g.ExportDate >= exportFrom && g.ExportDate <= exportTo) && (g.IsImport == true && g.ImportDate >= importFrom && g.ImportDate <= importTo) && (g.IsGoodsImported == null || g.IsGoodsImported == false)).ToList();
                    }
                    else
                    {
                        // chi lay ban ghi da xuat canh, khong quan tam da nhap  hay chua
                        // chi lay nhung ban ghi da xuat, ma chua nhap                            
                        // order by exported date
                        _viewAllVehicle = _viewAllVehicle.Where(g => (g.IsExport != null && g.IsExport == true) && (g.ExportDate >= exportFrom) && (g.ExportDate <= exportTo));
                        //result = db.ViewAllVehicleHasGoods.Where(g => (g.IsExport != null && g.IsExport == true) && (g.ExportDate >= exportFrom) && (g.ExportDate <= exportTo) && (g.IsGoodsImported == null || g.IsGoodsImported == false)).ToList();
                    }
                }
                else
                {
                    // lay tat ban ghi chua xuat, chua nhap
                    _viewAllVehicle = _viewAllVehicle.Where(g => (g.IsExport == null || g.IsExport == false) && (g.IsImport == null || g.IsImport == false));
                    //result = db.ViewAllVehicleHasGoods.Where(g => (g.IsExport == null || g.IsExport == false) && (g.IsImport == null || g.IsImport == false)).ToList();
                }
            }
            
            List<ViewAllVehicleHasGood> rsl = (from a in _viewAllVehicle
                                               orderby a.ModifiedDate descending
                                               select a).ToList();
            //List<ViewAllVehicleHasGood> rsl = !string.IsNullOrEmpty(plateNumber) ? result.Where(g => g.PlateNumber != null && g.PlateNumber.Contains(plateNumber)).OrderByDescending(g => g.ModifiedDate).ToList() : result.OrderByDescending(g => g.ModifiedDate).ToList();
            db.Connection.Close();
            return rsl;
        }

        public static List<ViewAllVehicleHasGood> GetFromViewByDeclarationID(long declarationID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            List<ViewAllVehicleHasGood> list = db.ViewAllVehicleHasGoods.Where(g => g.DeclarationID == declarationID).ToList();
            db.Connection.Close();
            return list;
        }

        public static tblVehicle GetByID(long vehicleID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            tblVehicle vehicle = db.tblVehicles.Where(g => g.VehicleID == vehicleID).FirstOrDefault();
            db.Connection.Close();
            return vehicle;
        }

        public static ViewAllVehicleHasGood GetByIDFromView(long vehicleID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            ViewAllVehicleHasGood allVehicleHasGood = db.ViewAllVehicleHasGoods.Where(g => g.VehicleID == vehicleID).FirstOrDefault();
            db.Connection.Close();
            return allVehicleHasGood;
        }

        public static int UpdateVehicle(tblVehicle vehicle)
        {
            return UpdateVehicle(vehicle, 0);
        }

        /// <summary>
        /// Update Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="declerationID"></param>
        /// <returns></returns>
        public static int UpdateVehicle(tblVehicle vehicle, long declerationID)
        {
            // Set last modified date to now
            vehicle.ModifiedDate = CommonFactory.GetCurrentDate();
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            switch (declerationID)
            {
                case 0:
                    {
                        // Get orgin vehicle
                        var vehicleOrgin = db.tblVehicles.Where(g => g.VehicleID == vehicle.VehicleID).FirstOrDefault();
                        if (vehicleOrgin != null)
                        {
                            db.Attach(vehicleOrgin);
                            db.ApplyPropertyChanges("tblVehicles", vehicle);
                            int re = db.SaveChanges();
                            db.Connection.Close();
                            return re;
                        }
                        return -1;
                    }
                default:
                    {
                        var vehicleOrgin = db.tblVehicles.Where(g => g.VehicleID == vehicle.VehicleID).FirstOrDefault();
                        db.Attach(vehicleOrgin);
                        db.ApplyPropertyChanges("tblVehicles", vehicle);
                        db.SaveChanges();
                        // Insert to tblVehicleDeclerateion
                        var vehicleDeclara = new tblDeclarationVehicle();
                        vehicleDeclara.VehicleID = vehicle.VehicleID;
                        vehicleDeclara.DeclarationID = declerationID;
                        db.AddTotblDeclarationVehicles(vehicleDeclara);
                        int re = db.SaveChanges();
                        db.Connection.Close();
                        db.Dispose();
                        return re;

                    }
            }
        }

        /// <summary>
        /// Delete vehicle by ID
        /// </summary>
        /// <param name="vehicleID">Vehicle ID</param>
        /// <returns>Number of rows are effected</returns>
        public static int DeleteByID(long vehicleID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var vehicle = db.tblVehicles.Where(g => g.VehicleID == vehicleID).FirstOrDefault();
            if (vehicle != null)
                db.DeleteObject(vehicle);
            db.SaveChanges();
            // Revmove from vehicleDecleration
            var vehicleDeclere = db.tblDeclarationVehicles.Where(g => g.VehicleID == vehicleID).ToList();
            foreach (var item in vehicleDeclere)
            {
                var vehicleDeclereTemp = db.tblDeclarationVehicles.Where(g => g.VehicleID == vehicleID).FirstOrDefault();
                if (vehicleDeclereTemp != null)
                    db.DeleteObject(vehicleDeclereTemp);
                db.SaveChanges();
            }
            // TODO:
            db.Connection.Close();
            return 1;
        }

        /// <summary>
        ///  Get all Exported vehicle
        /// </summary>
        /// <returns></returns>
        public static List<tblVehicle> GetExported()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var result = db.tblVehicles.Where(g => (g.IsExport == true && (g.IsGoodsImported == null || g.IsGoodsImported == false) && (g.IsChineseVehicle == null || g.IsChineseVehicle == false)) || (g.IsChineseVehicle == true && g.IsExport == false && g.IsImport == true && g.HasGoodsImported == true)).OrderByDescending(g => g.ExportDate).ToList();
            return result;
        }


        /// <summary>
        ///  Get all Vehicle in Export Park
        /// </summary>
        /// <returns></returns>
        public static List<tblVehicle> GetVehicleInExportPark()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var result = db.tblVehicles.Where(g => g.IsExport == false && (g.IsGoodsImported == null || g.IsGoodsImported == false) && g.IsExportParking == true).OrderByDescending(g => g.ExportParkingDate).ToList();
            return result;
        }

        /// <summary>
        ///  Get Exist DeclarationVehicle Exported vehicle by vehicleID
        /// </summary>
        /// <returns></returns>
        public static List<viewDeclarationVehicle> GetExistDeclarationVehicleExported(long vehicleID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var result = db.viewDeclarationVehicles.Where(g => (g.VehicleID == vehicleID) && (g.DeclarationType == (int)DeclarationType.DeclarationTypeImport)).OrderByDescending(g => g.ExportDate).ToList();
            db.Connection.Close();
            return result;
        }


        /// <summary>
        ///  Get Exist DeclarationExported that contain vehicleInExportPark
        /// </summary>
        /// <returns></returns>
        public static List<viewDeclarationVehicle> GetExistDeclarationExportOfVehicleInExportPark(long vehicleID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var result = db.viewDeclarationVehicles.Where(g => g.DeclarationID != 0 && (g.VehicleID == vehicleID) && (g.DeclarationType == (int)DeclarationType.DeclarationTypeExport)).OrderByDescending(g => g.ExportDate).ToList();
            db.Connection.Close();
            return result;
        }


        /// <summary>
        ///  Get Exist DeclarationVehicle  by vehicleID
        /// </summary>
        /// <returns></returns>
        public static List<viewDeclarationVehicle> GetDeclarationVehicleByVehicleID(long vehicleID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var result = db.viewDeclarationVehicles.Where(g => (g.VehicleID == vehicleID)).OrderByDescending(g => g.RegisterDate).ToList();
            db.Connection.Close();
            return result;
        }



        public static List<viewDeclarationVehicle> GetImportDeclarationVehicleByVehicleID(long vehicleID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var result = db.viewDeclarationVehicles.Where(g => (g.VehicleID == vehicleID) && (g.DeclarationType == 1) && (g.DeclarationID != 1) && (g.DeclarationID != 0)).OrderByDescending(g => g.RegisterDate).ToList();
            db.Connection.Close();
            return result;
        }


        public static int InsertVehicle(tblVehicle vehicle)
        {
            return InsertVehicle(vehicle, 0);
        }

        public static int InsertVehicle(tblVehicle vehicle, long declarationID)
        {
            // Update last modified date by now
            vehicle.ModifiedDate = CommonFactory.GetCurrentDate();
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            db.tblDeclarations.Where(g => g.DeclarationID == declarationID).FirstOrDefault();
            db.AddTotblVehicles(vehicle);
            db.SaveChanges();
            // Insert to tblVehicleDeclerate
            var vehicleDeclere = new tblDeclarationVehicle();
            vehicleDeclere.VehicleID = vehicle.VehicleID;
            vehicleDeclere.DeclarationID = declarationID;
            db.AddTotblDeclarationVehicles(vehicleDeclere);
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        public static List<ViewAllVehicleHasGood> GetByDeclarationID(long declaractionID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            List<ViewAllVehicleHasGood> list = db.ViewAllVehicleHasGoods.Where(g => g.DeclarationID == declaractionID).ToList();
            db.Connection.Close();
            return list;
        }

        public static List<ViewAllVehicle> GetAllViewAllVehicle()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            List<ViewAllVehicle> list = db.ViewAllVehicles.ToList();
            db.Connection.Close();
            return list;
        }

        //c ap nhat so lan in ticket cua vehicle
        public static int UpdateTicketTotalPrint(tblVehicle vehicle)
        {
          var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
          tblVehicle vehicleObj = db.tblVehicles.Where(g => g.VehicleID == vehicle.VehicleID).FirstOrDefault();

          vehicleObj.HasGoodsImportedTocalPrint = vehicle.HasGoodsImportedTocalPrint;
          vehicleObj.ParkingTotalPrint = vehicle.ParkingTotalPrint;

          vehicleObj.HasGoodsImportedPrintOrderNumber = vehicle.HasGoodsImportedPrintOrderNumber;
          vehicleObj.ParkingTotalPrintOrderNumber = vehicle.ParkingTotalPrintOrderNumber;

          int re = db.SaveChanges();
          db.Connection.Close();
          return re;
        }

        public static List<tblVehicle> GetChineseVehicle()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var result = db.tblVehicles.Where(g => g.IsChineseVehicle == true).OrderByDescending(g => g.ModifiedDate).ToList();
            return result;
        }

        public static List<string> GetAllPlateNumberChinese()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var lstResult = db.tblVehicles.Where(g => g.IsChineseVehicle == true).Select(g => g.PlateNumber).Distinct().ToList();
            db.Connection.Close();
            return lstResult;
        }
    }
}
