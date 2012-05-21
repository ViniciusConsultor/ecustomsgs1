USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewVehicleFee]    Script Date: 05/22/2012 00:18:08 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewVehicleFee]'))
DROP VIEW [dbo].[ViewVehicleFee]
GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[ViewVehicleFee]    Script Date: 05/22/2012 00:18:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewVehicleFee]
AS
SELECT     table1.VehicleID, table1.PlateNumber, table1.FeeReceiptNumber, table1.FeeAmount, table1.DeclarationID, table1.Number, table1.Type, table1.ProductName, 
                      table1.ExportDate, table1.ImportedLocalTime, table1.VehicleTypeName, table1.FeeDate, table1.FeeType, table1.FeeTypeID, table2.VehicleIdTmp, 
                      table2.maxDeclarationID
FROM         (SELECT     VehicleID, PlateNumber, ExportReceiptNumber AS FeeReceiptNumber, feeExportAmount AS FeeAmount, DeclarationID, Number, Type, ProductName, 
                                              ExportDate, ImportedLocalTime, Name AS VehicleTypeName, feeExportDate AS FeeDate, N'Xuất cảnh' AS FeeType, 1 AS FeeTypeID
                       FROM          dbo.ViewAllVehicleHasGood
                       WHERE      (feeExportStatus = 2)
                       UNION
                       SELECT     VehicleID, PlateNumber, ImportReceiptNumber AS FeeReceiptNumber, feeImportAmount AS FeeAmount, DeclarationID, Number, Type, ProductName, 
                                             ExportDate, ImportedLocalTime, Name AS VehicleTypeName, feeImportDate AS FeeDate, N'Nhập cảnh' AS FeeType, 2 AS FeeTypeID
                       FROM         dbo.ViewAllVehicleHasGood AS ViewAllVehicleHasGood_2
                       WHERE     (feeImportStatus = 2)) AS table1 INNER JOIN
                          (SELECT     VehicleID AS VehicleIdTmp, MAX(DeclarationID) AS maxDeclarationID
                            FROM          dbo.ViewAllVehicleHasGood AS ViewAllVehicleHasGood_1
                            WHERE      (1 = 1)
                            GROUP BY VehicleID) AS table2 ON table1.VehicleID = table2.VehicleIdTmp AND table1.DeclarationID = table2.maxDeclarationID

GO

