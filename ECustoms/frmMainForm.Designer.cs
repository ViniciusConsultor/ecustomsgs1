﻿namespace ECustoms
{
    partial class frmMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuitemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khaiBáoXuấtNhậpKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemDeclaration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnImport = new System.Windows.Forms.ToolStripMenuItem();
            this.vehicleSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewVehiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVehicleChinese = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportParking = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManageInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnReview = new System.Windows.Forms.ToolStripMenuItem();
            this.mnReviewSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHàngNTXCKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtKhẩuChuyểnCửaKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpKhẩuChuyểnCửaKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hàngTạmNhậpTáiXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFeeManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVehidleType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGetFee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFeeReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFeeSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnSửDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstripLabelWelcome = new System.Windows.Forms.ToolStripLabel();
            this.tsExport = new System.Windows.Forms.ToolStripButton();
            this.tsImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonListdeclarace = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.viewAllVehicleTableAdapter1 = new ECustoms.DataSet2TableAdapters.ViewAllVehicleTableAdapter();
            this.mnMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnMain
            // 
            this.mnMain.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.khaiBáoXuấtNhậpKhẩuToolStripMenuItem,
            this.toolStripMenuReport,
            this.menuManageInformation,
            this.quảnLýHàngNTXCKToolStripMenuItem,
            this.mnuFeeManagement,
            this.trợGiúpToolStripMenuItem,
            this.inTicketToolStripMenuItem});
            this.mnMain.Location = new System.Drawing.Point(0, 0);
            this.mnMain.Name = "mnMain";
            this.mnMain.Size = new System.Drawing.Size(1211, 29);
            this.mnMain.TabIndex = 0;
            this.mnMain.Tag = "";
            this.mnMain.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemUser,
            this.mnGroup,
            this.toolStripMenuItem1,
            this.menuitemLogout,
            this.toolStripSeparator1,
            this.menuitemExit,
            this.aboutUsToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // menuitemUser
            // 
            this.menuitemUser.Image = global::ECustoms.Properties.Resources.user;
            this.menuitemUser.Name = "menuitemUser";
            this.menuitemUser.Size = new System.Drawing.Size(248, 26);
            this.menuitemUser.Text = "Quản lý người dùng";
            this.menuitemUser.Click += new System.EventHandler(this.menuitemUser_Click);
            // 
            // mnGroup
            // 
            this.mnGroup.Image = global::ECustoms.Properties.Resources.Users;
            this.mnGroup.Name = "mnGroup";
            this.mnGroup.Size = new System.Drawing.Size(248, 26);
            this.mnGroup.Text = "Quản lý nhóm";
            this.mnGroup.Click += new System.EventHandler(this.mnGroup_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::ECustoms.Properties.Resources.change_password_icon;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(248, 26);
            this.toolStripMenuItem1.Text = "Thay đổi mật khẩu";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuitemLogout
            // 
            this.menuitemLogout.Image = global::ECustoms.Properties.Resources.logout;
            this.menuitemLogout.Name = "menuitemLogout";
            this.menuitemLogout.Size = new System.Drawing.Size(248, 26);
            this.menuitemLogout.Text = "Đăng xuất";
            this.menuitemLogout.Click += new System.EventHandler(this.menuitemLogout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(245, 6);
            // 
            // menuitemExit
            // 
            this.menuitemExit.Image = global::ECustoms.Properties.Resources.exit;
            this.menuitemExit.Name = "menuitemExit";
            this.menuitemExit.Size = new System.Drawing.Size(248, 26);
            this.menuitemExit.Text = "Thoát Khỏi chương trình";
            this.menuitemExit.Click += new System.EventHandler(this.menuitemExit_Click);
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.aboutUsToolStripMenuItem.Text = "About Us";
            this.aboutUsToolStripMenuItem.Visible = false;
            // 
            // khaiBáoXuấtNhậpKhẩuToolStripMenuItem
            // 
            this.khaiBáoXuấtNhậpKhẩuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemDeclaration,
            this.mnExport,
            this.mnImport,
            this.vehicleSearch,
            this.addNewVehiceToolStripMenuItem,
            this.addVehicleChinese,
            this.mnuExportParking});
            this.khaiBáoXuấtNhậpKhẩuToolStripMenuItem.Name = "khaiBáoXuấtNhậpKhẩuToolStripMenuItem";
            this.khaiBáoXuấtNhậpKhẩuToolStripMenuItem.Size = new System.Drawing.Size(192, 25);
            this.khaiBáoXuấtNhậpKhẩuToolStripMenuItem.Text = "Khai báo xuất nhập khẩu";
            // 
            // menuitemDeclaration
            // 
            this.menuitemDeclaration.Image = global::ECustoms.Properties.Resources.list;
            this.menuitemDeclaration.Name = "menuitemDeclaration";
            this.menuitemDeclaration.Size = new System.Drawing.Size(313, 26);
            this.menuitemDeclaration.Text = "Danh sách tờ khai";
            this.menuitemDeclaration.Click += new System.EventHandler(this.menuitemDeclaration_Click);
            // 
            // mnExport
            // 
            this.mnExport.Image = global::ECustoms.Properties.Resources.export1;
            this.mnExport.Name = "mnExport";
            this.mnExport.Size = new System.Drawing.Size(313, 26);
            this.mnExport.Text = "Khai báo xuất cảnh";
            this.mnExport.Click += new System.EventHandler(this.mnExport_Click);
            // 
            // mnImport
            // 
            this.mnImport.Image = global::ECustoms.Properties.Resources.import;
            this.mnImport.Name = "mnImport";
            this.mnImport.Size = new System.Drawing.Size(313, 26);
            this.mnImport.Text = "Khai báo nhập cảnh";
            this.mnImport.Click += new System.EventHandler(this.mnImport_Click);
            // 
            // vehicleSearch
            // 
            this.vehicleSearch.Image = global::ECustoms.Properties.Resources.searchIcon;
            this.vehicleSearch.Name = "vehicleSearch";
            this.vehicleSearch.Size = new System.Drawing.Size(313, 26);
            this.vehicleSearch.Text = "Tìm kiếm phương tiện";
            this.vehicleSearch.Click += new System.EventHandler(this.vehicleSearch_Click);
            // 
            // addNewVehiceToolStripMenuItem
            // 
            this.addNewVehiceToolStripMenuItem.Image = global::ECustoms.Properties.Resources._001_01;
            this.addNewVehiceToolStripMenuItem.Name = "addNewVehiceToolStripMenuItem";
            this.addNewVehiceToolStripMenuItem.Size = new System.Drawing.Size(313, 26);
            this.addNewVehiceToolStripMenuItem.Text = "Thêm phương tiện xe không";
            this.addNewVehiceToolStripMenuItem.Click += new System.EventHandler(this.addNewVehiceToolStripMenuItem_Click);
            // 
            // addVehicleChinese
            // 
            this.addVehicleChinese.Image = global::ECustoms.Properties.Resources._001_01;
            this.addVehicleChinese.Name = "addVehicleChinese";
            this.addVehicleChinese.Size = new System.Drawing.Size(313, 26);
            this.addVehicleChinese.Text = "Thêm phương tiện xe Trung Quốc";
            this.addVehicleChinese.Visible = false;
            this.addVehicleChinese.Click += new System.EventHandler(this.addVehicleChinese_Click);
            // 
            // mnuExportParking
            // 
            this.mnuExportParking.Image = global::ECustoms.Properties.Resources.export;
            this.mnuExportParking.Name = "mnuExportParking";
            this.mnuExportParking.Size = new System.Drawing.Size(313, 26);
            this.mnuExportParking.Text = "Thêm xe vào bãi xuất";
            this.mnuExportParking.Click += new System.EventHandler(this.mnuExportParking_Click);
            // 
            // toolStripMenuReport
            // 
            this.toolStripMenuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnItemReport});
            this.toolStripMenuReport.Name = "toolStripMenuReport";
            this.toolStripMenuReport.Size = new System.Drawing.Size(76, 25);
            this.toolStripMenuReport.Text = "Báo cáo";
            // 
            // mnItemReport
            // 
            this.mnItemReport.Image = global::ECustoms.Properties.Resources.print_icon;
            this.mnItemReport.Name = "mnItemReport";
            this.mnItemReport.Size = new System.Drawing.Size(151, 26);
            this.mnItemReport.Text = "In báo cáo";
            this.mnItemReport.Click += new System.EventHandler(this.mnItemReport_Click);
            // 
            // menuManageInformation
            // 
            this.menuManageInformation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnReview,
            this.mnReviewSummary});
            this.menuManageInformation.Name = "menuManageInformation";
            this.menuManageInformation.Size = new System.Drawing.Size(143, 25);
            this.menuManageInformation.Text = "Quản lý thông tin";
            // 
            // mnReview
            // 
            this.mnReview.Image = global::ECustoms.Properties.Resources._4469;
            this.mnReview.Name = "mnReview";
            this.mnReview.Size = new System.Drawing.Size(336, 26);
            this.mnReview.Text = "Danh sách thông tin đề nghị kiểm tra";
            this.mnReview.Click += new System.EventHandler(this.mnReview_Click);
            // 
            // mnReviewSummary
            // 
            this.mnReviewSummary.Image = global::ECustoms.Properties.Resources._5373;
            this.mnReviewSummary.Name = "mnReviewSummary";
            this.mnReviewSummary.Size = new System.Drawing.Size(336, 26);
            this.mnReviewSummary.Text = "Tổng hợp kết quả kiểm tra";
            this.mnReviewSummary.Click += new System.EventHandler(this.mnReviewSummary_Click);
            // 
            // quảnLýHàngNTXCKToolStripMenuItem
            // 
            this.quảnLýHàngNTXCKToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xuấtKhẩuChuyểnCửaKhẩuToolStripMenuItem,
            this.nhậpKhẩuChuyểnCửaKhẩuToolStripMenuItem,
            this.hàngTạmNhậpTáiXuấtToolStripMenuItem});
            this.quảnLýHàngNTXCKToolStripMenuItem.Name = "quảnLýHàngNTXCKToolStripMenuItem";
            this.quảnLýHàngNTXCKToolStripMenuItem.Size = new System.Drawing.Size(174, 25);
            this.quảnLýHàngNTXCKToolStripMenuItem.Text = "Quản lý hàng NTX, CK";
            // 
            // xuấtKhẩuChuyểnCửaKhẩuToolStripMenuItem
            // 
            this.xuấtKhẩuChuyểnCửaKhẩuToolStripMenuItem.Name = "xuấtKhẩuChuyểnCửaKhẩuToolStripMenuItem";
            this.xuấtKhẩuChuyểnCửaKhẩuToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.xuấtKhẩuChuyểnCửaKhẩuToolStripMenuItem.Text = "Xuất khẩu chuyển cửa khẩu";
            this.xuấtKhẩuChuyểnCửaKhẩuToolStripMenuItem.Click += new System.EventHandler(this.xuấtKhẩuChuyểnCửaKhẩuToolStripMenuItem_Click);
            // 
            // nhậpKhẩuChuyểnCửaKhẩuToolStripMenuItem
            // 
            this.nhậpKhẩuChuyểnCửaKhẩuToolStripMenuItem.Name = "nhậpKhẩuChuyểnCửaKhẩuToolStripMenuItem";
            this.nhậpKhẩuChuyểnCửaKhẩuToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.nhậpKhẩuChuyểnCửaKhẩuToolStripMenuItem.Text = "Nhập khẩu chuyển cửa khẩu";
            this.nhậpKhẩuChuyểnCửaKhẩuToolStripMenuItem.Click += new System.EventHandler(this.nhậpKhẩuChuyểnCửaKhẩuToolStripMenuItem_Click);
            // 
            // hàngTạmNhậpTáiXuấtToolStripMenuItem
            // 
            this.hàngTạmNhậpTáiXuấtToolStripMenuItem.Name = "hàngTạmNhậpTáiXuấtToolStripMenuItem";
            this.hàngTạmNhậpTáiXuấtToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.hàngTạmNhậpTáiXuấtToolStripMenuItem.Text = "Hàng tạm nhập tái xuất";
            this.hàngTạmNhậpTáiXuấtToolStripMenuItem.Click += new System.EventHandler(this.hàngTạmNhậpTáiXuấtToolStripMenuItem_Click);
            // 
            // mnuFeeManagement
            // 
            this.mnuFeeManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVehidleType,
            this.menuGetFee,
            this.mnuFeeReport,
            this.mnuFeeSetting});
            this.mnuFeeManagement.Name = "mnuFeeManagement";
            this.mnuFeeManagement.Size = new System.Drawing.Size(133, 25);
            this.mnuFeeManagement.Text = "Quản lý tính phí";
            // 
            // mnuVehidleType
            // 
            this.mnuVehidleType.Name = "mnuVehidleType";
            this.mnuVehidleType.Size = new System.Drawing.Size(288, 26);
            this.mnuVehidleType.Text = "Loại phương tiện";
            this.mnuVehidleType.Click += new System.EventHandler(this.mnuVehidleType_Click);
            // 
            // menuGetFee
            // 
            this.menuGetFee.Name = "menuGetFee";
            this.menuGetFee.Size = new System.Drawing.Size(288, 26);
            this.menuGetFee.Text = "Thu phí";
            this.menuGetFee.Click += new System.EventHandler(this.menuGetFee_Click);
            // 
            // mnuFeeReport
            // 
            this.mnuFeeReport.Name = "mnuFeeReport";
            this.mnuFeeReport.Size = new System.Drawing.Size(288, 26);
            this.mnuFeeReport.Text = "Báo cáo thu phí";
            this.mnuFeeReport.Click += new System.EventHandler(this.mnuFeeReport_Click);
            // 
            // mnuFeeSetting
            // 
            this.mnuFeeSetting.Name = "mnuFeeSetting";
            this.mnuFeeSetting.Size = new System.Drawing.Size(288, 26);
            this.mnuFeeSetting.Text = "Cấu hình tính phí phương tiện";
            this.mnuFeeSetting.Click += new System.EventHandler(this.mnuFeeSetting_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hướngDẫnSửDụngToolStripMenuItem});
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(81, 25);
            this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // hướngDẫnSửDụngToolStripMenuItem
            // 
            this.hướngDẫnSửDụngToolStripMenuItem.Name = "hướngDẫnSửDụngToolStripMenuItem";
            this.hướngDẫnSửDụngToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.hướngDẫnSửDụngToolStripMenuItem.Text = "Hướng dẫn sử dụng";
            this.hướngDẫnSửDụngToolStripMenuItem.Click += new System.EventHandler(this.hướngDẫnSửDụngToolStripMenuItem_Click);
            // 
            // inTicketToolStripMenuItem
            // 
            this.inTicketToolStripMenuItem.Name = "inTicketToolStripMenuItem";
            this.inTicketToolStripMenuItem.Size = new System.Drawing.Size(76, 25);
            this.inTicketToolStripMenuItem.Text = "In ticket";
            this.inTicketToolStripMenuItem.Click += new System.EventHandler(this.inTicketToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripLabelWelcome,
            this.tsExport,
            this.tsImport,
            this.toolStripButtonSearch,
            this.toolStripButtonListdeclarace,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 29);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1211, 30);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolstripLabelWelcome
            // 
            this.toolstripLabelWelcome.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolstripLabelWelcome.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolstripLabelWelcome.ForeColor = System.Drawing.Color.Red;
            this.toolstripLabelWelcome.Name = "toolstripLabelWelcome";
            this.toolstripLabelWelcome.Size = new System.Drawing.Size(93, 27);
            this.toolstripLabelWelcome.Text = "toolStripLabel1";
            // 
            // tsExport
            // 
            this.tsExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsExport.Image = global::ECustoms.Properties.Resources.export1;
            this.tsExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExport.Name = "tsExport";
            this.tsExport.Size = new System.Drawing.Size(23, 27);
            this.tsExport.Text = "toolStripButton1";
            this.tsExport.ToolTipText = "Khai báo xuất cảnh";
            this.tsExport.Click += new System.EventHandler(this.tsExport_Click);
            // 
            // tsImport
            // 
            this.tsImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsImport.Image = global::ECustoms.Properties.Resources.import;
            this.tsImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsImport.Name = "tsImport";
            this.tsImport.Size = new System.Drawing.Size(23, 27);
            this.tsImport.Text = "toolStripButton1";
            this.tsImport.ToolTipText = "Khai báo nhập cảnh";
            this.tsImport.Click += new System.EventHandler(this.tsImport_Click);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearch.Image = global::ECustoms.Properties.Resources.searchIcon;
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(23, 27);
            this.toolStripButtonSearch.Text = "toolStripButton2";
            this.toolStripButtonSearch.ToolTipText = "Tìm kiếm phương tiện";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // toolStripButtonListdeclarace
            // 
            this.toolStripButtonListdeclarace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonListdeclarace.Image = global::ECustoms.Properties.Resources.list;
            this.toolStripButtonListdeclarace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonListdeclarace.Name = "toolStripButtonListdeclarace";
            this.toolStripButtonListdeclarace.Size = new System.Drawing.Size(23, 27);
            this.toolStripButtonListdeclarace.Text = "toolStripButton3";
            this.toolStripButtonListdeclarace.ToolTipText = "Danh sách tờ khai";
            this.toolStripButtonListdeclarace.Click += new System.EventHandler(this.toolStripButtonListdeclarace_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 27);
            this.toolStripButton1.Text = "Đã hoàn thành thủ tục hải quan";
            this.toolStripButton1.ToolTipText = "Đã hoàn thành thủ tục hải quan";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // viewAllVehicleTableAdapter1
            // 
            this.viewAllVehicleTableAdapter1.ClearBeforeFill = true;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ECustoms.Properties.Resources.logoBackgound;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1211, 723);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mnMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnMain;
            this.Name = "frmMainForm";
            this.Text = "Quản lý phương tiện xuất nhập biên";
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.mnMain.ResumeLayout(false);
            this.mnMain.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnMain;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khaiBáoXuấtNhậpKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnExport;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolstripLabelWelcome;
        private System.Windows.Forms.ToolStripMenuItem vehicleSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuitemExit;
        private System.Windows.Forms.ToolStripMenuItem menuitemLogout;
        private System.Windows.Forms.ToolStripMenuItem menuitemDeclaration;
        private System.Windows.Forms.ToolStripMenuItem menuitemUser;
        private System.Windows.Forms.ToolStripButton tsExport;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonListdeclarace;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewVehiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuReport;
        private System.Windows.Forms.ToolStripMenuItem mnItemReport;
        private System.Windows.Forms.ToolStripMenuItem mnImport;
        private System.Windows.Forms.ToolStripButton tsImport;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hướngDẫnSửDụngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuManageInformation;
        private System.Windows.Forms.ToolStripMenuItem mnReviewSummary;
        private System.Windows.Forms.ToolStripMenuItem mnReview;
        private System.Windows.Forms.ToolStripMenuItem mnGroup;
        private System.Windows.Forms.ToolStripMenuItem inTicketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHàngNTXCKToolStripMenuItem;
        private DataSet2TableAdapters.ViewAllVehicleTableAdapter viewAllVehicleTableAdapter1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem xuấtKhẩuChuyểnCửaKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpKhẩuChuyểnCửaKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hàngTạmNhậpTáiXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVehicleChinese;
        private System.Windows.Forms.ToolStripMenuItem mnuExportParking;
        private System.Windows.Forms.ToolStripMenuItem mnuFeeManagement;
        private System.Windows.Forms.ToolStripMenuItem mnuVehidleType;
        private System.Windows.Forms.ToolStripMenuItem menuGetFee;
        private System.Windows.Forms.ToolStripMenuItem mnuFeeReport;
        private System.Windows.Forms.ToolStripMenuItem mnuFeeSetting;
    }
}