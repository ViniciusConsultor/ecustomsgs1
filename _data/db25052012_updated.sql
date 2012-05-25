USE [dbEcustoms]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_GetFeeAmountByTypeDeclaration]    Script Date: 05/25/2012 09:17:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetFeeAmountByTypeDeclaration]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetFeeAmountByTypeDeclaration]
GO

USE [dbEcustoms]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_GetFeeAmountByTypeDeclaration]    Script Date: 05/25/2012 09:17:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CReate FUNCTION [dbo].[fn_GetFeeAmountByTypeDeclaration] (@exportFeeAmount bigint, @importFeeAmount bigint, @declarationType int)
RETURNS Bigint
WITH EXECUTE AS CALLER
AS
BEGIN
     DECLARE @feeAmount int;
	 IF @declarationType = 0
		SET @feeAmount = @exportFeeAmount
	 ELSE
		SET @feeAmount = @importFeeAmount;
     RETURN @feeAmount;
END;


GO


ALTER VIEW [dbo].[ViewVehicleFreight]
AS
SELECT DISTINCT 
                      dbo.tblVehicle.VehicleID, dbo.tblVehicle.PlateNumber, dbo.tblVehicle.CreatedDate, dbo.tblVehicle.vehicleTypeId, dbo.tblVehicleType.Code, dbo.tblVehicleType.Name, 
                      dbo.tblDeclaration.DeclarationType, dbo.fn_GetGoodTypeIdByTypeDeclaration(dbo.tblVehicle.ExportGoodTypeId, dbo.tblVehicle.ImportGoodTypeId, 
                      dbo.tblDeclaration.DeclarationType) AS GoodTypeName, dbo.fn_GetFeeAmountByTypeDeclaration(dbo.tblVehicle.feeExportAmount, dbo.tblVehicle.feeImportAmount, 
                      dbo.tblDeclaration.DeclarationType) AS FeeAmount
FROM         dbo.tblVehicle INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblVehicle.VehicleID = dbo.tblDeclarationVehicle.VehicleID INNER JOIN
                      dbo.tblDeclaration ON dbo.tblDeclarationVehicle.DeclarationID = dbo.tblDeclaration.DeclarationID INNER JOIN
                      dbo.tblGoodsType ON dbo.tblVehicle.ExportGoodTypeId = dbo.tblGoodsType.TypeId OR dbo.tblVehicle.ImportGoodTypeId = dbo.tblGoodsType.TypeId INNER JOIN
                      dbo.tblVehicleType ON dbo.tblVehicle.vehicleTypeId = dbo.tblVehicleType.VehicleTypeID
WHERE     (dbo.tblDeclaration.DeclarationID > 1)

GO


