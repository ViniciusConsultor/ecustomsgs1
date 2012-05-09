USE [dbEcustoms]
GO
/****** Object:  View [dbo].[ViewAllVehicleHasGood]    Script Date: 05/09/2012 23:28:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[ViewAllVehicleHasGood]
AS
SELECT     dbo.tblVehicle.VehicleID, dbo.tblVehicle.PlateNumber, dbo.tblVehicle.NumberOfContainer, dbo.tblVehicle.DriverName, dbo.tblVehicle.ImportDate, 
                      dbo.tblVehicle.IsImport, dbo.tblVehicle.ExportDate, dbo.tblVehicle.IsExport, dbo.tblVehicle.Note, dbo.tblVehicle.Status, dbo.tblVehicle.IsCompleted, 
                      dbo.tblVehicle.IsGoodsImported, dbo.tblVehicle.ImportStatus, dbo.tblVehicle.ImportedLocalTime, dbo.tblVehicle.HasGoodsImported, dbo.tblVehicle.ConfirmImportBy, 
                      dbo.tblVehicle.ConfirmExportBy, dbo.tblVehicle.ConfirmLocalImportBy, dbo.tblDeclaration.DeclarationID, dbo.tblDeclaration.Number, dbo.tblDeclaration.ProductName, 
                      dbo.tblDeclaration.CompanyName, dbo.tblDeclaration.ProductAmount, dbo.tblDeclaration.Unit, dbo.tblDeclaration.CreatedByID, dbo.tblDeclaration.ModifiedByID, 
                      dbo.tblDeclaration.ModifiedDate, dbo.tblDeclaration.CreatedDate, dbo.tblDeclaration.HasDeclaration, dbo.tblDeclaration.Type, dbo.tblDeclaration.CompanyCode, 
                      dbo.tblDeclaration.RegisterDate, dbo.tblDeclaration.DeclarationType, dbo.fn_GetNameById(dbo.tblVehicle.ConfirmExportBy) AS ConfirmExportByName, 
                      dbo.fn_GetNameById(dbo.tblVehicle.ConfirmImportBy) AS ConfirmImportByName, dbo.fn_GetNameById(dbo.tblVehicle.ConfirmLocalImportBy) 
                      AS ConfirmLocalImportByName, dbo.tblDeclaration.ConfirmStatus, dbo.tblDeclaration.ConfirmDate, dbo.tblVehicle.Parking, dbo.tblVehicle.ParkingDate, 
                      dbo.tblDeclaration.Money, dbo.tblDeclaration.RegisterPlace, dbo.tblVehicle.IsExportParking, dbo.tblVehicle.ExportParkingDate, 
                      dbo.tblVehicle.ConfirmExportParkingBy, dbo.tblVehicle.PlateNumberPartner, dbo.tblVehicle.IsChineseVehicle, dbo.tblVehicle.vehicleTypeId, dbo.tblVehicleType.Code, 
                      dbo.tblVehicleType.Name, dbo.tblVehicle.GoodTypeId, dbo.tblGoodsType.TypeName, dbo.tblVehicle.quantityExport, dbo.tblVehicle.quantityImport, 
                      dbo.tblVehicle.feeExportStatus, dbo.tblVehicle.feeImportStatus, dbo.tblVehicle.feeExportAmount, dbo.tblVehicle.feeImportAmount, dbo.tblVehicle.feeExportDate, 
                      dbo.tblVehicle.feeImportDate, dbo.tblVehicle.confirmFeeExportBy, dbo.tblVehicle.confirmFeeImportBy, dbo.tblVehicle.ExportReceiptNumber, 
                      dbo.tblVehicle.ImportReceiptNumber, dbo.tblVehicle.CreatedDate AS CreatedDateVehicle, dbo.tblVehicleType.Capacity
FROM         dbo.tblVehicle INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblVehicle.VehicleID = dbo.tblDeclarationVehicle.VehicleID INNER JOIN
                      dbo.tblDeclaration ON dbo.tblDeclarationVehicle.DeclarationID = dbo.tblDeclaration.DeclarationID LEFT OUTER JOIN
                      dbo.tblGoodsType ON dbo.tblVehicle.GoodTypeId = dbo.tblGoodsType.TypeId LEFT OUTER JOIN
                      dbo.tblVehicleType ON dbo.tblVehicle.vehicleTypeId = dbo.tblVehicleType.VehicleTypeID
WHERE     (dbo.tblVehicle.VehicleID IN
                          (SELECT     VehicleID
                            FROM          dbo.tblDeclarationVehicle AS tblDeclarationVehicle_1))

GO

