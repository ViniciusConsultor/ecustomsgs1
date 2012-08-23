use dbECustoms

go

ALTER TABLE dbo.tblDeclaration
ADD NumberTempInfo nvarchar(4000) NULL

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewAllDeclaration]    Script Date: 08/23/2012 23:50:09 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewAllDeclaration]'))
DROP VIEW [dbo].[ViewAllDeclaration]
GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewAllDeclaration]    Script Date: 08/23/2012 23:50:10 ******/
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
                      dbo.tblDeclaration.GateImport, dbo.tblDeclaration.ReceiveNumberInYear, dbo.tblDeclaration.NumberTempInfo
FROM         dbo.tblDeclaration INNER JOIN
                      dbo.tblUser AS tblUser_1 ON dbo.tblDeclaration.CreatedByID = tblUser_1.UserID

GO