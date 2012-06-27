USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblType]    Script Date: 06/27/2012 22:02:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblType]') AND type in (N'U'))
DROP TABLE [dbo].[tblType]
GO

USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblType]    Script Date: 06/27/2012 22:02:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblType](
	[TypeCode] [nvarchar](50) NOT NULL,
	[TypeName] [nvarchar](500) NULL,
	[Description] [nvarchar](1000) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_tblType] PRIMARY KEY CLUSTERED 
(
	[TypeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


