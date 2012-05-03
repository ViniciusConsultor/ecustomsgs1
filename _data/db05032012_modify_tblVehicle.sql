use dbECustoms

go

ALTER TABLE dbo.tblVehicle
ADD vehicleTypeId int NULL,
 quantityExport bigint NULL,
 quantityImport bigint NULL,
 feeExportStatus bit NULL,
 feeImportStatus bit NULL,
 feeExportAmount bigint NULL,
 feeImportAmount bigint NULL,
 feeExportDate datetime NULL,
 feeImportDate datetime NULL,
 confirmFeeExportBy int NULL,
 confirmFeeImportBy int NULL
 