USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblVehicleType]    Script Date: 05/01/2012 22:04:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblVehicleType]') AND type in (N'U'))
DROP TABLE [dbo].[tblVehicleType]
GO

USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblVehicleType]    Script Date: 05/01/2012 22:04:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblVehicleType](
	[VehicleTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](1000) NULL,
	[Capacity] [nvarchar](500) NULL,
	[FeePrice] [bigint] NULL,
	[Description] [nvarchar](1000) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedUser] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedUser] [int] NULL,
 CONSTRAINT [PK_tblVehicleType] PRIMARY KEY CLUSTERED 
(
	[VehicleTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


