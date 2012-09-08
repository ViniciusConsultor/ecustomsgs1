USE [dbEcustom]
GO

/****** Object:  Table [dbo].[tblPermissionType]    Script Date: 09/08/2012 15:44:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPermissionType]') AND type in (N'U'))
DROP TABLE [dbo].[tblPermissionType]
GO

USE [dbEcustom]
GO

/****** Object:  Table [dbo].[tblPermissionType]    Script Date: 09/08/2012 15:44:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblPermissionType](
	[TypeCode] [nvarchar](10) NOT NULL,
	[TypeName] [nvarchar](500) NULL,
	[IsSynced] [bit] NULL,
	[BranchId] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_tblPermissionType] PRIMARY KEY CLUSTERED 
(
	[TypeCode] ASC,
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

GO
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName], [IsSynced], [BranchId]) VALUES (N'AA', N'Quản lý nhóm người dùng',0, N'Z15Z')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName], [IsSynced], [BranchId]) VALUES (N'AB', N'Quản lý người dùng',0, N'Z15Z')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName], [IsSynced], [BranchId]) VALUES (N'AC', N'Quản lý tờ khai',0, N'Z15Z')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName], [IsSynced], [BranchId]) VALUES (N'AD', N'Quản lý phương tiện',0, N'Z15Z')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName], [IsSynced], [BranchId]) VALUES (N'AE', N'Quản lý thu phí',0, N'Z15Z')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName], [IsSynced], [BranchId]) VALUES (N'AF', N'Quản lý loại hình',0, N'Z15Z')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName], [IsSynced], [BranchId]) VALUES (N'AG', N'Quản lý thông tin đề nghị kiểm tra',0, N'Z15Z')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName], [IsSynced], [BranchId]) VALUES (N'AH', N'Quản lý trạng thái phương tiện',0, N'Z15Z')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName], [IsSynced], [BranchId]) VALUES (N'AI', N'Quản lý thông tin tạm nhập tái xuất',0, N'Z15Z')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName], [IsSynced], [BranchId]) VALUES (N'AJ', N'Quản lý loại phương tiện',0, N'Z15Z')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName], [IsSynced], [BranchId]) VALUES (N'AK', N'Quản lý cấu hình tính phí phương tiện',0, N'Z15Z')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName], [IsSynced], [BranchId]) VALUES (N'AL', N'Xuất báo cáo',0, N'Z15Z')
INSERT [dbo].[tblPermissionType] ([TypeCode], [TypeName], [IsSynced], [BranchId]) VALUES (N'AM', N'Quản lý hồ sơ tờ khai',0, N'Z15Z')


GO

USE [dbEcustom]
GO

/****** Object:  Table [dbo].[tblPermission]    Script Date: 09/08/2012 15:50:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPermission]') AND type in (N'U'))
DROP TABLE [dbo].[tblPermission]
GO

USE [dbEcustom]
GO

/****** Object:  Table [dbo].[tblPermission]    Script Date: 09/08/2012 15:50:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblPermission](
	[PermissionID] [int] NOT NULL,
	[Permission] [nvarchar](250) NULL,
	[IsSynced] [bit] NULL,
	[TypeCode] [nvarchar](10) NULL,
	[BranchId] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_tblPermission] PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC,
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (1, N'Tạo mới người dùng', 0, N'AB', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (2, N'Tạo mới nhóm người dùng', 0, N'AA', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (3, N'Cập nhật người dùng', 0, N'AB', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (4, N'Cập nhật nhóm nguời dùng', 0, N'AA', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (5, N'Xóa người dùng', 0, N'AB', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (6, N'Xóa nhóm người dùng', 0, N'AA', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (7, N'Tạo mới  phương tiện', 0, N'AD', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (8, N'Cập nhật phương tiẹn', 0, N'AD', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (9, N'Xóa phương tiện', 0, N'AD', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (10, N'Tạo mới thông tin đề nghị kiểm tra', 0, N'AG', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (11, N'Cập nhật thông tin đề nghị kiểm tra', 0, N'AG', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (12, N'Xóa thông tin đề nghị kiểm tra', 0, N'AG', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (13, N'Tạo tờ khai', 0, N'AC', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (14, N'Cập nhật tờ khai', 0, N'AC', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (15, N'Xóa tờ khai', 0, N'AC', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (16, N'Xác nhận xuât cảnh', 0, N'AH', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (17, N'Xác nhận nhập cảnh', 0, N'AH', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (18, N'Kêt xuất dữ liệu', 0, N'AL', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (19, N'Nhập kết quả kiểm tra', 0, N'AG', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (20, N'In báo cáo', 0, N'AL', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (21, N'Đổi mật khẩu', 0, N'AA', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (22, N'Cập nhật thời gian vào nội địa', 0, N'AH', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (23, N'Xác nhận trả hồ sơ', 0, N'AC', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (24, N'Export tờ khai', 0, N'AC', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (25, N'Xác nhận hàng vào nội địa', 0, N'AH', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (26, N'Hàng vào bãi', 0, N'AH', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (27, N'Cập nhật kết quả kiểm tra', 0, N'AG', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (28, N'Xóa thông tin kiểm tra', 0, N'AG', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (29, N'Thêm phương tiện cho tờ khai nhập cảnh', 0, N'AC', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (30, N'Xóa phương tiện cho tờ khai nhập cảnh', 0, N'AC', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (31, N'Cập nhật phương tiện cho tờ khai nhập cảnh', 0, N'AC', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (32, N'Thêm phương tiện cho tờ khai xuất cảnh', 0, N'AC', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (33, N'Xóa phương tiện cho tờ khai xuất cảnh', 0, N'AC', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (34, N'Cập nhật  phương tiện cho tờ khai xuất cảnh', 0, N'AC', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (35, N'Tra cứu thông tin tạm nhập tái xuất', 0, N'AI', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (36, N'Xác nhận hồi báo tạm nhập tái xuất', 0, N'AI', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (37, N'Bổ sung thông tin tờ khai/Sửa thông tin bổ sung tờ khai tạm nhập tái xuất', 0, N'AI', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (38, N'In báo cáo tạm nhập tái xuất', 0, N'AI', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (39, N'Nhập phương tiện vào bãi xuất', 0, N'AD', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (40, N'Nhập phương tiện xe Trung Quốc', 0, N'AD', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (41, N'Tra cứu thông tin loại phương tiện/loại trọng tải', 0, N'AJ', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (42, N'Thêm mới loại phương tiện/loại trọng tải', 0, N'AJ', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (43, N'Cập nhật loại phương tiện/loại trọng tải', 0, N'AJ', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (44, N'Xóa loại phương tiện/loại trọng tải', 0, N'AJ', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (45, N'Tra cứu thông tin thu phí phương tiện', 0, N'AE', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (46, N'Xác  nhận thu phí phương tiện xuất cảnh', 0, N'AE', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (47, N'Xác  nhận thu phí phương tiện nhập cảnh', 0, N'AE', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (48, N'Xuất Excel thông tin thu phí phương tiện ', 0, N'AE', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (49, N'Xem báo cáo thu phí phương tiện', 0, N'AE', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (50, N'Tra cứu thông tin cấu hình tính phí phương tiện', 0, N'AK', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (51, N'Thêm mới cấu hình tính phí phương tiện', 0, N'AK', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (52, N'Cập nhật thông tin cấu hình tính phí phương tiện', 0, N'AK', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (53, N'Xóa thông tin cấu hình tính phí phương tiện', 0, N'AK', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (54, N'Tra cứu thông tin hồ sơ tờ khai', 0, N'AM', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (55, N'Xác nhận bàn giao hồ sơ tờ khai lên phúc tập', 0, N'AM', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (56, N'Xác nhận bàn giao hồ sơ tờ khai sang lưu trữ', 0, N'AM', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (57, N'Xác nhận cho mượn hồ sơ tờ khai', 0, N'AM', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (58, N'Xác nhận trả hồ sơ tờ khai', 0, N'AM', N'Z15Z')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission], [IsSynced], [TypeCode], [BranchId]) VALUES (59, N'Cập nhật thông tin lưu trữ hồ sơ tờ khai', 0, N'AM', N'Z15Z')

