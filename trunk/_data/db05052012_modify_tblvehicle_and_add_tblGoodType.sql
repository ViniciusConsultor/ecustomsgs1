use dbECustoms

go
/*Modify tblVehicle*/

ALTER TABLE dbo.tblVehicle
ADD ExportReceiptNumber varchar(100) NULL,
	ImportReceiptNumber  varchar(100) NULL,
	GoodTypeId int NULL
	
	
GO

/****** Object:  Table [dbo].[tblGoodsType]    Script Date: 05/05/2012 22:49:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblGoodsType]') AND type in (N'U'))
DROP TABLE [dbo].[tblGoodsType]
GO


/****** Object:  Table [dbo].[tblGoodsType]    Script Date: 05/05/2012 22:49:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblGoodsType](
	[TypeId] [int] NOT NULL,
	[TypeName] [nvarchar](500) NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_tblGoodsType] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*Init data for tblGoodsType*/
Insert into tblGoodsType values (1, N'Hàng thông thường','');
Insert into tblGoodsType values (2, N'Hàng TNTX','');
Insert into tblGoodsType values (3, N'Quặng xuất khẩu','');
Insert into tblGoodsType values (4, N'Rau-Củ-Quả tươi','');

