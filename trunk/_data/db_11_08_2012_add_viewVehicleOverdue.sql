USE [dbEcustoms]
GO

/****** Object:  View [dbo].[ViewVehicleOverdue]    Script Date: 08/11/2012 10:35:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewVehicleOverdue]
AS
SELECT     VehicleID, PlateNumber, DriverName, IsImport, IsExport, ExportDate, ImportDate, IsChineseVehicle, IsCompleted
FROM         dbo.tblVehicle

GO
