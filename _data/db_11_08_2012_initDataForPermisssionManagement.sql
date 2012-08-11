USE [dbECustoms]
GO
/****** Object:  Table [dbo].[tblPermissionType]    Script Date: 08/11/2012 23:13:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPermissionType]') AND type in (N'U'))
DROP TABLE [dbo].[tblPermissionType]
GO

GO
/****** Object:  Table [dbo].[tblPermissionType]    Script Date: 08/11/2012 23:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPermissionType](
	[TypeCode] [nchar](10) NOT NULL,
	[TypeName] [nvarchar](500) NULL,
 CONSTRAINT [PK_tblPermissionType] PRIMARY KEY CLUSTERED 
(
	[TypeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName]) VALUES (N'AA        ', N'Quản lý nhóm người dùng')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName]) VALUES (N'AB        ', N'Quản lý người dùng')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName]) VALUES (N'AC        ', N'Quản lý tờ khai')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName]) VALUES (N'AD        ', N'Quản lý phương tiện')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName]) VALUES (N'AE        ', N'Quản lý thu phí')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName]) VALUES (N'AF        ', N'Quản lý loại hình')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName]) VALUES (N'AG        ', N'Quản lý thông tin đề nghị kiểm tra')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName]) VALUES (N'AH        ', N'Quản lý trạng thái phương tiện')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName]) VALUES (N'AI        ', N'Quản lý thông tin tạm nhập tái xuất')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName]) VALUES (N'AJ        ', N'Quản lý loại phương tiện')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName]) VALUES (N'AK        ', N'Quản lý cấu hình tính phí phương tiện')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName]) VALUES (N'AP        ', N'Xuất báo cáo')
/****** Object:  Table [dbo].[tblPermission]    Script Date: 08/11/2012 23:09:57 ******/
SET ANSI_NULLS ON
GO

/****** Object:  Table [dbo].[tblPermission]    Script Date: 08/11/2012 23:13:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPermission]') AND type in (N'U'))
DROP TABLE [dbo].[tblPermission]
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPermission](
	[PermissionID] [int] NOT NULL,
	[Permission] [nvarchar](250) NULL,
	[IsSynced] [bit] NULL,
	[TypeCode] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (1, N'Tạo mới người dùng', 0, N'AB        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (2, N'Tạo mới nhóm người dùng', 0, N'AA        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (3, N'Cập nhật người dùng', 0, N'AB        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (4, N'Cập nhật nhóm nguời dùng', 0, N'AA        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (5, N'Xóa người dùng', 0, N'AB        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (6, N'Xóa nhóm người dùng', 0, N'AA        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (7, N'Tạo mới  phương tiện', 0, N'AD        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (8, N'Cập nhật phương tiẹn', 0, N'AD        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (9, N'Xóa phương tiện', 0, N'AD        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (10, N'Tạo mới thông tin đề nghị kiểm tra', 0, N'AG        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (11, N'Cập nhật thông tin đề nghị kiểm tra', 0, N'AG        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (12, N'Xóa thông tin đề nghị kiểm tra', 0, N'AG        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (13, N'Tạo tờ khai', 0, N'AC        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (14, N'Cập nhật tờ khai', 0, N'AC        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (15, N'Xóa tờ khai', 0, N'AC        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (16, N'Xác nhận xuât cảnh', 0, N'AH        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (17, N'Xác nhận nhập cảnh', 0, N'AH        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (18, N'Kêt xuất dữ liệu', 0, N'AP        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (19, N'Nhập kết quả kiểm tra', 0, N'AG        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (20, N'In báo cáo', 0, N'AP        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (21, N'Đổi mật khẩu', 0, N'AA        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (22, N'Cập nhật thời gian vào nội địa', 0, N'AH        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (23, N'Xác nhận trả hồ sơ', 0, N'AC        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (24, N'Export tờ khai', 0, N'AC        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (25, N'Xác nhận hàng vào nội địa', 0, N'AH        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (26, N'Hàng vào bãi', 0, N'AH        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (27, N'Cập nhật kết quả kiểm tra', 0, N'AG        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (28, N'Xóa thông tin kiểm tra', 0, N'AG        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (29, N'Thêm phương tiện cho tờ khai nhập cảnh', 0, N'AC        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (30, N'Xóa phương tiện cho tờ khai nhập cảnh', 0, N'AC        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (31, N'Cập nhật phương tiện cho tờ khai nhập cảnh', 0, N'AC        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (32, N'Thêm phương tiện cho tờ khai xuất cảnh', 0, N'AC        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (33, N'Xóa phương tiện cho tờ khai xuất cảnh', 0, N'AC        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (34, N'Cập nhật  phương tiện cho tờ khai xuất cảnh', 0, N'AC        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (35, N'Tra cứu thông tin tạm nhập tái xuất', 0, N'AI        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (36, N'Xác nhận hồi báo tạm nhập tái xuất', 0, N'AI        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (37, N'Bổ sung thông tin tờ khai/Sửa thông tin bổ sung tờ khai tạm nhập tái xuất', 0, N'AI        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (38, N'In báo cáo tạm nhập tái xuất', 0, N'AI        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (39, N'Nhập phương tiện vào bãi xuất', 0, N'AD        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (40, N'Nhập phương tiện xe Trung Quốc', 0, N'AD        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (41, N'Tra cứu thông tin loại phương tiện/loại trọng tải', 0, N'AJ        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (42, N'Thêm mới loại phương tiện/loại trọng tải', 0, N'AJ        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (43, N'Cập nhật loại phương tiện/loại trọng tải', 0, N'AJ        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (44, N'Xóa loại phương tiện/loại trọng tải', 0, N'AJ        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (45, N'Tra cứu thông tin thu phí phương tiện', 0, N'AE        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (46, N'Xác  nhận thu phí phương tiện xuất cảnh', 0, N'AE        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (47, N'Xác  nhận thu phí phương tiện nhập cảnh', 0, N'AE        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (48, N'Xuất Excel thông tin thu phí phương tiện ', 0, N'AE        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (49, N'Xem báo cáo thu phí phương tiện', 0, N'AE        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (50, N'Tra cứu thông tin cấu hình tính phí phương tiện', 0, N'AK        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (51, N'Thêm mới cấu hình tính phí phương tiện', 0, N'AK        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (52, N'Cập nhật thông tin cấu hình tính phí phương tiện', 0, N'AK        ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode]) VALUES (53, N'Xóa thông tin cấu hình tính phí phương tiện', 0, N'AK        ')
