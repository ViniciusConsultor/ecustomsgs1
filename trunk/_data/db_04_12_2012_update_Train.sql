BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.tblTrain
	(
	TrainID bigint NOT NULL IDENTITY (1, 1),
	Number nvarchar(50) NULL,
	Type smallint NULL,
	IsImport bit NULL,
	DateImport datetime NULL,
	IsExport bit NULL,
	DateExport datetime NULL,
	NumberHandover nvarchar(50) NULL,
	DateHandover datetime NULL,
	StationStart nvarchar(200) NULL,
	StationEnd nvarchar(200) NULL,
	CompanyCode nvarchar(50) NULL,
	Partner nvarchar(200) NULL,
	StatusVehicle nvarchar(200) NULL,
	StatusGoods nvarchar(200) NULL,
	NumberPartTrain nchar(10) NULL,
	Jounery nvarchar(200) NULL,
	PassengerVN int NULL,
	PassengerForegin int NULL,
	Staff int NULL,
	CreatedDate datetime NULL,
	CreatedBy int NULL,
	ModifiedDate datetime NULL,
	ModifiedBy int NULL,
	BranchId nvarchar(15) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.tblTrain ADD CONSTRAINT
	PK_tblTrain PRIMARY KEY CLUSTERED 
	(
	BranchId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.tblTrain SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.tblTrain', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblTrain', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblTrain', 'Object', 'CONTROL') as Contr_Per 


BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.tblDelarationTrain
	(
	DeclarationID bigint NOT NULL,
	TrainID bigint NOT NULL,
	BranchId nvarchar(15) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.tblDelarationTrain ADD CONSTRAINT
	PK_tblDelarationTrain PRIMARY KEY CLUSTERED 
	(
	DeclarationID,
	TrainID,
	BranchId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.tblDelarationTrain SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.tblDelarationTrain', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblDelarationTrain', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblDelarationTrain', 'Object', 'CONTROL') as Contr_Per 