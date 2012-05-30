USE [dbEcustoms]
GO

/****** Object:  View [dbo].[ViewVehicleFee]    Script Date: 05/31/2012 03:02:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[ViewVehicleFee]
AS
SELECT     *
FROM         (SELECT     VehicleID, PlateNumber, ExportReceiptNumber AS FeeReceiptNumber, feeExportAmount AS FeeAmount, DeclarationID, Number, Type, ProductName, 
                                              ExportDate, ImportedLocalTime, Name AS VehicleTypeName, feeExportDate AS FeeDate, N'Xuất cảnh' AS FeeType, 1 AS FeeTypeID
                       FROM          dbo.ViewAllVehicleHasGood
                       WHERE      (feeExportStatus = 2)) AS table1 INNER JOIN
                          (SELECT     VehicleID AS VehicleIdTmp, MAX(DeclarationID) AS maxDeclarationID
                            FROM          dbo.ViewAllVehicleHasGood AS ViewAllVehicleHasGood_1
                            WHERE      (DeclarationType = 0)
                            GROUP BY VehicleID) AS table2 ON table1.VehicleID = table2.VehicleIdTmp AND table1.DeclarationID = table2.maxDeclarationID
UNION
SELECT    *
FROM         (SELECT     VehicleID, PlateNumber, ImportReceiptNumber AS FeeReceiptNumber, feeImportAmount AS FeeAmount, DeclarationID, Number, Type, ProductName, 
                                              ExportDate, ImportedLocalTime, Name AS VehicleTypeName, feeImportDate AS FeeDate, N'Nhập cảnh' AS FeeType, 2 AS FeeTypeID
                       FROM          dbo.ViewAllVehicleHasGood AS ViewAllVehicleHasGood_2
                       WHERE      (feeImportStatus = 2)) AS table1 INNER JOIN
                          (SELECT     VehicleID AS VehicleIdTmp, MAX(DeclarationID) AS maxDeclarationID
                            FROM          dbo.ViewAllVehicleHasGood AS ViewAllVehicleHasGood_1
                            WHERE      (DeclarationType = 1)
                            GROUP BY VehicleID) AS table2 ON table1.VehicleID = table2.VehicleIdTmp AND table1.DeclarationID = table2.maxDeclarationID

GO


