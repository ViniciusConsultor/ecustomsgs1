/* -------------------------NOTE----------------------------------------: 
	Sửa lại bảng tblDeclaration như sau:
	- XÓA trường PersonHandover (nvarchar)
	- THÊM trường PersonHandoverID (int)
-------------------------------------------------------------------------*/

-- Create function
PRINT N'Creating [dbo].[fn_GetStatusExportByDeclarationId]...';
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetStatusExportByDeclarationId]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_GetStatusExportByDeclarationId]
GO
CREATE FUNCTION [dbo].[fn_GetStatusExportByDeclarationId] (@DeclarationId bigint, @DeclarationOptionType smallint)
RETURNS NVARCHAR(100)
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @Status NVARCHAR(100);
    IF (@DeclarationOptionType is null or @DeclarationOptionType != 1)
		SET @Status = null
	ELSE
		BEGIN
			DECLARE @isExport bit;
			DECLARE Vehicle_Cursor CURSOR FOR
				SELECT IsExport
				FROM tblVehicle inner join tblDeclarationVehicle 
				ON dbo.tblDeclarationVehicle.VehicleID = dbo.tblVehicle.VehicleID
				WHERE dbo.tblDeclarationVehicle.DeclarationID = @DeclarationId;
			
			OPEN Vehicle_Cursor;
			FETCH NEXT FROM Vehicle_Cursor INTO @isExport;
			DECLARE @totalCount int = 0, @countExport int = 0;
			WHILE @@FETCH_STATUS = 0
				BEGIN
					SET @totalCount += 1;
					IF @isExport = 'true'
						SET @countExport += 1;
					FETCH NEXT FROM Vehicle_Cursor INTO @isExport;
				END;
			CLOSE Vehicle_Cursor;
			DEALLOCATE Vehicle_Cursor;
			IF @countExport = @totalCount  
				IF @countExport = 0
					SET @Status = N'Không có hàng hóa'
				ELSE
					SET @Status = N'Đã xuất khẩu'
			ELSE
				IF (@countExport < @totalCount  and @countExport = 0)
					SET @Status = N'Chưa xuất khẩu'
				ELSE
					SET @Status = N'Chưa xuất khẩu hết, còn tồn'
		END
	RETURN (@Status);		
END;
GO


-- Alter view
PRINT N'Altering [dbo].[ViewAllVehicleHasGood]...';


GO
ALTER VIEW dbo.ViewAllVehicleHasGood
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
                      dbo.tblDeclaration.Money, dbo.tblDeclaration.RegisterPlace
FROM         dbo.tblVehicle INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblVehicle.VehicleID = dbo.tblDeclarationVehicle.VehicleID INNER JOIN
                      dbo.tblDeclaration ON dbo.tblDeclarationVehicle.DeclarationID = dbo.tblDeclaration.DeclarationID
WHERE     (dbo.tblVehicle.VehicleID IN
                          (SELECT     VehicleID
                            FROM          dbo.tblDeclarationVehicle AS tblDeclarationVehicle_1))
GO
PRINT N'Altering [dbo].[ViewAllDeclaration]...';


GO
ALTER VIEW dbo.ViewAllDeclaration
AS
SELECT     tblUser_1.UserID, tblUser_1.Name, tblUser_1.UserName AS CreatedBy,
                          (SELECT     UserName
                            FROM          dbo.tblUser
                            WHERE      (UserID = dbo.tblDeclaration.ModifiedByID)) AS ModifiedBy, dbo.tblDeclaration.Number, dbo.tblDeclaration.ProductName, 
                      dbo.tblDeclaration.CompanyName, dbo.tblDeclaration.ProductAmount, dbo.tblDeclaration.Unit, dbo.tblDeclaration.CreatedByID, dbo.tblDeclaration.ModifiedByID, 
                      dbo.tblDeclaration.ModifiedDate, dbo.tblDeclaration.CreatedDate, dbo.tblDeclaration.HasDeclaration, dbo.tblDeclaration.Type, dbo.tblDeclaration.CompanyCode, 
                      dbo.tblDeclaration.RegisterDate, dbo.tblDeclaration.DeclarationType, dbo.tblDeclaration.ConfirmStatus, dbo.tblDeclaration.ConfirmDate, 
                      dbo.tblDeclaration.RegisterPlace, dbo.tblDeclaration.Money, dbo.tblDeclaration.NumberHandover, dbo.tblDeclaration.DateHandover, dbo.tblDeclaration.DateReturn, 
                      dbo.tblDeclaration.GateExport, dbo.tblDeclaration.Seal, dbo.tblDeclaration.TypeOption,
                          (SELECT     COUNT(*) AS NumberTotalVehicles
                            FROM          dbo.tblDeclarationVehicle
                            WHERE      (DeclarationID = dbo.tblDeclaration.DeclarationID)) AS NumberTotalVehicles, dbo.tblDeclaration.DeclarationID, dbo.tblDeclaration.NumberTemp,
                          (SELECT     UserName
                            FROM          dbo.tblUser AS tblUser_2
                            WHERE      (UserID = dbo.tblDeclaration.PersonConfirmReturnID)) AS PersonConfirmReturnName, dbo.tblDeclaration.PersonHandoverID, 
                      dbo.tblDeclaration.PersonConfirmReturnID, dbo.fn_GetNameById(dbo.tblDeclaration.PersonHandoverID) AS PersonHandoverName
FROM         dbo.tblDeclaration INNER JOIN
                      dbo.tblUser AS tblUser_1 ON dbo.tblDeclaration.CreatedByID = tblUser_1.UserID
GO
PRINT N'Altering [dbo].[ViewAllDeclarationTNTX]...';


GO
ALTER VIEW dbo.ViewAllDeclarationTNTX
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
                      AS PersonHandoverName
FROM         dbo.tblDeclaration INNER JOIN
                      dbo.tblDeclarationVehicle ON dbo.tblDeclaration.DeclarationID = dbo.tblDeclarationVehicle.DeclarationID INNER JOIN
                      dbo.tblVehicle ON dbo.tblDeclarationVehicle.VehicleID = dbo.tblVehicle.VehicleID
GO