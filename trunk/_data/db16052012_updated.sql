USE [dbECustoms]
GO

ALTER TABLE dbo.tblVehicle
DROP COLUMN GoodTypeId

ALTER TABLE dbo.tblVehicle
ADD ExportGoodTypeId int NULL,
	ImportGoodTypeId int NULL
	
ALTER VIEW [dbo].[ViewAllVehicleHasGood]
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
                      dbo.tblVehicle.ConfirmExportParkingBy, dbo.tblVehicle.PlateNumberPartner, dbo.tblVehicle.IsChineseVehicle, dbo.tblVehicleType.Code, dbo.tblVehicleType.Name, 
                      dbo.tblGoodsType.TypeName AS ExportGoodTypeName, dbo.tblVehicle.quantityExport, dbo.tblVehicle.quantityImport, dbo.tblVehicle.feeExportStatus, 
                      dbo.tblVehicle.feeImportStatus, dbo.tblVehicle.feeExportAmount, dbo.tblVehicle.feeImportAmount, dbo.tblVehicle.feeExportDate, dbo.tblVehicle.feeImportDate, 
                      dbo.tblVehicle.confirmFeeExportBy, dbo.tblVehicle.confirmFeeImportBy, dbo.tblVehicle.ExportReceiptNumber, dbo.tblVehicle.ImportReceiptNumber, 
                      dbo.tblVehicle.CreatedDate AS CreatedDateVehicle, dbo.tblVehicleType.Capacity, dbo.tblVehicle.vehicleTypeId, 
                      dbo.fn_GetGoodTypeNameById(dbo.tblVehicle.ImportGoodTypeId) AS ImportGoodTypeName, dbo.tblVehicle.ExportGoodTypeId, dbo.tblVehicle.ImportGoodTypeId
FROM         dbo.tblVehicle INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblVehicle.VehicleID = dbo.tblDeclarationVehicle.VehicleID INNER JOIN
                      dbo.tblDeclaration ON dbo.tblDeclarationVehicle.DeclarationID = dbo.tblDeclaration.DeclarationID LEFT OUTER JOIN
                      dbo.tblGoodsType ON dbo.tblVehicle.ExportGoodTypeId = dbo.tblGoodsType.TypeId LEFT OUTER JOIN
                      dbo.tblVehicleType ON dbo.tblVehicle.vehicleTypeId = dbo.tblVehicleType.VehicleTypeID
WHERE     (dbo.tblVehicle.VehicleID IN
                          (SELECT     VehicleID
                            FROM          dbo.tblDeclarationVehicle AS tblDeclarationVehicle_1))

GO

ALTER VIEW [dbo].[ViewVehicleFreight]
AS
SELECT DISTINCT 
                      dbo.tblVehicle.VehicleID, dbo.tblVehicle.PlateNumber, dbo.tblVehicle.CreatedDate, dbo.tblVehicle.vehicleTypeId, dbo.tblVehicleType.Code, dbo.tblVehicleType.Name, 
                      dbo.tblVehicle.feeExportAmount, dbo.tblVehicle.feeImportAmount, dbo.tblDeclaration.DeclarationType, 
                      dbo.fn_GetGoodTypeIdByTypeDeclaration(dbo.tblVehicle.ExportGoodTypeId, dbo.tblVehicle.ImportGoodTypeId, dbo.tblDeclaration.DeclarationType) 
                      AS GoodTypeName
FROM         dbo.tblVehicle INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblVehicle.VehicleID = dbo.tblDeclarationVehicle.VehicleID INNER JOIN
                      dbo.tblDeclaration ON dbo.tblDeclarationVehicle.DeclarationID = dbo.tblDeclaration.DeclarationID INNER JOIN
                      dbo.tblGoodsType ON dbo.tblVehicle.ExportGoodTypeId = dbo.tblGoodsType.TypeId OR dbo.tblVehicle.ImportGoodTypeId = dbo.tblGoodsType.TypeId INNER JOIN
                      dbo.tblVehicleType ON dbo.tblVehicle.vehicleTypeId = dbo.tblVehicleType.VehicleTypeID
WHERE     (dbo.tblDeclaration.DeclarationID > 1)

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetGoodTypeIdByTypeDeclaration]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetGoodTypeIdByTypeDeclaration]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_GetGoodTypeIdByTypeDeclaration] (@exportGoodTypeId int, @importGoodTypeId int, @declarationType int)
RETURNS NVARCHAR(500)
WITH EXECUTE AS CALLER
AS
BEGIN
     DECLARE @goodTypeId int;
	 IF @declarationType = 0
		SET @goodTypeId = @exportGoodTypeId
	 ELSE
		SET @goodTypeId = @importGoodTypeId;
	 DECLARE @Name NVARCHAR(500);
		SELECT @Name = TypeName FROM tblGoodsType as a WHERE a.TypeId = @goodTypeId
     RETURN(@Name);
END;

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetGoodTypeNameById]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetGoodTypeNameById]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_GetGoodTypeNameById] (@goodTypeId int)
RETURNS NVARCHAR(500)
WITH EXECUTE AS CALLER
AS
BEGIN
     DECLARE @Name NVARCHAR(500);
		SELECT @Name = TypeName FROM tblGoodsType as a WHERE a.TypeId = @goodTypeId
     RETURN(@Name);
END;

GO