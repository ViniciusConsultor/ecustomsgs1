USE [eCustoms]
GO

/****** Object:  Table [dbo].[tblDeclaration]    Script Date: 01/19/2012 00:58:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER TABLE [dbo].[tblDeclaration]
ADD
	[NumberTemp] [int] NULL,
	[Money] [numeric](18, 0) NULL,
	[DateHandover] [datetime] NULL,
	[DateReported] [datetime] NULL,
	[CustomsStatistics] [nvarchar](50) NULL,
	[StatusGate] [nchar](10) NULL,
	[Seal] [nvarchar](100) NULL,
	[DirectExport] [nvarchar](500) NULL

