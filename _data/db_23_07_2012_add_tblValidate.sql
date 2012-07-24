USE [dbECustoms]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblValidate]') AND type in (N'U'))
DROP TABLE [dbo].[tblValidate]
GO

USE [dbECustoms]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblValidate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblValidate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT [dbo].[tblValidate] ([ID], [TagName]) VALUES (1, N'TypeCode')
INSERT [dbo].[tblValidate] ([ID], [TagName]) VALUES (2, N'CustomCode')
INSERT [dbo].[tblValidate] ([ID], [TagName]) VALUES (3, N'CompanyCode')


