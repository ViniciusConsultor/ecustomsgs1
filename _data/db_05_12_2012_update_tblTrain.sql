USE [dbEcustom]
GO

/****** Object:  Table [dbo].[tblTrain]    Script Date: 12/05/2012 09:17:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblTrain]') AND type in (N'U'))
DROP TABLE [dbo].[tblTrain]
GO

USE [dbEcustom]
GO

/****** Object:  Table [dbo].[tblTrain]    Script Date: 12/05/2012 09:17:30 ******/
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
	[StationStart] [nvarchar](200) NULL,
	[StationEnd] [nvarchar](200) NULL,
	[CompanyCode] [nvarchar](50) NULL,
	[Partner] [nvarchar](200) NULL,
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


