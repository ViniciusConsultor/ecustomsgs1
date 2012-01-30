
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

