USE [eCustoms]
GO

/****** Object:  View [dbo].[ViewAllDeclarationTNTX]    Script Date: 03/15/2012 09:18:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewAllDeclarationTNTX]
AS
SELECT     dbo.tblDeclaration.DeclarationID, dbo.tblDeclaration.Number, dbo.tblDeclaration.CompanyName, dbo.tblDeclaration.ProductName, dbo.tblDeclaration.ProductAmount, 
                      dbo.tblDeclaration.Unit, dbo.tblDeclaration.CreatedByID, dbo.tblDeclaration.ModifiedByID, dbo.tblDeclaration.ModifiedDate, dbo.tblDeclaration.CreatedDate, 
                      dbo.tblDeclaration.HasDeclaration, dbo.tblDeclaration.Type, dbo.tblDeclaration.CompanyCode, dbo.tblDeclaration.RegisterDate, dbo.tblDeclaration.DeclarationType, 
                      dbo.tblDeclaration.ConfirmStatus, dbo.tblDeclaration.ConfirmDate, dbo.tblDeclaration.RegisterPlace, dbo.tblDeclaration.Money, dbo.tblDeclaration.NumberHandover, 
                      dbo.tblDeclaration.DateHandover, dbo.tblDeclaration.DateReturn, dbo.tblDeclaration.PersonConfirmReturnID, 
                      dbo.fn_GetNameById(dbo.tblDeclaration.PersonConfirmReturnID) AS PersonConfirmReturnName, dbo.tblDeclaration.NumberTemp, dbo.tblDeclaration.GateExport, 
                      dbo.tblDeclaration.TypeOption, dbo.tblDeclaration.Seal, dbo.tblVehicle.VehicleID, dbo.tblVehicle.PlateNumber, dbo.tblVehicle.NumberOfContainer
FROM         dbo.tblDeclaration INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblDeclaration.DeclarationID = dbo.tblDeclarationVehicle.DeclarationID INNER JOIN
                      dbo.tblVehicle ON dbo.tblDeclarationVehicle.VehicleID = dbo.tblVehicle.VehicleID

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[19] 2[22] 3) )"
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
         Begin Table = "tblDeclaration"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 224
               Right = 241
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblDeclarationVehicle"
            Begin Extent = 
               Top = 6
               Left = 279
               Bottom = 95
               Right = 439
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblVehicle"
            Begin Extent = 
               Top = 6
               Left = 477
               Bottom = 205
               Right = 745
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
         Column = 6480
         Alias = 2460
         Table = 2460
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewAllDeclarationTNTX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewAllDeclarationTNTX'
GO


