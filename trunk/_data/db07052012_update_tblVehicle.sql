use dbECustoms
go

ALTER TABLE dbo.tblVehicle
ALTER COLUMN feeExportStatus int NULL;
Go

ALTER TABLE dbo.tblVehicle
ALTER COLUMN feeImportStatus int NULL;

