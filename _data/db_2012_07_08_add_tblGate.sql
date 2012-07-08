USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblGate]    Script Date: 07/08/2012 23:24:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblGate]') AND type in (N'U'))
DROP TABLE [dbo].[tblGate]
GO

USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblGate]    Script Date: 07/08/2012 23:24:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblGate](
	[GateCode] [nvarchar](50) NOT NULL,
	[GateName] [nvarchar](500) NULL,
	[GateType] [int] NULL,
	[Description] [nvarchar](1000) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_tblGate] PRIMARY KEY CLUSTERED 
(
	[GateCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


