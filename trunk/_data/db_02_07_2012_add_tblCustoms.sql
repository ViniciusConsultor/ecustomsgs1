USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblCustoms]    Script Date: 07/02/2012 22:58:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCustoms]') AND type in (N'U'))
DROP TABLE [dbo].[tblCustoms]
GO

USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblCustoms]    Script Date: 07/02/2012 22:58:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCustoms](
	[CustomsCode] [nvarchar](50) NOT NULL,
	[CustomsName] [nvarchar](500) NULL,
	[Description] [nvarchar](1000) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_tblCustoms] PRIMARY KEY CLUSTERED 
(
	[CustomsCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


