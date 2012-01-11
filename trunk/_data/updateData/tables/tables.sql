USE [dbECustoms]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblApplicationObject]') AND type in (N'U'))
DROP TABLE [dbo].[tblApplicationObject]
GO

USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblApplicationObject]    Script Date: 01/01/2012 01:26:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblApplicationObject](
	[ApplicationObjectID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationObjectName] [varchar](500) NULL,
	[ApplicationObjectValueString] [nvarchar](500) NULL,
	[ApplicationObjectValueLong] [bigint] NULL,
	[ApplicationObjectValueFloat] [float] NULL,
	[ApplicationObjectValueDatetime] [datetime] NULL,
 CONSTRAINT [PK_ApplicationObject] PRIMARY KEY CLUSTERED 
(
	[ApplicationObjectID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblUserGroupPermission]    Script Date: 09/28/2011 00:42:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUserGroupPermission]') AND type in (N'U'))
DROP TABLE [dbo].[tblUserGroupPermission]
GO

USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblUserGroupPermission]    Script Date: 09/28/2011 00:42:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblUserGroupPermission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[GroupID] [int] NULL,
	[PermissionType] [int] NULL,
	[PermissionID] [int] NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [date] NULL,
	[ModifiedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[tblPermission]    Script Date: 09/30/2011 01:43:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPermission]') AND type in (N'U'))
DROP TABLE [dbo].[tblPermission]
GO

/****** Object:  Table [dbo].[tblPermission]    Script Date: 09/30/2011 01:43:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblPermission](
	[PermissionID] [int] NOT NULL,
	[Permission] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblVehicleCheck]') AND type in (N'U'))
DROP TABLE [dbo].[tblVehicleCheck]
GO
CREATE TABLE [dbo].[tblVehicleCheck](
	[VehicleCheckID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleID] [bigint] NULL,
	[InputBy] [int] NULL,
	[RecievedBy] [int] NULL,
	[CheckBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[Content] [nvarchar](1000) NULL,
	[Result] [ntext] NULL,
	[CheckFrom] [datetime] NULL,
	[CheckTo] [datetime] NULL,
	[CheckCode] [nchar](500) NULL,
 CONSTRAINT [PK_tblVehicleCheck] PRIMARY KEY CLUSTERED 
(
	[VehicleCheckID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
*/

ALTER TABLE [dbo].[tblVehicleCheck]
ADD CheckCode varchar(500) NULL

/*
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblVehicleCheck]') AND type in (N'U'))
DROP TABLE [dbo].[tblVehicleCheck]
GO

USE [dbECustoms]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblVehicleCheck](
	[VehicleCheckID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleID] [bigint] NULL,
	[InputBy] [int] NULL,
	[RecievedBy] [int] NULL,
	[CheckBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[Content] [nvarchar](1000) NULL,
	[Result] [ntext] NULL,
	[CheckFrom] [datetime] NULL,
	[CheckTo] [datetime] NULL,
	[CheckCode] [nchar](500) NULL,
	[IsImportChecked] [bit] NULL,
	[IsExportChecked] [bit] NULL,
	[IsLocalImportChecked] [bit] NULL,
 CONSTRAINT [PK_tblVehicleCheck] PRIMARY KEY CLUSTERED 
(
	[VehicleCheckID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

*/
GO
ALTER TABLE [dbo].[tblVehicleCheck]
ADD	[IsImportChecked] [bit] NULL,
	[IsExportChecked] [bit] NULL,
	[IsLocalImportChecked] [bit] NULL

/*
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_tblVehicle_ExportDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[tblVehicle] DROP CONSTRAINT [DF_tblVehicle_ExportDate]
END

GO

USE [dbECustoms]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblVehicle]') AND type in (N'U'))
DROP TABLE [dbo].[tblVehicle]
GO

USE [dbECustoms]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblVehicle](
	[VehicleID] [bigint] IDENTITY(1,1) NOT NULL,
	[PlateNumber] [varchar](50) NULL,
	[NumberOfContainer] [nvarchar](50) NULL,
	[DriverName] [nvarchar](250) NULL,
	[ImportDate] [datetime] NULL,
	[IsImport] [bit] NULL,
	[ExportDate] [datetime] NULL,
	[IsExport] [bit] NULL,
	[Note] [nvarchar](500) NULL,
	[Status] [nvarchar](500) NULL,
	[IsCompleted] [bit] NULL,
	[IsGoodsImported] [bit] NULL,
	[ImportStatus] [nvarchar](500) NULL,
	[ImportedLocalTime] [datetime] NULL,
	[HasGoodsImported] [bit] NULL,
	[ConfirmImportBy] [int] NULL,
	[ConfirmExportBy] [int] NULL,
	[ConfirmLocalImportBy] [int] NULL,
	[DeclarationType] [smallint] NULL,
	[ModifiedDate] [datetime] NULL,
	[Parking] [nvarchar](250) NULL,
	[ParkingDate] [datetime] NULL,
 CONSTRAINT [PK_tblVehicle] PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[tblVehicle] ADD  CONSTRAINT [DF_tblVehicle_ExportDate]  DEFAULT (((1)/(1))/(1900)) FOR [ExportDate]
GO

*/	

GO
ALTER TABLE [dbo].[tblVehicle]
ADD	[ParkingDate] [datetime] NULL
	

