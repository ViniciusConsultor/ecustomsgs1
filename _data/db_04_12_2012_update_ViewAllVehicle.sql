USE [dbEcustom]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[ViewAllVehicle]
AS
SELECT     VehicleID, PlateNumber, NumberOfContainer, DriverName, ImportDate, IsImport, ExportDate, IsExport, Note, Status, IsCompleted, IsGoodsImported, ImportStatus, 
                      ImportedLocalTime, HasGoodsImported, ConfirmImportBy, ConfirmExportBy, ConfirmLocalImportBy, dbo.fn_GetNameById(ConfirmExportBy) 
                      AS ConfirmExportByName, dbo.fn_GetNameById(ConfirmImportBy) AS ConfirmImportByName, dbo.fn_GetNameById(ConfirmLocalImportBy) 
                      AS ConfirmLocalImportByName, ModifiedDate, Parking, ParkingDate, PlateNumberPartner, dbo.fn_GetNameById(ModifiedById) AS ModifiedByUserName, 
                      StatusChangeGood, BranchId
FROM         dbo.tblVehicle

GO


