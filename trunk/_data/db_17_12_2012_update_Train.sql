USE [dbEcustom]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblTrain]') AND type in (N'U'))
DROP TABLE [dbo].[tblTrain]
GO

USE [dbEcustom]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblTrain](
	[TrainID] [bigint] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](50) NULL,
	[Type] [smallint] NULL,
	[IsImport] [bit] NULL,
	[DateImport] [datetime] NULL,
	[IsExport] [bit] NULL,
	[DateExport] [datetime] NULL,
	[NumberHandover] [nvarchar](50) NULL,
	[DateHandover] [datetime] NULL,
	[CodeStation] [nvarchar](50) NULL,
	[CodeStationFromTo] [nvarchar](50) NULL,
	[StatusVehicle] [nvarchar](200) NULL,
	[StatusGoods] [nvarchar](200) NULL,
	[NumberPartTrain] [nchar](10) NULL,
	[Jounery] [nvarchar](200) NULL,
	[PassengerVN] [int] NULL,
	[PassengerForegin] [int] NULL,
	[Staff] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[BranchId] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_tblTrain] PRIMARY KEY CLUSTERED 
(
	[TrainID] ASC,
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [dbEcustom]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblToaTau]') AND type in (N'U'))
DROP TABLE [dbo].[tblToaTau]
GO

USE [dbEcustom]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblToaTau](
	[ToaTauID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ma_ToaTau] [nvarchar](50) NULL,
	[So_VanTai_Don] [nvarchar](50) NULL,
	[Ngay_VanTai_Don] [datetime] NULL,
	[Ten_DoiTac] [nvarchar](250) NULL,
	[Ma_DoanhNghiep] [nvarchar](50) NULL,
	[Ten_Hang] [nvarchar](250) NULL,
	[Trong_Luong] [nvarchar](50) NULL,
	[Don_Vi_Tinh] [nvarchar](50) NULL,
	[Seal_VanTai] [nvarchar](50) NULL,
	[Seal_HaiQuan] [nvarchar](50) NULL,
	[Ghi_Chu] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[TrainID] [bigint] NOT NULL,
	[BranchId] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_tblToaTau_1] PRIMARY KEY CLUSTERED 
(
	[ToaTauID] ASC,
	[TrainID] ASC,
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblToKhaiTau]') AND type in (N'U'))
DROP TABLE [dbo].[tblToKhaiTau]
GO

USE [dbEcustom]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblToKhaiTau](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Number] [int] NULL,
	[DateDeclaration] [datetime] NULL,
	[TypeCode] [nvarchar](50) NULL,
	[CustomCode] [nvarchar](50) NULL,
	[CompanyCode] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[BranchId] [nvarchar](15) NOT NULL,
	[TrainID] [bigint] NOT NULL,
 CONSTRAINT [PK_tblToKhaiTau] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[BranchId] ASC,
	[TrainID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


