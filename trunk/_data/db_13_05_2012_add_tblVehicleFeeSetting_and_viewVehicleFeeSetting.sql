USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblVehicleFeeSetting]    Script Date: 05/13/2012 23:02:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblVehicleFeeSetting]') AND type in (N'U'))
DROP TABLE [dbo].[tblVehicleFeeSetting]
GO

USE [dbECustoms]
GO

/****** Object:  Table [dbo].[tblVehicleFeeSetting]    Script Date: 05/13/2012 23:02:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblVehicleFeeSetting](
	[VehicleTypeId] [int] NOT NULL,
	[GoodsTypeId] [int] NOT NULL,
	[Fee] [bigint] NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedUser] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedUser] [int] NULL,
 CONSTRAINT [PK_tblVehicleFeeSetting] PRIMARY KEY CLUSTERED 
(
	[VehicleTypeId] ASC,
	[GoodsTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[viewVehicleFeeSetting]    Script Date: 05/13/2012 23:03:14 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[viewVehicleFeeSetting]'))
DROP VIEW [dbo].[viewVehicleFeeSetting]
GO

USE [dbECustoms]
GO

/****** Object:  View [dbo].[viewVehicleFeeSetting]    Script Date: 05/13/2012 23:03:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[viewVehicleFeeSetting]
AS
SELECT     dbo.tblVehicleFeeSetting.VehicleTypeId, dbo.tblVehicleFeeSetting.GoodsTypeId, dbo.tblVehicleFeeSetting.Fee, dbo.tblVehicleFeeSetting.Description, 
                      dbo.tblGoodsType.TypeName AS GoodTypeName, dbo.tblVehicleType.Name AS VehicleTypeName, dbo.tblVehicleType.Capacity
FROM         dbo.tblVehicleType INNER JOIN
                      dbo.tblVehicleFeeSetting ON dbo.tblVehicleType.VehicleTypeID = dbo.tblVehicleFeeSetting.VehicleTypeId INNER JOIN
                      dbo.tblGoodsType ON dbo.tblVehicleFeeSetting.VehicleTypeId = dbo.tblGoodsType.TypeId

GO
