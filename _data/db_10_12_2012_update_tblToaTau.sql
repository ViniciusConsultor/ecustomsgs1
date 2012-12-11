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
	[Ten_Hang] [nvarchar](250) NULL,
	[Trong_Luong] [nvarchar](50) NULL,
	[Seal_VanTai] [nvarchar](50) NULL,
	[Seal_HaiQuan] [nvarchar](50) NULL,
	[Ghi_Chu] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[TrainID] [bigint] NOT NULL,
 CONSTRAINT [PK_tblToaTau_1] PRIMARY KEY CLUSTERED 
(
	[ToaTauID] ASC,
	[TrainID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


