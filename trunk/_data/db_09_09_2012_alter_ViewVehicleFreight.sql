USE [dbEcustom]
GO

/****** Object:  View [dbo].[ViewVehicleFreight]    Script Date: 09/09/2012 16:47:19 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewVehicleFreight]'))
DROP VIEW [dbo].[ViewVehicleFreight]
GO

USE [dbEcustom]
GO

/****** Object:  View [dbo].[ViewVehicleFreight]    Script Date: 09/09/2012 16:47:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewVehicleFreight]
AS
SELECT DISTINCT 
                      dbo.tblVehicle.VehicleID, dbo.tblVehicle.PlateNumber, dbo.tblVehicle.CreatedDate, dbo.tblVehicle.vehicleTypeId, dbo.tblVehicleType.Code, dbo.tblVehicleType.Name, 
                      dbo.tblDeclaration.DeclarationType, dbo.fn_GetGoodTypeIdByTypeDeclaration(dbo.tblVehicle.ExportGoodTypeId, dbo.tblVehicle.ImportGoodTypeId, 
                      dbo.tblDeclaration.DeclarationType) AS GoodTypeName, dbo.fn_GetFeeAmountByTypeDeclaration(dbo.tblVehicle.feeExportAmount, dbo.tblVehicle.feeImportAmount, 
                      dbo.tblDeclaration.DeclarationType) AS FeeAmount, dbo.tblDeclaration.BranchId
FROM         dbo.tblVehicle INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblVehicle.VehicleID = dbo.tblDeclarationVehicle.VehicleID INNER JOIN
                      dbo.tblDeclaration ON dbo.tblDeclarationVehicle.DeclarationID = dbo.tblDeclaration.DeclarationID INNER JOIN
                      dbo.tblGoodsType ON dbo.tblVehicle.ExportGoodTypeId = dbo.tblGoodsType.TypeId OR dbo.tblVehicle.ImportGoodTypeId = dbo.tblGoodsType.TypeId INNER JOIN
                      dbo.tblVehicleType ON dbo.tblVehicle.vehicleTypeId = dbo.tblVehicleType.VehicleTypeID
WHERE     (dbo.tblDeclaration.DeclarationID > 1)

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblVehicle"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 306
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblDeclarationVehicle"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblDeclaration"
            Begin Extent = 
               Top = 126
               Left = 236
               Bottom = 245
               Right = 451
            End
            DisplayFlags = 280
            TopColumn = 37
         End
         Begin Table = "tblGoodsType"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 365
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblVehicleType"
            Begin Extent = 
               Top = 246
               Left = 236
               Bottom = 365
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewVehicleFreight'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewVehicleFreight'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewVehicleFreight'
GO


