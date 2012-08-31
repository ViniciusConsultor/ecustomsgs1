use dbECustoms

go

ALTER TABLE dbo.tblDeclaration
ADD FilesLocation nvarchar(4000) NULL,
LoanStatus bit NULL
USE [dbECustoms]
GO

USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblDeclarationLoan]    Script Date: 09/01/2012 03:18:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblDeclarationLoan]') AND type in (N'U'))
DROP TABLE [dbo].[tblDeclarationLoan]
GO

USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblDeclarationLoan]    Script Date: 09/01/2012 03:18:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblDeclarationLoan](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[DeclarationID] [bigint] NULL,
	[LoanDate] [datetime] NULL,
	[ReturnDate] [datetime] NULL,
	[LenderUserID] [int] NULL,
	[BorrowerName] [nvarchar](500) NULL,
	[LoanReason] [nvarchar](4000) NULL,
	[GetLoanDescription] [nvarchar](4000) NULL,
	[ReturnLoanDescription] [nvarchar](4000) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedUserID] [int] NULL,
	[ModifiedUserID] [int] NULL,
 CONSTRAINT [PK_tblDeclarationLoan1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [dbECustoms]
GO

/****** Object:  View [dbo].[viewDeclarationLoan]    Script Date: 09/01/2012 03:18:37 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[viewDeclarationLoan]'))
DROP VIEW [dbo].[viewDeclarationLoan]
GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[viewDeclarationLoan]    Script Date: 09/01/2012 03:18:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[viewDeclarationLoan]
AS
SELECT     dbo.tblDeclarationLoan.ID, dbo.tblDeclarationLoan.DeclarationID, dbo.tblDeclarationLoan.LoanDate, dbo.tblDeclarationLoan.ReturnDate, 
                      dbo.tblDeclarationLoan.LenderUserID, dbo.tblDeclarationLoan.BorrowerName, dbo.tblDeclarationLoan.LoanReason, dbo.tblDeclarationLoan.GetLoanDescription, 
                      dbo.tblDeclarationLoan.ReturnLoanDescription, dbo.tblDeclarationLoan.CreatedDate, dbo.tblDeclarationLoan.ModifiedDate, dbo.tblDeclaration.PageNumbers, 
                      dbo.tblDeclaration.LoanStatus, dbo.tblDeclaration.Number, dbo.tblUser.Name AS LenderFullName
FROM         dbo.tblUser INNER JOIN
                      dbo.tblDeclarationLoan ON dbo.tblUser.UserID = dbo.tblDeclarationLoan.LenderUserID LEFT OUTER JOIN
                      dbo.tblDeclaration ON dbo.tblDeclarationLoan.DeclarationID = dbo.tblDeclaration.DeclarationID

GO