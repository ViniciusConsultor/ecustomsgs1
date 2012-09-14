USE [dbEcustom]
GO

/****** Object:  View [dbo].[ViewAllDeclarationTNTX]    Script Date: 09/09/2012 16:41:45 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewAllDeclarationTNTX]'))
DROP VIEW [dbo].[ViewAllDeclarationTNTX]
GO

USE [dbEcustom]
GO

/****** Object:  View [dbo].[ViewAllDeclarationTNTX]    Script Date: 09/09/2012 16:41:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewAllDeclarationTNTX]
AS
SELECT     dbo.tblDeclaration.DeclarationID, dbo.tblDeclaration.Number, dbo.tblDeclaration.CompanyName, dbo.tblDeclaration.ProductName, dbo.tblDeclaration.ProductAmount, 
                      dbo.tblDeclaration.Unit, dbo.tblDeclaration.CreatedByID, dbo.fn_GetNameById(dbo.tblDeclaration.CreatedByID) AS CreatedByName, dbo.tblDeclaration.ModifiedByID, 
                      dbo.tblDeclaration.ModifiedDate, dbo.tblDeclaration.CreatedDate, dbo.tblDeclaration.HasDeclaration, dbo.tblDeclaration.Type, dbo.tblDeclaration.CompanyCode, 
                      dbo.tblDeclaration.RegisterDate, dbo.tblDeclaration.DeclarationType, dbo.tblDeclaration.ConfirmStatus, dbo.tblDeclaration.ConfirmDate, 
                      dbo.tblDeclaration.RegisterPlace, dbo.tblDeclaration.Money, dbo.tblDeclaration.NumberHandover, dbo.tblDeclaration.DateHandover, dbo.tblDeclaration.DateReturn, 
                      dbo.tblDeclaration.PersonConfirmReturnID, dbo.fn_GetNameById(dbo.tblDeclaration.PersonConfirmReturnID) AS PersonConfirmReturnName, 
                      dbo.tblDeclaration.NumberTemp, dbo.tblDeclaration.GateExport, dbo.tblDeclaration.TypeOption, dbo.tblDeclaration.Seal, dbo.tblVehicle.VehicleID, 
                      dbo.tblVehicle.PlateNumber, dbo.tblVehicle.NumberOfContainer, dbo.tblVehicle.IsExport, dbo.fn_GetStatusExportByDeclarationId(dbo.tblDeclaration.DeclarationID, 
                      dbo.tblDeclaration.TypeOption) AS StatusExport, dbo.tblDeclaration.PersonHandoverID, dbo.fn_GetNameById(dbo.tblDeclaration.PersonHandoverID) 
                      AS PersonHandoverName, dbo.tblDeclaration.ReceiveNumberInYear, dbo.tblDeclaration.BranchId
FROM         dbo.tblDeclaration INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblDeclaration.DeclarationID = dbo.tblDeclarationVehicle.DeclarationID INNER JOIN
                      dbo.tblVehicle ON dbo.tblDeclarationVehicle.VehicleID = dbo.tblVehicle.VehicleID

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
         Begin Table = "tblDeclaration"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 241
            End
            DisplayFlags = 280
            TopColumn = 37
         End
         Begin Table = "tblDeclarationVehicle"
            Begin Extent = 
               Top = 6
               Left = 279
               Bottom = 110
               Right = 439
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "tblVehicle"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 306
            End
            DisplayFlags = 280
            TopColumn = 47
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
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewAllDeclarationTNTX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewAllDeclarationTNTX'
GO

