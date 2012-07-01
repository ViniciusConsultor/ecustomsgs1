USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblCompany]    Script Date: 07/01/2012 23:31:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCompany]') AND type in (N'U'))
DROP TABLE [dbo].[tblCompany]
GO

USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblCompany]    Script Date: 07/01/2012 23:31:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCompany](
	[CompanyCode] [nvarchar](50) NOT NULL,
	[CompanyName] [nvarchar](500) NULL,
	[Description] [nvarchar](1000) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_tblCompany] PRIMARY KEY CLUSTERED 
(
	[CompanyCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


