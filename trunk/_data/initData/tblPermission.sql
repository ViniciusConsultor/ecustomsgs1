USE [dbECustoms]

/****** Object:  Table [dbo].[tblPermission]    Script Date: 10/24/2011 23:37:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPermission]') AND type in (N'U'))
DROP TABLE [dbo].[tblPermission]

GO
/****** Object:  Table [dbo].[tblPermission]    Script Date: 10/13/2011 00:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPermission](
	[PermissionID] [int] NOT NULL,
	[Permission] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (1, N'Tạo mới người dùng')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (2, N'Tạo mới nhóm người dùng')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (3, N'Cập nhật người dùng')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (4, N'Cập nhật nhóm nguời dùng')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (5, N'Xóa người dùng')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (6, N'Xóa nhóm người dùng')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (7, N'Tạo mới  phương tiện')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (8, N'Cập nhật phương tiẹn')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (9, N'Xóa phương tiện')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (10, N'Tạo mới thông tin đề nghị kiểm tra')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (11, N'Cập nhật thông tin đề nghị kiểm tra')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (12, N'Xóa thông tin đề nghị kiểm tra')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (13, N'Tạo tờ khai')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (14, N'Cập nhật tờ khai')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (15, N'Xóa tờ khai')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (16, N'Xác nhận xuât cảnh')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (17, N'Xác nhận nhập cảnh')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (18, N'Kêt xuất dữ liệu')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (19, N'Nhập kết quả kiểm tra')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (20, N'In báo cáo')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (21, N'Đổi mật khẩu')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (22, N'Cập nhật thời gian vào nội địa')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (23, N'Xác nhận trả hồ sơ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (24, N'Export tờ khai')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (25, N'Xác nhận hàng vào nội địa')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (26, N'Hàng vào bãi')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (27, N'Cập nhật kết quả kiểm tra')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (28, N'Xóa thông tin kiểm tra')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (29, N'Thêm phương tiện cho tờ khai nhập cảnh')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (30, N'Xóa phương tiện cho tờ khai nhập cảnh')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (31, N'Cập nhật phương tiện cho tờ khai nhập cảnh')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (32, N'Thêm phương tiện cho tờ khai xuất cảnh')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (33, N'Xóa phương tiện cho tờ khai xuất cảnh')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (34, N'Cập nhật  phương tiện cho tờ khai xuất cảnh')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (35, N'Tra cứu thông tin tạm nhập tái xuất')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (36, N'Xác nhận hồi báo tạm nhập tái xuất')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (37, N'Bổ sung thông tin tờ khai/Sửa thông tin bổ sung tờ khai tạm nhập tái xuất')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (38, N'In báo cáo tạm nhập tái xuất')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (39, N'Nhập phương tiện vào bãi xuất')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (40, N'Nhập phương tiện xe Trung Quốc')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (41, N'Tra cứu thông tin loại phương tiện/loại trọng tải')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (42, N'Thêm mới loại phương tiện/loại trọng tải')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (43, N'Cập nhật loại phương tiện/loại trọng tải')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (44, N'Xóa loại phương tiện/loại trọng tải')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (45, N'Tra cứu thông tin thu phí phương tiện')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (46, N'Xác  nhận thu phí phương tiện xuất cảnh')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (47, N'Xác  nhận thu phí phương tiện nhập cảnh')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (48, N'Xuất Excel thông tin thu phí phương tiện ')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (49, N'Xem báo cáo thu phí phương tiện')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (50, N'Tra cứu thông tin cấu hình tính phí phương tiện')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (51, N'Thêm mới cấu hình tính phí phương tiện')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (52, N'Cập nhật thông tin cấu hình tính phí phương tiện')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (53, N'Xóa thông tin cấu hình tính phí phương tiện')


