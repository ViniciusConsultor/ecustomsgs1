/*
Deployment script for compareEcustoms
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "compareEcustoms"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\"

GO
USE [master]

GO
:on error exit
GO
USE [$(DatabaseName)]

GO
PRINT N'Dropping FK_tblDeclaration_tblUser...';


GO
ALTER TABLE [dbo].[tblDeclaration] DROP CONSTRAINT [FK_tblDeclaration_tblUser];


GO
PRINT N'Starting rebuilding table [dbo].[tblDeclaration]...';


GO
/*
The column [dbo].[tblDeclaration].[CustomsStatistics] is being dropped, data loss could occur.

The column [dbo].[tblDeclaration].[DateReported] is being dropped, data loss could occur.

The column [dbo].[tblDeclaration].[DirectExport] is being dropped, data loss could occur.

The column [dbo].[tblDeclaration].[StatusGate] is being dropped, data loss could occur.
*/
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

BEGIN TRANSACTION;

CREATE TABLE [dbo].[tmp_ms_xx_tblDeclaration] (
    [DeclarationID]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [Number]          INT            NULL,
    [ProductName]     NVARCHAR (500) NULL,
    [CompanyName]     NVARCHAR (500) NULL,
    [ProductAmount]   NVARCHAR (500) NULL,
    [Unit]            NVARCHAR (500) NULL,
    [CreatedByID]     INT            NULL,
    [ModifiedByID]    INT            NULL,
    [ModifiedDate]    DATETIME       NULL,
    [CreatedDate]     DATETIME       NULL,
    [HasDeclaration]  BIT            NULL,
    [Type]            NVARCHAR (200) NULL,
    [CompanyCode]     NVARCHAR (500) NULL,
    [RegisterDate]    DATETIME       NULL,
    [DeclarationType] SMALLINT       NULL,
    [ConfirmStatus]   NVARCHAR (200) NULL,
    [ConfirmDate]     DATETIME       NULL,
    [RegisterPlace]   NVARCHAR (500) NULL,
    [Money]           NUMERIC (18)   NULL,
    [NumberHandover]  INT            NULL,
    [DateHandover]    DATETIME       NULL,
    [DateReturn]      DATETIME       NULL,
    [NumberTemp]      INT            NULL,
    [GateExport]      NVARCHAR (500) NULL,
    [Seal]            NVARCHAR (100) NULL,
    [TypeOption]      SMALLINT       NULL
);

ALTER TABLE [dbo].[tmp_ms_xx_tblDeclaration]
    ADD CONSTRAINT [tmp_ms_xx_clusteredindex_PK_tblDeclaration] PRIMARY KEY CLUSTERED ([DeclarationID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

IF EXISTS (SELECT TOP 1 1
           FROM   [dbo].[tblDeclaration])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblDeclaration] ON;
        INSERT INTO [dbo].[tmp_ms_xx_tblDeclaration] ([DeclarationID], [Number], [ProductName], [CompanyName], [ProductAmount], [Unit], [CreatedByID], [ModifiedByID], [ModifiedDate], [CreatedDate], [HasDeclaration], [Type], [CompanyCode], [RegisterDate], [DeclarationType], [ConfirmStatus], [ConfirmDate], [NumberTemp], [Money], [DateHandover], [Seal])
        SELECT   [DeclarationID],
                 [Number],
                 [ProductName],
                 [CompanyName],
                 [ProductAmount],
                 [Unit],
                 [CreatedByID],
                 [ModifiedByID],
                 [ModifiedDate],
                 [CreatedDate],
                 [HasDeclaration],
                 [Type],
                 [CompanyCode],
                 [RegisterDate],
                 [DeclarationType],
                 [ConfirmStatus],
                 [ConfirmDate],
                 [NumberTemp],
                 [Money],
                 [DateHandover],
                 [Seal]
        FROM     [dbo].[tblDeclaration]
        ORDER BY [DeclarationID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblDeclaration] OFF;
    END

DROP TABLE [dbo].[tblDeclaration];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_tblDeclaration]', N'tblDeclaration';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_clusteredindex_PK_tblDeclaration]', N'PK_tblDeclaration', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating FK_tblDeclaration_tblUser...';


GO
ALTER TABLE [dbo].[tblDeclaration] WITH NOCHECK
    ADD CONSTRAINT [FK_tblDeclaration_tblUser] FOREIGN KEY ([CreatedByID]) REFERENCES [dbo].[tblUser] ([UserID]) ON DELETE CASCADE ON UPDATE NO ACTION;


GO
PRINT N'Refreshing [dbo].[viewDeclarationVehicle]...';


GO
EXECUTE sp_refreshview N'dbo.viewDeclarationVehicle';


GO
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
                      dbo.tblDeclaration.Money, dbo.tblDeclaration.DateHandover, dbo.tblDeclaration.Seal, dbo.tblDeclaration.NumberTemp, dbo.tblDeclaration.GateExport, 
                      dbo.tblDeclaration.DateReturn, dbo.tblDeclaration.NumberHandover, dbo.tblDeclaration.RegisterPlace, dbo.tblDeclaration.TypeOption
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
                            WHERE      (UserID = dbo.tblDeclaration.ModifiedByID)) AS ModifiedBy, dbo.tblDeclaration.DeclarationID, dbo.tblDeclaration.Number, 
                      dbo.tblDeclaration.ProductName, dbo.tblDeclaration.CompanyName, dbo.tblDeclaration.ProductAmount, dbo.tblDeclaration.Unit, dbo.tblDeclaration.CreatedByID, 
                      dbo.tblDeclaration.ModifiedByID, dbo.tblDeclaration.ModifiedDate, dbo.tblDeclaration.CreatedDate, dbo.tblDeclaration.HasDeclaration, dbo.tblDeclaration.Type, 
                      dbo.tblDeclaration.CompanyCode, dbo.tblDeclaration.RegisterDate, dbo.tblDeclaration.DeclarationType, dbo.tblDeclaration.ConfirmStatus, 
                      dbo.tblDeclaration.ConfirmDate, dbo.tblDeclaration.RegisterPlace, dbo.tblDeclaration.Money, dbo.tblDeclaration.NumberHandover, dbo.tblDeclaration.DateHandover, 
                      dbo.tblDeclaration.DateReturn, dbo.tblDeclaration.NumberTemp, dbo.tblDeclaration.GateExport, dbo.tblDeclaration.Seal, dbo.tblDeclaration.TypeOption
FROM         dbo.tblDeclaration INNER JOIN
                      dbo.tblUser AS tblUser_1 ON dbo.tblDeclaration.CreatedByID = tblUser_1.UserID
GO
PRINT N'Refreshing [dbo].[ViewAllCheckResult]...';


GO
EXECUTE sp_refreshview N'dbo.ViewAllCheckResult';


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[tblDeclaration] WITH CHECK CHECK CONSTRAINT [FK_tblDeclaration_tblUser];


GO
