USE [dbEcustom]
GO

ALTER TABLE dbo.tblVehicle ADD
	StatusChangeGood tinyint NULL
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblVehicleChange]') AND type in (N'U'))
DROP TABLE [dbo].[tblVehicleChange]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblVehicleChange](
	[VehicleChangeID] [bigint] IDENTITY(1,1) NOT NULL,
	[VehicleFromID] [bigint] NULL,
	[VehicleToID] [bigint] NULL,
	[BranchId] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_tblVehicleChange] PRIMARY KEY CLUSTERED 
(
	[VehicleChangeID] ASC,
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



ALTER VIEW [dbo].[ViewAllVehicle]
AS
SELECT     VehicleID, PlateNumber, NumberOfContainer, DriverName, ImportDate, IsImport, ExportDate, IsExport, Note, Status, IsCompleted, IsGoodsImported, ImportStatus, 
                      ImportedLocalTime, HasGoodsImported, ConfirmImportBy, ConfirmExportBy, ConfirmLocalImportBy, dbo.fn_GetNameById(ConfirmExportBy) 
                      AS ConfirmExportByName, dbo.fn_GetNameById(ConfirmImportBy) AS ConfirmImportByName, dbo.fn_GetNameById(ConfirmLocalImportBy) 
                      AS ConfirmLocalImportByName, ModifiedDate, Parking, ParkingDate, PlateNumberPartner, dbo.fn_GetNameById(ModifiedById) AS ModifiedByUserName, 
                      StatusChangeGood
FROM         dbo.tblVehicle

GO


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
                      dbo.fn_GetGoodTypeNameById(dbo.tblVehicle.ImportGoodTypeId) AS ImportGoodTypeName, dbo.tblVehicle.ExportGoodTypeId, dbo.tblVehicle.ImportGoodTypeId, 
                      dbo.tblVehicle.CreatedById AS VehicleCreatedById, dbo.tblVehicle.ModifiedById AS VehicleModifiedById, dbo.fn_GetNameById(dbo.tblVehicle.CreatedById) 
                      AS CreatedByUserName, dbo.fn_GetNameById(dbo.tblVehicle.ModifiedById) AS ModifiedByUserName, dbo.tblVehicle.BranchId, 
                      dbo.tblVehicle.StatusChangeGood
FROM         dbo.tblVehicle INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblVehicle.VehicleID = dbo.tblDeclarationVehicle.VehicleID INNER JOIN
                      dbo.tblDeclaration ON dbo.tblDeclarationVehicle.DeclarationID = dbo.tblDeclaration.DeclarationID LEFT OUTER JOIN
                      dbo.tblGoodsType ON dbo.tblVehicle.ExportGoodTypeId = dbo.tblGoodsType.TypeId LEFT OUTER JOIN
                      dbo.tblVehicleType ON dbo.tblVehicle.vehicleTypeId = dbo.tblVehicleType.VehicleTypeID
WHERE     (dbo.tblVehicle.VehicleID IN
                          (SELECT     VehicleID
                            FROM          dbo.tblDeclarationVehicle AS tblDeclarationVehicle_1))

GO

