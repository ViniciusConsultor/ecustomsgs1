USE [dbEcustoms]
GO


IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewVehicleFreight]'))
DROP VIEW [dbo].[ViewVehicleFreight]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewVehicleFreight]
AS
SELECT DISTINCT 
                      dbo.tblVehicle.VehicleID, dbo.tblVehicle.PlateNumber, dbo.tblVehicle.CreatedDate, dbo.tblVehicle.vehicleTypeId, dbo.tblVehicleType.Code, dbo.tblVehicleType.Name, 
                      dbo.tblVehicle.GoodTypeId, dbo.tblGoodsType.TypeName, dbo.tblVehicle.feeExportAmount, dbo.tblVehicle.feeImportAmount, dbo.tblDeclaration.DeclarationType
FROM         dbo.tblVehicle INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblVehicle.VehicleID = dbo.tblDeclarationVehicle.VehicleID INNER JOIN
                      dbo.tblDeclaration ON dbo.tblDeclarationVehicle.DeclarationID = dbo.tblDeclaration.DeclarationID INNER JOIN
                      dbo.tblGoodsType ON dbo.tblVehicle.GoodTypeId = dbo.tblGoodsType.TypeId INNER JOIN
                      dbo.tblVehicleType ON dbo.tblVehicle.vehicleTypeId = dbo.tblVehicleType.VehicleTypeID
WHERE     (dbo.tblDeclaration.DeclarationID > 1)

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetGoodTypeNameById]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetGoodTypeNameById]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetVehicleTypeCapacityById]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetVehicleTypeCapacityById]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetVehicleTypeNameById]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetVehicleTypeNameById]
GO