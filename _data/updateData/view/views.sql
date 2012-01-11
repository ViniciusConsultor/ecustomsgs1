USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewUserGroup]    Script Date: 09/28/2011 00:43:26 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewUserGroup]'))
DROP VIEW [dbo].[ViewUserGroup]
GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewUserGroup]    Script Date: 09/28/2011 00:43:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewUserGroup]
AS					  
SELECT     dbo.tblUser.UserID, dbo.tblUser.Name AS UserFullName, dbo.tblUser.UserName, dbo.tblUser.Address, dbo.tblUser.Email, dbo.tblUser.PhoneNumber, 
                      dbo.tblGroup.GroupID, dbo.tblGroup.GroupName
FROM         dbo.tblUser INNER JOIN
                      dbo.tblUserInGroup ON dbo.tblUser.UserID = dbo.tblUserInGroup.UserID INNER JOIN
                      dbo.tblGroup ON dbo.tblUserInGroup.GroupID = dbo.tblGroup.GroupID
					  
GO

/****** Object:  View [dbo].[ViewAllCheckResult]    Script Date: 10/05/2011 00:45:48 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewAllCheckResult]'))
DROP VIEW [dbo].[ViewAllCheckResult]
GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewAllCheckResult]    Script Date: 10/10/2011 23:16:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewAllCheckResult]
AS
SELECT     dbo.tblVehicleCheck.VehicleCheckID, dbo.tblVehicleCheck.VehicleID, dbo.tblVehicleCheck.InputBy, dbo.tblVehicleCheck.RecievedBy, dbo.tblVehicleCheck.CreatedDate, 
                      dbo.tblVehicleCheck.[Content], dbo.tblVehicleCheck.Result, dbo.tblVehicleCheck.CheckFrom, dbo.tblVehicleCheck.CheckTo, 
                      dbo.fn_GetNameById(dbo.tblVehicleCheck.InputBy) AS InputByName, dbo.fn_GetNameById(dbo.tblVehicleCheck.RecievedBy) AS RecievedByName, 
                      dbo.fn_GetNameById(dbo.tblVehicleCheck.CheckBy) AS CheckByName, dbo.ViewAllVehicleHasGood.Number, dbo.ViewAllVehicleHasGood.CompanyCode, 
                      dbo.ViewAllVehicleHasGood.PlateNumber, dbo.ViewAllVehicleHasGood.DeclarationType, dbo.tblVehicleCheck.CheckCode, dbo.ViewAllVehicleHasGood.ImportDate, 
                      dbo.ViewAllVehicleHasGood.ExportDate
FROM         dbo.tblVehicleCheck INNER JOIN
                      dbo.ViewAllVehicleHasGood ON dbo.tblVehicleCheck.VehicleID = dbo.ViewAllVehicleHasGood.VehicleID

GO

GO

/****** Object:  View [dbo].[viewDeclarationVehicle]    Script Date: 10/16/2011 23:09:06 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[viewDeclarationVehicle]'))
DROP VIEW [dbo].[viewDeclarationVehicle]
GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[viewDeclarationVehicle]    Script Date: 10/16/2011 23:09:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[viewDeclarationVehicle]
AS
SELECT     dbo.tblDeclarationVehicle.DeclarationID, dbo.tblDeclarationVehicle.VehicleID, dbo.tblDeclaration.Number, dbo.tblVehicle.PlateNumber, 
                      dbo.tblVehicle.NumberOfContainer, dbo.tblVehicle.DriverName, dbo.tblVehicle.ImportDate, dbo.tblVehicle.IsImport, dbo.tblVehicle.ExportDate, dbo.tblVehicle.IsExport, 
                      dbo.tblVehicle.Note, dbo.tblVehicle.Status, dbo.tblVehicle.IsCompleted, dbo.tblVehicle.IsGoodsImported, dbo.tblVehicle.ImportStatus, 
                      dbo.tblVehicle.ImportedLocalTime, dbo.tblVehicle.HasGoodsImported, dbo.tblVehicle.ConfirmImportBy, dbo.tblVehicle.ConfirmExportBy, 
                      dbo.tblVehicle.ConfirmLocalImportBy, dbo.tblVehicle.ModifiedDate, dbo.tblVehicle.Parking, dbo.tblDeclaration.CompanyName, dbo.tblDeclaration.CompanyCode, 
                      dbo.tblDeclaration.DeclarationType, dbo.tblDeclaration.Type, dbo.tblDeclaration.ProductAmount, dbo.tblDeclaration.Unit, dbo.tblDeclaration.ProductName, 
                      dbo.tblDeclaration.RegisterDate
FROM         dbo.tblDeclaration INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblDeclaration.DeclarationID = dbo.tblDeclarationVehicle.DeclarationID INNER JOIN
                      dbo.tblVehicle ON dbo.tblDeclarationVehicle.VehicleID = dbo.tblVehicle.VehicleID

GO

/****** Object:  View [dbo].[ViewAllVehicle]    Script Date: 11/04/2011 23:19:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewAllVehicle]
AS
SELECT     VehicleID, PlateNumber, NumberOfContainer, DriverName, ImportDate, IsImport, ExportDate, IsExport, Note, Status, IsCompleted, IsGoodsImported, ImportStatus, 
                      ImportedLocalTime, HasGoodsImported, ConfirmImportBy, ConfirmExportBy, ConfirmLocalImportBy, dbo.fn_GetNameById(ConfirmExportBy) 
                      AS ConfirmExportByName, dbo.fn_GetNameById(ConfirmImportBy) AS ConfirmImportByName, dbo.fn_GetNameById(ConfirmLocalImportBy) 
                      AS ConfirmLocalImportByName, ModifiedDate, Parking, ParkingDate
FROM         dbo.tblVehicle

GO

/****** Object:  View [dbo].[ViewAllVehicleHasGood]    Script Date: 11/04/2011 23:19:41 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewAllVehicleHasGood]'))
DROP VIEW [dbo].[ViewAllVehicleHasGood]
GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewAllVehicleHasGood]    Script Date: 11/04/2011 23:19:42 ******/
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
                      AS ConfirmLocalImportByName, dbo.tblDeclaration.ConfirmStatus, dbo.tblDeclaration.ConfirmDate, dbo.tblVehicle.Parking, dbo.tblVehicle.ParkingDate
FROM         dbo.tblVehicle INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblVehicle.VehicleID = dbo.tblDeclarationVehicle.VehicleID INNER JOIN
                      dbo.tblDeclaration ON dbo.tblDeclarationVehicle.DeclarationID = dbo.tblDeclaration.DeclarationID
WHERE     (dbo.tblVehicle.VehicleID IN
                          (SELECT     VehicleID
                            FROM          dbo.tblDeclarationVehicle AS tblDeclarationVehicle_1))

GO
					  