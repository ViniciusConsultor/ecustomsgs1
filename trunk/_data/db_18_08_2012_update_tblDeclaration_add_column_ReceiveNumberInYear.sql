use dbECustoms

go

ALTER TABLE dbo.tblDeclaration
ADD ReceiveNumberInYear bigint NULL

go

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewAllDeclarationTNTX]    Script Date: 08/18/2012 01:01:27 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewAllDeclarationTNTX]'))
DROP VIEW [dbo].[ViewAllDeclarationTNTX]
GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewAllDeclarationTNTX]    Script Date: 08/18/2012 01:01:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewAllDeclarationTNTX]
AS
SELECT     dbo.tblDeclaration.DeclarationID, dbo.tblDeclaration.Number, dbo.tblDeclaration.CompanyName, dbo.tblDeclaration.ProductName, dbo.tblDeclaration.ProductAmount, 
                      dbo.tblDeclaration.Unit, dbo.tblDeclaration.CreatedByID, dbo.fn_GetNameById(dbo.tblDeclaration.CreatedByID) AS CreatedByName, dbo.tblDeclaration.ModifiedByID, 
                      dbo.tblDeclaration.ModifiedDate, dbo.tblDeclaration.CreatedDate, dbo.tblDeclaration.HasDeclaration, dbo.tblDeclaration.Type, dbo.tblDeclaration.CompanyCode, 
                      dbo.tblDeclaration.RegisterDate, dbo.tblDeclaration.DeclarationType, dbo.tblDeclaration.ConfirmStatus, dbo.tblDeclaration.ConfirmDate, 
                      dbo.tblDeclaration.RegisterPlace, dbo.tblDeclaration.Money, dbo.tblDeclaration.NumberHandover, dbo.tblDeclaration.DateHandover, dbo.tblDeclaration.DateReturn, 
                      dbo.tblDeclaration.PersonConfirmReturnID, dbo.fn_GetNameById(dbo.tblDeclaration.PersonConfirmReturnID) AS PersonConfirmReturnName, 
                      dbo.tblDeclaration.NumberTemp, dbo.tblDeclaration.GateExport, dbo.tblDeclaration.TypeOption, dbo.tblDeclaration.Seal, dbo.tblVehicle.VehicleID, 
                      dbo.tblVehicle.PlateNumber, dbo.tblVehicle.NumberOfContainer, dbo.tblVehicle.IsExport, dbo.fn_GetStatusExportByDeclarationId(dbo.tblDeclaration.DeclarationID, 
                      dbo.tblDeclaration.TypeOption) AS StatusExport, dbo.tblDeclaration.PersonHandoverID, dbo.fn_GetNameById(dbo.tblDeclaration.PersonHandoverID) 
                      AS PersonHandoverName, dbo.tblDeclaration.ReceiveNumberInYear
FROM         dbo.tblDeclaration INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblDeclaration.DeclarationID = dbo.tblDeclarationVehicle.DeclarationID INNER JOIN
                      dbo.tblVehicle ON dbo.tblDeclarationVehicle.VehicleID = dbo.tblVehicle.VehicleID

GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewAllDeclaration]    Script Date: 08/18/2012 01:01:44 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewAllDeclaration]'))
DROP VIEW [dbo].[ViewAllDeclaration]
GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewAllDeclaration]    Script Date: 08/18/2012 01:01:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewAllDeclaration]
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
                            WHERE      (DeclarationID = dbo.tblDeclaration.DeclarationID)) AS NumberTotalVehicles, dbo.tblDeclaration.DeclarationID, dbo.tblDeclaration.NumberTemp,
                          (SELECT     UserName
                            FROM          dbo.tblUser AS tblUser_2
                            WHERE      (UserID = dbo.tblDeclaration.PersonConfirmReturnID)) AS PersonConfirmReturnName, dbo.tblDeclaration.PersonHandoverID, 
                      dbo.tblDeclaration.PersonConfirmReturnID, dbo.fn_GetNameById(dbo.tblDeclaration.PersonHandoverID) AS PersonHandoverName, dbo.tblDeclaration.CustomsCode, 
                      dbo.tblDeclaration.GateImport, dbo.tblDeclaration.ReceiveNumberInYear
FROM         dbo.tblDeclaration INNER JOIN
                      dbo.tblUser AS tblUser_1 ON dbo.tblDeclaration.CreatedByID = tblUser_1.UserID

GO