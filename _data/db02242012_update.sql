/*
Deployment script for compareEcustoms
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
/* DatabaseName "your Ecustoms db name" */

GO
USE [$(DatabaseName)]

GO
PRINT N'Altering [dbo].[tblDeclaration]...';


GO
ALTER TABLE [dbo].[tblDeclaration] ALTER COLUMN [NumberTemp] NVARCHAR (50) NULL;


GO
PRINT N'Refreshing [dbo].[viewDeclarationVehicle]...';


GO
EXECUTE sp_refreshview N'dbo.viewDeclarationVehicle';


GO
PRINT N'Altering [dbo].[ViewAllVehicleHasGood]...';


GO
ALTER VIEW dbo.ViewAllVehicleHasGood
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
                      dbo.tblDeclaration.Money, dbo.tblDeclaration.DateHandover, dbo.tblDeclaration.Seal, dbo.tblDeclaration.GateExport, dbo.tblDeclaration.DateReturn, 
                      dbo.tblDeclaration.NumberHandover, dbo.tblDeclaration.RegisterPlace, dbo.tblDeclaration.TypeOption, dbo.tblDeclaration.NumberTemp
FROM         dbo.tblVehicle INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblVehicle.VehicleID = dbo.tblDeclarationVehicle.VehicleID INNER JOIN
                      dbo.tblDeclaration ON dbo.tblDeclarationVehicle.DeclarationID = dbo.tblDeclaration.DeclarationID
WHERE     (dbo.tblVehicle.VehicleID IN
                          (SELECT     VehicleID
                            FROM          dbo.tblDeclarationVehicle AS tblDeclarationVehicle_1))
GO
PRINT N'Altering [dbo].[ViewAllDeclaration]...';


GO
ALTER VIEW dbo.ViewAllDeclaration
AS
SELECT     tblUser_1.UserID, tblUser_1.Name, tblUser_1.UserName AS CreatedBy,
                          (SELECT     UserName
                            FROM          dbo.tblUser
                            WHERE      (UserID = dbo.tblDeclaration.ModifiedByID)) AS ModifiedBy, dbo.tblDeclaration.Number, dbo.tblDeclaration.ProductName, 
                      dbo.tblDeclaration.CompanyName, dbo.tblDeclaration.ProductAmount, dbo.tblDeclaration.Unit, dbo.tblDeclaration.CreatedByID, dbo.tblDeclaration.ModifiedByID, 
                      dbo.tblDeclaration.ModifiedDate, dbo.tblDeclaration.CreatedDate, dbo.tblDeclaration.HasDeclaration, dbo.tblDeclaration.Type, dbo.tblDeclaration.CompanyCode, 
                      dbo.tblDeclaration.RegisterDate, dbo.tblDeclaration.DeclarationType, dbo.tblDeclaration.ConfirmStatus, dbo.tblDeclaration.ConfirmDate, 
                      dbo.tblDeclaration.RegisterPlace, dbo.tblDeclaration.Money, dbo.tblDeclaration.NumberHandover, dbo.tblDeclaration.DateHandover, dbo.tblDeclaration.DateReturn, 
                      dbo.tblDeclaration.GateExport, dbo.tblDeclaration.Seal, dbo.tblDeclaration.TypeOption,
                          (SELECT     COUNT(*) AS NumberTotalVehicles
                            FROM          dbo.tblDeclarationVehicle
                            WHERE      (DeclarationID = dbo.tblDeclaration.DeclarationID)) AS NumberTotalVehicles, tblDeclarationVehicle_1.VehicleID, dbo.tblDeclaration.DeclarationID, 
                      dbo.tblDeclaration.NumberTemp
FROM         dbo.tblVehicle INNER JOIN
                      dbo.tblDeclarationVehicle AS tblDeclarationVehicle_1 ON dbo.tblVehicle.VehicleID = tblDeclarationVehicle_1.VehicleID INNER JOIN
                      dbo.tblDeclaration INNER JOIN
                      dbo.tblUser AS tblUser_1 ON dbo.tblDeclaration.CreatedByID = tblUser_1.UserID ON tblDeclarationVehicle_1.DeclarationID = dbo.tblDeclaration.DeclarationID
GO
PRINT N'Refreshing [dbo].[ViewAllCheckResult]...';


GO
EXECUTE sp_refreshview N'dbo.ViewAllCheckResult';


GO
