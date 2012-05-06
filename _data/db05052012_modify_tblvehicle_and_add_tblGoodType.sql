use dbECustoms

go
/*Modify tblVehicle*/

ALTER TABLE dbo.tblVehicle
ADD ExportReceiptNumber varchar(100) NULL,
	ImportReceiptNumber  varchar(100) NULL,
	GoodTypeId int NULL
	
	
GO

/****** Object:  Table [dbo].[tblGoodsType]    Script Date: 05/05/2012 22:49:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblGoodsType]') AND type in (N'U'))
DROP TABLE [dbo].[tblGoodsType]
GO


/****** Object:  Table [dbo].[tblGoodsType]    Script Date: 05/05/2012 22:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblGoodsType](
	[TypeId] [int] NOT NULL,
	[TypeName] [nvarchar](500) NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_tblGoodsType] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*Init data for tblGoodsType*/
Delete from tblGoodsType;
Insert into tblGoodsType values (1, N'Hàng thông thường','');
Insert into tblGoodsType values (2, N'Quặng xuất khẩu','');
Insert into tblGoodsType values (3, N'Rau-Củ-Quả tươi','');
Insert into tblGoodsType values (4, N'Xe sang tải','');
Insert into tblGoodsType values (5, N'Hàng TNTX','');

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewAllVehicleHasGood]    Script Date: 05/05/2012 23:41:05 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewAllVehicleHasGood]'))
DROP VIEW [dbo].[ViewAllVehicleHasGood]
GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewAllVehicleHasGood]    Script Date: 05/05/2012 23:41:05 ******/
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
                      dbo.tblVehicle.ConfirmExportParkingBy, dbo.tblVehicle.PlateNumberPartner, dbo.tblVehicle.IsChineseVehicle, dbo.tblVehicle.vehicleTypeId, dbo.tblVehicleType.Code, 
                      dbo.tblVehicleType.Name, dbo.tblVehicleType.FeePrice, dbo.tblVehicle.GoodTypeId, dbo.tblGoodsType.TypeName, dbo.tblVehicle.quantityExport, 
                      dbo.tblVehicle.quantityImport, dbo.tblVehicle.feeExportStatus, dbo.tblVehicle.feeImportStatus, dbo.tblVehicle.feeExportAmount, dbo.tblVehicle.feeImportAmount, 
                      dbo.tblVehicle.feeExportDate, dbo.tblVehicle.feeImportDate, dbo.tblVehicle.confirmFeeExportBy, dbo.tblVehicle.confirmFeeImportBy, 
                      dbo.tblVehicle.ExportReceiptNumber, dbo.tblVehicle.ImportReceiptNumber
FROM         dbo.tblVehicle INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblVehicle.VehicleID = dbo.tblDeclarationVehicle.VehicleID INNER JOIN
                      dbo.tblDeclaration ON dbo.tblDeclarationVehicle.DeclarationID = dbo.tblDeclaration.DeclarationID LEFT OUTER JOIN
                      dbo.tblGoodsType ON dbo.tblVehicle.GoodTypeId = dbo.tblGoodsType.TypeId LEFT OUTER JOIN
                      dbo.tblVehicleType ON dbo.tblVehicle.vehicleTypeId = dbo.tblVehicleType.VehicleTypeID
WHERE     (dbo.tblVehicle.VehicleID IN
                          (SELECT     VehicleID
                            FROM          dbo.tblDeclarationVehicle AS tblDeclarationVehicle_1))

GO