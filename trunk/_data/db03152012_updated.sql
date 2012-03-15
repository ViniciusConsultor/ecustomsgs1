/****** Object:  View [dbo].[ViewAllDeclarationTNTX]    Script Date: 03/15/2012 14:48:06 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewAllDeclarationTNTX]'))
DROP VIEW [dbo].[ViewAllDeclarationTNTX]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewAllDeclarationTNTX]
AS
SELECT     dbo.tblDeclaration.DeclarationID, dbo.tblDeclaration.Number, dbo.tblDeclaration.CompanyName, dbo.tblDeclaration.ProductName, dbo.tblDeclaration.ProductAmount, 
                      dbo.tblDeclaration.Unit, dbo.tblDeclaration.CreatedByID, dbo.tblDeclaration.ModifiedByID, dbo.tblDeclaration.ModifiedDate, dbo.tblDeclaration.CreatedDate, 
                      dbo.tblDeclaration.HasDeclaration, dbo.tblDeclaration.Type, dbo.tblDeclaration.CompanyCode, dbo.tblDeclaration.RegisterDate, dbo.tblDeclaration.DeclarationType, 
                      dbo.tblDeclaration.ConfirmStatus, dbo.tblDeclaration.ConfirmDate, dbo.tblDeclaration.RegisterPlace, dbo.tblDeclaration.Money, dbo.tblDeclaration.NumberHandover, 
                      dbo.tblDeclaration.DateHandover, dbo.tblDeclaration.DateReturn, dbo.tblDeclaration.PersonConfirmReturnID, 
                      dbo.fn_GetNameById(dbo.tblDeclaration.PersonConfirmReturnID) AS PersonConfirmReturnName, dbo.tblDeclaration.NumberTemp, dbo.tblDeclaration.GateExport, 
                      dbo.tblDeclaration.TypeOption, dbo.tblDeclaration.Seal, dbo.tblVehicle.VehicleID, dbo.tblVehicle.PlateNumber, dbo.tblVehicle.NumberOfContainer
FROM         dbo.tblDeclaration INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblDeclaration.DeclarationID = dbo.tblDeclarationVehicle.DeclarationID INNER JOIN
                      dbo.tblVehicle ON dbo.tblDeclarationVehicle.VehicleID = dbo.tblVehicle.VehicleID
GO

