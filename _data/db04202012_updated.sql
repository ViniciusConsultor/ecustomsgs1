USE [dbECustoms]
/*Comment this section because can not run it*/
/*
GO
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (39, N'Nhập phương tiện vào bãi xuất')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (40, N'Nhập phương tiện xe Trung Quốc')
*/
go

IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewAllVehicleHasGood]'))
DROP VIEW [dbo].[ViewAllVehicleHasGood]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewAllVehicleHasGood]
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
                      dbo.tblVehicle.ConfirmExportParkingBy, dbo.tblVehicle.PlateNumberPartner, dbo.tblVehicle.IsChineseVehicle
FROM         dbo.tblVehicle INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblVehicle.VehicleID = dbo.tblDeclarationVehicle.VehicleID INNER JOIN
                      dbo.tblDeclaration ON dbo.tblDeclarationVehicle.DeclarationID = dbo.tblDeclaration.DeclarationID
WHERE     (dbo.tblVehicle.VehicleID IN
                          (SELECT     VehicleID
                            FROM          dbo.tblDeclarationVehicle AS tblDeclarationVehicle_1))

GO



IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewAllVehicle]'))
DROP VIEW [dbo].[ViewAllVehicle]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewAllVehicle]
AS
SELECT     VehicleID, PlateNumber, NumberOfContainer, DriverName, ImportDate, IsImport, ExportDate, IsExport, Note, Status, IsCompleted, IsGoodsImported, ImportStatus, 
                      ImportedLocalTime, HasGoodsImported, ConfirmImportBy, ConfirmExportBy, ConfirmLocalImportBy, dbo.fn_GetNameById(ConfirmExportBy) 
                      AS ConfirmExportByName, dbo.fn_GetNameById(ConfirmImportBy) AS ConfirmImportByName, dbo.fn_GetNameById(ConfirmLocalImportBy) 
                      AS ConfirmLocalImportByName, ModifiedDate, Parking, ParkingDate, PlateNumberPartner
FROM         dbo.tblVehicle

GO