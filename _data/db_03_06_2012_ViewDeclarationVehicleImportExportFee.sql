USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewDeclarationVechicleExport]    Script Date: 06/03/2012 19:00:29 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewDeclarationVechicleExport]'))
DROP VIEW [dbo].[ViewDeclarationVechicleExport]
GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewDeclarationVechicleExport]    Script Date: 06/03/2012 19:00:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewDeclarationVechicleExport]
AS
SELECT     tblDeclaration_1.DeclarationID, tblDeclaration_1.Number AS DeclarationExportNumber, tblDeclaration_1.Type AS DeclarationExportType, 
                      tblDeclaration_1.DeclarationType, dbo.tblVehicle.VehicleID, dbo.tblVehicle.PlateNumber, dbo.tblVehicle.NumberOfContainer, dbo.tblVehicle.DriverName, 
                      dbo.tblVehicle.ImportDate, dbo.tblVehicle.IsImport, dbo.tblVehicle.ExportDate, dbo.tblVehicle.IsExport, dbo.tblVehicle.Note, dbo.tblVehicle.Status, 
                      dbo.tblVehicle.IsCompleted, dbo.tblVehicle.IsGoodsImported, dbo.tblVehicle.ImportStatus, dbo.tblVehicle.ImportedLocalTime, dbo.tblVehicle.HasGoodsImported, 
                      dbo.tblVehicle.ConfirmImportBy, dbo.tblVehicle.ConfirmExportBy, dbo.tblVehicle.ConfirmLocalImportBy, dbo.tblVehicle.ModifiedDate, dbo.tblVehicle.Parking, 
                      dbo.tblVehicle.ParkingDate, dbo.tblVehicle.HasGoodsImportedTocalPrint, dbo.tblVehicle.ParkingTotalPrint, dbo.tblVehicle.HasGoodsImportedPrintOrderNumber, 
                      dbo.tblVehicle.ParkingTotalPrintOrderNumber, dbo.tblVehicle.IsChineseVehicle, dbo.tblVehicle.IsExportParking, dbo.tblVehicle.ExportParkingDate, 
                      dbo.tblVehicle.ConfirmExportParkingBy, dbo.tblVehicle.PlateNumberPartner, dbo.tblVehicle.vehicleTypeId, dbo.tblVehicle.quantityExport, dbo.tblVehicle.quantityImport, 
                      dbo.tblVehicle.feeExportStatus, dbo.tblVehicle.feeExportAmount, dbo.tblVehicle.feeImportStatus, dbo.tblVehicle.feeImportAmount, dbo.tblVehicle.feeExportDate, 
                      dbo.tblVehicle.feeImportDate, dbo.tblVehicle.confirmFeeExportBy, dbo.tblVehicle.confirmFeeImportBy, dbo.tblVehicle.ExportReceiptNumber, 
                      dbo.tblVehicle.ImportReceiptNumber, dbo.tblVehicle.CreatedDate, dbo.tblVehicle.ExportGoodTypeId, dbo.tblVehicle.ImportGoodTypeId, 
                      dbo.tblGoodsType.TypeName AS ExportGoodsTypeName, dbo.tblVehicleType.Name AS VehicleTypeName, tblUser_1.Name AS ConfirmFeeExportByUserName, 
                      dbo.tblUser.Name AS ConfirmExportByName
FROM         dbo.tblUser RIGHT OUTER JOIN
                      dbo.tblVehicle ON dbo.tblUser.UserID = dbo.tblVehicle.ConfirmExportBy LEFT OUTER JOIN
                      dbo.tblUser AS tblUser_1 ON dbo.tblVehicle.confirmFeeExportBy = tblUser_1.UserID LEFT OUTER JOIN
                      dbo.tblGoodsType ON dbo.tblVehicle.ExportGoodTypeId = dbo.tblGoodsType.TypeId LEFT OUTER JOIN
                      dbo.tblVehicleType ON dbo.tblVehicle.vehicleTypeId = dbo.tblVehicleType.VehicleTypeID LEFT OUTER JOIN
                      dbo.tblDeclarationVehicle LEFT OUTER JOIN
                      dbo.tblDeclaration AS tblDeclaration_1 ON dbo.tblDeclarationVehicle.DeclarationID = tblDeclaration_1.DeclarationID ON 
                      dbo.tblVehicle.VehicleID = dbo.tblDeclarationVehicle.VehicleID
WHERE     (tblDeclaration_1.DeclarationType = 0)

GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewDeclarationVehicleImport]    Script Date: 06/03/2012 19:00:49 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewDeclarationVehicleImport]'))
DROP VIEW [dbo].[ViewDeclarationVehicleImport]
GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewDeclarationVehicleImport]    Script Date: 06/03/2012 19:00:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewDeclarationVehicleImport]
AS
SELECT     tblDeclaration_1.DeclarationID, tblDeclaration_1.Type AS DeclarationImportType, tblDeclaration_1.DeclarationType, dbo.tblVehicle.VehicleID, 
                      dbo.tblVehicle.PlateNumber, dbo.tblVehicle.NumberOfContainer, dbo.tblVehicle.DriverName, dbo.tblVehicle.ImportDate, dbo.tblVehicle.IsImport, 
                      dbo.tblVehicle.ExportDate, dbo.tblVehicle.IsExport, dbo.tblVehicle.Note, dbo.tblVehicle.Status, dbo.tblVehicle.IsCompleted, dbo.tblVehicle.IsGoodsImported, 
                      dbo.tblVehicle.ImportStatus, dbo.tblVehicle.ImportedLocalTime, dbo.tblVehicle.HasGoodsImported, dbo.tblVehicle.ConfirmImportBy, dbo.tblVehicle.ConfirmExportBy, 
                      dbo.tblVehicle.ConfirmLocalImportBy, dbo.tblVehicle.ModifiedDate, dbo.tblVehicle.Parking, dbo.tblVehicle.ParkingDate, dbo.tblVehicle.HasGoodsImportedTocalPrint, 
                      dbo.tblVehicle.ParkingTotalPrint, dbo.tblVehicle.HasGoodsImportedPrintOrderNumber, dbo.tblVehicle.ParkingTotalPrintOrderNumber, dbo.tblVehicle.IsChineseVehicle, 
                      dbo.tblVehicle.IsExportParking, dbo.tblVehicle.ExportParkingDate, dbo.tblVehicle.ConfirmExportParkingBy, dbo.tblVehicle.PlateNumberPartner, 
                      dbo.tblVehicle.vehicleTypeId, dbo.tblVehicle.quantityExport, dbo.tblVehicle.quantityImport, dbo.tblVehicle.feeExportStatus, dbo.tblVehicle.feeExportAmount, 
                      dbo.tblVehicle.feeImportStatus, dbo.tblVehicle.feeImportAmount, dbo.tblVehicle.feeExportDate, dbo.tblVehicle.feeImportDate, dbo.tblVehicle.confirmFeeExportBy, 
                      dbo.tblVehicle.confirmFeeImportBy, dbo.tblVehicle.ExportReceiptNumber, dbo.tblVehicle.ImportReceiptNumber, dbo.tblVehicle.CreatedDate, 
                      dbo.tblVehicle.ExportGoodTypeId, dbo.tblVehicle.ImportGoodTypeId, dbo.tblVehicleType.Name AS VehicleTypeName, 
                      dbo.tblGoodsType.TypeName AS ImportGoodsTypeName, tblUser_1.Name AS ConfirmFeeImportByUserName, dbo.tblUser.Name AS ConfirmImportByName, 
                      tblDeclaration_1.Number AS DeclarationImportNumber
FROM         dbo.tblUser RIGHT OUTER JOIN
                      dbo.tblVehicle ON dbo.tblUser.UserID = dbo.tblVehicle.ConfirmImportBy LEFT OUTER JOIN
                      dbo.tblUser AS tblUser_1 ON dbo.tblVehicle.confirmFeeImportBy = tblUser_1.UserID LEFT OUTER JOIN
                      dbo.tblGoodsType ON dbo.tblVehicle.ImportGoodTypeId = dbo.tblGoodsType.TypeId LEFT OUTER JOIN
                      dbo.tblVehicleType ON dbo.tblVehicle.vehicleTypeId = dbo.tblVehicleType.VehicleTypeID LEFT OUTER JOIN
                      dbo.tblDeclarationVehicle LEFT OUTER JOIN
                      dbo.tblDeclaration AS tblDeclaration_1 ON dbo.tblDeclarationVehicle.DeclarationID = tblDeclaration_1.DeclarationID ON 
                      dbo.tblVehicle.VehicleID = dbo.tblDeclarationVehicle.VehicleID
WHERE     (tblDeclaration_1.DeclarationType = 1)

GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewDeclarationVehicleImportExportFee]    Script Date: 06/03/2012 19:01:03 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewDeclarationVehicleImportExportFee]'))
DROP VIEW [dbo].[ViewDeclarationVehicleImportExportFee]
GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewDeclarationVehicleImportExportFee]    Script Date: 06/03/2012 19:01:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewDeclarationVehicleImportExportFee]
AS
SELECT     dbo.tblVehicle.VehicleID, dbo.tblVehicle.PlateNumber, dbo.tblVehicle.NumberOfContainer, dbo.tblVehicle.DriverName, dbo.tblVehicle.ImportDate, 
                      dbo.tblVehicle.IsImport, dbo.tblVehicle.ExportDate, dbo.tblVehicle.IsExport, dbo.tblVehicle.Note, dbo.tblVehicle.Status, dbo.tblVehicle.IsCompleted, 
                      dbo.tblVehicle.IsGoodsImported, dbo.tblVehicle.ImportStatus, dbo.tblVehicle.ImportedLocalTime, dbo.tblVehicle.HasGoodsImported, dbo.tblVehicle.ConfirmImportBy, 
                      dbo.tblVehicle.ConfirmExportBy, dbo.tblVehicle.ConfirmLocalImportBy, dbo.tblVehicle.DeclarationType, dbo.tblVehicle.ModifiedDate, dbo.tblVehicle.Parking, 
                      dbo.tblVehicle.ParkingDate, dbo.tblVehicle.HasGoodsImportedTocalPrint, dbo.tblVehicle.ParkingTotalPrint, dbo.tblVehicle.HasGoodsImportedPrintOrderNumber, 
                      dbo.tblVehicle.ParkingTotalPrintOrderNumber, dbo.tblVehicle.IsChineseVehicle, dbo.tblVehicle.IsExportParking, dbo.tblVehicle.ExportParkingDate, 
                      dbo.tblVehicle.ConfirmExportParkingBy, dbo.tblVehicle.PlateNumberPartner, dbo.tblVehicle.vehicleTypeId, dbo.tblVehicle.quantityExport, dbo.tblVehicle.quantityImport, 
                      dbo.tblVehicle.feeExportStatus, dbo.tblVehicle.feeImportStatus, dbo.tblVehicle.feeExportAmount, dbo.tblVehicle.feeImportAmount, dbo.tblVehicle.feeExportDate, 
                      dbo.tblVehicle.feeImportDate, dbo.tblVehicle.confirmFeeExportBy, dbo.tblVehicle.confirmFeeImportBy, dbo.tblVehicle.ExportReceiptNumber, 
                      dbo.tblVehicle.ImportReceiptNumber, dbo.tblVehicle.CreatedDate, dbo.tblVehicle.ExportGoodTypeId, dbo.tblVehicle.ImportGoodTypeId, 
                      dbo.ViewDeclarationVechicleExport.DeclarationExportNumber, dbo.ViewDeclarationVechicleExport.DeclarationExportType, 
                      dbo.ViewDeclarationVechicleExport.ExportGoodsTypeName, dbo.ViewDeclarationVechicleExport.VehicleTypeName, 
                      dbo.ViewDeclarationVehicleImport.DeclarationImportNumber, dbo.ViewDeclarationVehicleImport.DeclarationImportType, 
                      dbo.ViewDeclarationVehicleImport.ImportGoodsTypeName, dbo.ViewDeclarationVechicleExport.ConfirmFeeExportByUserName, 
                      dbo.ViewDeclarationVehicleImport.ConfirmFeeImportByUserName, dbo.ViewDeclarationVehicleImport.ConfirmImportByName, 
                      dbo.ViewDeclarationVechicleExport.ConfirmExportByName
FROM         dbo.tblVehicle LEFT OUTER JOIN
                      dbo.ViewDeclarationVehicleImport ON dbo.tblVehicle.VehicleID = dbo.ViewDeclarationVehicleImport.VehicleID LEFT OUTER JOIN
                      dbo.ViewDeclarationVechicleExport ON dbo.tblVehicle.VehicleID = dbo.ViewDeclarationVechicleExport.VehicleID

GO