namespace TechLink.Views
{
    partial class DatabaseRegistration
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnAddToDest = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddToSource = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.opt2 = new DevExpress.XtraEditors.CheckEdit();
            this.opt1 = new DevExpress.XtraEditors.CheckEdit();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.btnTryConnect = new DevExpress.XtraEditors.SimpleButton();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.teckLinkErrorProvider1 = new TechLink.Views.TeckLinkErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opt2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teckLinkErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.PaddingLeft = 10;
            this.labelX1.Size = new System.Drawing.Size(723, 27);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "Create connection";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnAddToDest);
            this.groupControl1.Controls.Add(this.btnAddToSource);
            this.groupControl1.Controls.Add(this.xtraTabControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 27);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(354, 359);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Server info";
            // 
            // btnAddToDest
            // 
            this.btnAddToDest.Appearance.Options.UseTextOptions = true;
            this.btnAddToDest.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btnAddToDest.Location = new System.Drawing.Point(173, 326);
            this.btnAddToDest.Name = "btnAddToDest";
            this.btnAddToDest.Size = new System.Drawing.Size(165, 23);
            this.btnAddToDest.TabIndex = 14;
            this.btnAddToDest.Text = "Add selected DB to dest >>";
            this.btnAddToDest.Click += new System.EventHandler(this.btnAddToDest_Click);
            // 
            // btnAddToSource
            // 
            this.btnAddToSource.Appearance.Options.UseTextOptions = true;
            this.btnAddToSource.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btnAddToSource.Location = new System.Drawing.Point(173, 297);
            this.btnAddToSource.Name = "btnAddToSource";
            this.btnAddToSource.Size = new System.Drawing.Size(165, 23);
            this.btnAddToSource.TabIndex = 13;
            this.btnAddToSource.Text = "Add selected DB to source >>";
            this.btnAddToSource.Click += new System.EventHandler(this.btnAddToSource_Click);
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Location = new System.Drawing.Point(11, 37);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl2.Size = new System.Drawing.Size(332, 254);
            this.xtraTabControl2.TabIndex = 1;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2});
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.opt2);
            this.xtraTabPage2.Controls.Add(this.opt1);
            this.xtraTabPage2.Controls.Add(this.radioGroup1);
            this.xtraTabPage2.Controls.Add(this.btnTryConnect);
            this.xtraTabPage2.Controls.Add(this.labelX2);
            this.xtraTabPage2.Controls.Add(this.labelX3);
            this.xtraTabPage2.Controls.Add(this.txtServer);
            this.xtraTabPage2.Controls.Add(this.labelX4);
            this.xtraTabPage2.Controls.Add(this.txtUser);
            this.xtraTabPage2.Controls.Add(this.txtPass);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(326, 226);
            this.xtraTabPage2.Text = "Thông tin máy chủ";
            // 
            // opt2
            // 
            this.opt2.Location = new System.Drawing.Point(32, 82);
            this.opt2.Name = "opt2";
            this.opt2.Properties.Caption = "Use a specific User and Password";
            this.opt2.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.opt2.Properties.RadioGroupIndex = 0;
            this.opt2.Size = new System.Drawing.Size(260, 19);
            this.opt2.TabIndex = 17;
            this.opt2.TabStop = false;
            // 
            // opt1
            // 
            this.opt1.EditValue = true;
            this.opt1.Location = new System.Drawing.Point(32, 60);
            this.opt1.Name = "opt1";
            this.opt1.Properties.Caption = "Integrated Security";
            this.opt1.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.opt1.Properties.RadioGroupIndex = 0;
            this.opt1.Size = new System.Drawing.Size(260, 19);
            this.opt1.TabIndex = 16;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(22, 48);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Size = new System.Drawing.Size(286, 63);
            this.radioGroup1.TabIndex = 15;
            // 
            // btnTryConnect
            // 
            this.btnTryConnect.Location = new System.Drawing.Point(233, 184);
            this.btnTryConnect.Name = "btnTryConnect";
            this.btnTryConnect.Size = new System.Drawing.Size(75, 23);
            this.btnTryConnect.TabIndex = 12;
            this.btnTryConnect.Text = "Kết nối";
            this.btnTryConnect.Click += new System.EventHandler(this.btnTryConnect_Click);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(22, 20);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(108, 20);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "SQL server name:";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(22, 115);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 20);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "User:";
            // 
            // txtServer
            // 
            // 
            // 
            // 
            this.txtServer.Border.Class = "TextBoxBorder";
            this.txtServer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtServer.Location = new System.Drawing.Point(130, 22);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(178, 20);
            this.txtServer.TabIndex = 1;
            this.txtServer.Tag = "required";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(22, 141);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 20);
            this.labelX4.TabIndex = 4;
            this.labelX4.Text = "Password:";
            // 
            // txtUser
            // 
            // 
            // 
            // 
            this.txtUser.Border.Class = "TextBoxBorder";
            this.txtUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUser.Location = new System.Drawing.Point(115, 117);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(193, 20);
            this.txtUser.TabIndex = 3;
            this.txtUser.Tag = "required";
            // 
            // txtPass
            // 
            // 
            // 
            // 
            this.txtPass.Border.Class = "TextBoxBorder";
            this.txtPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPass.Location = new System.Drawing.Point(115, 143);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(193, 20);
            this.txtPass.TabIndex = 5;
            this.txtPass.Tag = "required";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 21);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(365, 336);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(354, 27);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(369, 359);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Databases";
            // 
            // teckLinkErrorProvider1
            // 
            this.teckLinkErrorProvider1.ContainerControl = this;
            // 
            // DatabaseRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelX1);
            this.Name = "DatabaseRegistration";
            this.Size = new System.Drawing.Size(723, 386);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.opt2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opt1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teckLinkErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.CheckEdit opt2;
        private DevExpress.XtraEditors.CheckEdit opt1;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.SimpleButton btnTryConnect;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtServer;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUser;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPass;
        private TeckLinkErrorProvider teckLinkErrorProvider1;
        private DevExpress.XtraEditors.SimpleButton btnAddToDest;
        private DevExpress.XtraEditors.SimpleButton btnAddToSource;
    }
}
