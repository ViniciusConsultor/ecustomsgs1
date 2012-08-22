USE [dbEcustoms]
GO

ALTER TABLE [dbo].[tblDeclaration]
	
	ADD [PageNumbers] [int] NULL,
	[PersonHandoverSecondID] [int] NULL,
	[PersonReceive] [nvarchar](50) NULL,
	[PersonReceiveSecond] [nvarchar](50) NULL,
	[DateHandoverSecond] [datetime] NULL

GO
