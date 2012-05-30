﻿using System;
using System.Collections.Generic;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Configuration;
using ECustoms.Utilities.Enums;

namespace ECustoms.BOL
{
    public class DeclarationFactory
    {
        /// <summary>
        /// Insert to Declaration and list vehicle
        /// </summary>
        /// <param name="declarationInfo"></param>
        /// <param name="vehicleInfos"></param>
        /// <param name="listVehicleUpdate"></param>
        /// <param name="userID"></param>
        public static int AddDeclaration(tblDeclaration declarationInfo, List<tblVehicle> vehicleInfos, List<tblVehicle> listVehicleUpdate, int userID)
        {
            var result = -1;
            var currentDate = CommonFactory.GetCurrentDate();
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

            declarationInfo.tblUser = db.tblUsers.Where(g => g.UserID.Equals(userID)).FirstOrDefault();
            // Set Created date and Last modified date
            declarationInfo.CreatedDate = currentDate;
            declarationInfo.ModifiedDate = currentDate;
            db.AddTotblDeclarations(declarationInfo);
            db.SaveChanges();
            // Return if insert fail
            if (declarationInfo.DeclarationID <= 0) return -1;
            // Add vehicle
            foreach (var vehicle in vehicleInfos)
            {
                // Update movidifedDate and Created date
                vehicle.CreatedDate = currentDate;
                vehicle.ModifiedDate = currentDate;
                db.AddTotblVehicles(vehicle);
                db.SaveChanges();

                // Insert to the tblVehicleDeclerateion
                var vehicleDeclara = new tblDeclarationVehicle();
                vehicleDeclara.VehicleID = vehicle.VehicleID;
                vehicleDeclara.DeclarationID = declarationInfo.DeclarationID;
                db.AddTotblDeclarationVehicles(vehicleDeclara);
                db.SaveChanges();
                // Add data to tblDecleVehicle
            }

            // Update the vehicle
            if (listVehicleUpdate.Count > 0)
            {
                foreach (var vehicle in listVehicleUpdate)
                {
                    // Update Vehicle infor
                    VehicleFactory.UpdateVehicle(vehicle, 0);
                    // Add to tblDeclerateVehcle
                    var declerartionTem =
                        db.tblDeclarations.Where(g => g.DeclarationID == declarationInfo.DeclarationID).FirstOrDefault();

                    var vehicleDeclara = new tblDeclarationVehicle();
                    vehicleDeclara.VehicleID = vehicle.VehicleID;
                    vehicleDeclara.DeclarationID = declerartionTem.DeclarationID;
                    db.AddTotblDeclarationVehicles(vehicleDeclara);
                    db.SaveChanges();
                }
            }
            db.Connection.Close();
            return result;
        }

        /// <summary>
        /// Delete Decleration by ID
        /// </summary>
        /// <param name="declerationID">DeclerationID</param>
        /// <returns>Number of rows are effected</returns>
        public static int DeleteByID(long declerationID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var declaration = db.tblDeclarations.Where(g => g.DeclarationID == declerationID).FirstOrDefault();
            db.DeleteObject(declaration);
            // Delete all record in VehicleDeclerat Table
            var vehicleDeclere = db.tblDeclarationVehicles.Where(g => g.DeclarationID == declerationID).ToList();
            db.SaveChanges();
            foreach (var item in vehicleDeclere)
            {
                var vehicleDeclereTemp = db.tblDeclarationVehicles.Where(g => g.DeclarationID == declerationID).FirstOrDefault();
                if (vehicleDeclereTemp != null)
                    db.DeleteObject(vehicleDeclereTemp);
                db.SaveChanges();
            }
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        /// <summary>
        /// Get Declaration by ID
        /// </summary>
        /// <param name="declarationID">DeclarationID</param>
        /// <returns>DeclarationInfo object</returns>
        public static tblDeclaration GetByID(long declarationID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            tblDeclaration declaration = db.tblDeclarations.Where(g => g.DeclarationID == declarationID).FirstOrDefault();
            db.Connection.Close();
            return declaration;
        }

        /// <summary>
        /// update declaration
        /// </summary>
        /// <param name="declaration"></param>
        /// <returns></returns>
        public static int Update(tblDeclaration declaration)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            declaration.ModifiedDate = CommonFactory.GetCurrentDate();
            // Get orgin object
            var objOrginDeclaration = db.tblDeclarations.Where(g => g.DeclarationID.Equals(declaration.DeclarationID)).FirstOrDefault();
            db.Attach(objOrginDeclaration);
            db.ApplyPropertyChanges("tblDeclarations", declaration);
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        /// <summary>
        /// Confirm return document
        /// </summary>
        /// <param name="confirmStatus"></param>
        /// <param name="declerationID"></param>
        /// <returns></returns>
        public static int ConfirmReturnDocument(string confirmStatus, long declerationID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var decleration = db.tblDeclarations.Where(g => g.DeclarationID == declerationID).FirstOrDefault();
            decleration.ConfirmStatus = confirmStatus;
            decleration.ConfirmDate = CommonFactory.GetCurrentDate();
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        public static List<ViewAllDeclaration> SelectAllFromView()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            // Dont' get the DeclerationID = 0 and 1
            List<ViewAllDeclaration> list = db.ViewAllDeclarations.Where(g => g.DeclarationID != 0 && g.DeclarationID != 1).ToList();
            db.Connection.Close();
            return list;
        }

        /// <summary>
        /// Get delceration by VehicleID
        /// </summary>
        /// <param name="vehicleID"></param>
        /// <returns></returns>
        public static List<ViewAllVehicleHasGood> GetByVehicleID(long vehicleID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            List<ViewAllVehicleHasGood> list = db.ViewAllVehicleHasGoods.Where(g => g.VehicleID == vehicleID && g.DeclarationID > 1).ToList();
            db.Connection.Close();
            return list;
        }

        public static List<ViewAllVehicleHasGood> GetAllVehicleByVehicleID(long vehicleID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            List<ViewAllVehicleHasGood> list = db.ViewAllVehicleHasGoods.Where(g => g.VehicleID == vehicleID).ToList();
            db.Connection.Close();
            return list;
        }

        public static List<string> GetAllRegisterPlace()
        {
          var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
          var lstResult = db.tblDeclarations.Where(g => g.RegisterPlace != null && g.RegisterPlace != "").Select(g=> g.RegisterPlace).Distinct().ToList();
          db.Connection.Close();
          return lstResult;
        }

        public static List<string> GetAllTypeExport()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var lstResult = db.tblDeclarations.Where(g => g.Type != null && g.Type != "").Select(g => g.Type).Distinct().ToList();
            db.Connection.Close();
            return lstResult;
        }

        public static List<string> GetAllGateExport()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var lstResult = db.tblDeclarations.Where(g => g.GateExport != null && g.GateExport != "").Select(g => g.GateExport).Distinct().ToList();
            db.Connection.Close();
            return lstResult;
        }

        public static int UpdateReturnInfo(long declerationID, int userID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var decleration = db.tblDeclarations.Where(g => g.DeclarationID == declerationID).FirstOrDefault();
            decleration.PersonConfirmReturnID = userID;
            decleration.DateReturn = CommonFactory.GetCurrentDate();
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        public static void ConfirmGetFee(long declarationId, int declarationType, int userId)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var currentDate = CommonFactory.GetCurrentDate();
            var listFee = VehicleFeeSettingFactory.getAllVehicleFeeSetting();
            var listVehicle = VehicleFactory.GetByDeclarationID(declarationId);
            foreach (var vehicleInfo in from item in listVehicle
                                        where item != null
                                        select db.tblVehicles.Where(v => v.VehicleID == item.VehicleID).FirstOrDefault())
            {
                if (declarationType.Equals((int)Common.DeclerationType.Export))
                {
                    vehicleInfo.ExportReceiptNumber = "9999";
                    var feeSetting = listFee.Where(f => f.VehicleTypeId == vehicleInfo.vehicleTypeId && f.GoodsTypeId == vehicleInfo.ExportGoodTypeId).FirstOrDefault();
                    var amount = feeSetting != null ? (feeSetting.Fee ?? 0) : 0;
                    vehicleInfo.feeExportAmount = amount;
                    vehicleInfo.feeExportDate = currentDate;
                    vehicleInfo.feeExportStatus = (int)FeeStatus.PaidFee;
                    vehicleInfo.confirmFeeExportBy = userId;
                }
                else
                {
                    vehicleInfo.ImportReceiptNumber = "9999";
                    var feeSetting = listFee.Where(f => f.VehicleTypeId == vehicleInfo.vehicleTypeId && f.GoodsTypeId == vehicleInfo.ImportGoodTypeId).FirstOrDefault();
                    var amount = feeSetting != null ? (feeSetting.Fee ?? 0) : 0;
                    vehicleInfo.feeImportAmount = amount;
                    vehicleInfo.feeImportDate = currentDate;
                    vehicleInfo.feeImportStatus = (int)FeeStatus.PaidFee;
                    vehicleInfo.confirmFeeImportBy = userId;
                }
                db.SaveChanges();
            }
            db.Connection.Close();
        }
    }
}
