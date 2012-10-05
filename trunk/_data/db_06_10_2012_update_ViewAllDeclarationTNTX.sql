USE [dbEcustom]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_GetGateNameByCode]    Script Date: 10/06/2012 00:17:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetGateNameByCode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetGateNameByCode]
GO

USE [dbEcustom]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_GetGateNameByCode]    Script Date: 10/06/2012 00:17:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_GetGateNameByCode] (@code nvarchar (500))
RETURNS NVARCHAR(500)
WITH EXECUTE AS CALLER
AS
BEGIN
     DECLARE @Name NVARCHAR(500);
		SELECT @Name = GateName FROM tblGate as a WHERE a.GateCode = @code
     RETURN(@Name);
END;

GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[ViewAllDeclarationTNTX]
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
                      AS PersonHandoverName, dbo.tblDeclaration.ReceiveNumberInYear, dbo.tblDeclaration.BranchId, dbo.fn_GetGateNameByCode(dbo.tblDeclaration.GateExport) 
                      AS GateExportName, dbo.tblDeclaration.GateImport, dbo.fn_GetGateNameByCode(dbo.tblDeclaration.GateImport) AS GateImportName
FROM         dbo.tblDeclaration INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblDeclaration.DeclarationID = dbo.tblDeclarationVehicle.DeclarationID INNER JOIN
                      dbo.tblVehicle ON dbo.tblDeclarationVehicle.VehicleID = dbo.tblVehicle.VehicleID

GO