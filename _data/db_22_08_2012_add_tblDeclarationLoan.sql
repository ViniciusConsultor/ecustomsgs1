USE [dbEcustoms]
GO

/****** Object:  Table [dbo].[tblDeclarationLoan]    Script Date: 08/22/2012 23:48:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblDeclarationLoan]') AND type in (N'U'))
DROP TABLE [dbo].[tblDeclarationLoan]
GO

USE [dbEcustoms]
GO

/****** Object:  Table [dbo].[tblDeclarationLoan]    Script Date: 08/22/2012 23:48:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblDeclarationLoan](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[DeclarationID] [bigint] NOT NULL,
	[LoanDate] [datetime] NOT NULL,
	[ReturnDate] [datetime] NULL,
	[LoanPerson] [nvarchar](50) NULL,
	[LoanReason] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblDeclarationLoan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


