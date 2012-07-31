namespace ECustoms
{
    partial class frmAddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUser));
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtRetypePassword = new System.Windows.Forms.TextBox();
            this.lblRetypePassword = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblActive = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.tabGroup = new System.Windows.Forms.TabPage();
            this.chbCheckAllGroup = new System.Windows.Forms.CheckBox();
            this.grvGroup = new System.Windows.Forms.DataGridView();
            this.checkGroup = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPermission = new System.Windows.Forms.TabPage();
            this.chbCheckAllPermission = new System.Windows.Forms.CheckBox();
            this.grvPermission = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdateListGroup = new System.Windows.Forms.Button();
            this.tbnResetListGroup = new System.Windows.Forms.Button();
            this.btnResetPermission = new System.Windows.Forms.Button();
            this.btnUpdatePermission = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.tabGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvGroup)).BeginInit();
            this.tabPermission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermission)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(30, 14);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(96, 20);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Tên truy cập";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(185, 11);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(430, 26);
            this.txtUserName.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(185, 171);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(430, 26);
            this.txtName.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(30, 171);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(77, 20);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Họ và tên";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(185, 51);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(430, 26);
            this.txtPassword.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(32, 51);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(75, 20);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Mật khẩu";
            // 
            // txtRetypePassword
            // 
            this.txtRetypePassword.Location = new System.Drawing.Point(185, 91);
            this.txtRetypePassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRetypePassword.Name = "txtRetypePassword";
            this.txtRetypePassword.PasswordChar = '*';
            this.txtRetypePassword.Size = new System.Drawing.Size(430, 26);
            this.txtRetypePassword.TabIndex = 3;
            // 
            // lblRetypePassword
            // 
            this.lblRetypePassword.AutoSize = true;
            this.lblRetypePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetypePassword.Location = new System.Drawing.Point(32, 91);
            this.lblRetypePassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRetypePassword.Name = "lblRetypePassword";
            this.lblRetypePassword.Size = new System.Drawing.Size(136, 20);
            this.lblRetypePassword.TabIndex = 8;
            this.lblRetypePassword.Text = "Nhập lại mật khẩu";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(185, 131);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(430, 26);
            this.txtEmail.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(30, 131);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 20);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(185, 211);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(430, 65);
            this.txtAddress.TabIndex = 6;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(30, 211);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(57, 20);
            this.lblAddress.TabIndex = 12;
            this.lblAddress.Text = "Địa chỉ";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(185, 291);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(430, 26);
            this.txtPhone.TabIndex = 7;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(32, 291);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(81, 20);
            this.lblPhone.TabIndex = 14;
            this.lblPhone.Text = "Điện thoại";
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActive.Location = new System.Drawing.Point(32, 336);
            this.lblActive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(123, 20);
            this.lblActive.TabIndex = 18;
            this.lblActive.Text = "Được hoạt động";
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(185, 335);
            this.cbActive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(15, 14);
            this.cbActive.TabIndex = 9;
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabUser);
            this.tabControl1.Controls.Add(this.tabGroup);
            this.tabControl1.Controls.Add(this.tabPermission);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(635, 512);
            this.tabControl1.TabIndex = 19;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.lblUsername);
            this.tabUser.Controls.Add(this.txtUserName);
            this.tabUser.Controls.Add(this.btnClose);
            this.tabUser.Controls.Add(this.lblName);
            this.tabUser.Controls.Add(this.btnUpdate);
            this.tabUser.Controls.Add(this.txtName);
            this.tabUser.Controls.Add(this.btnAdd);
            this.tabUser.Controls.Add(this.lblPassword);
            this.tabUser.Controls.Add(this.cbActive);
            this.tabUser.Controls.Add(this.txtPassword);
            this.tabUser.Controls.Add(this.lblActive);
            this.tabUser.Controls.Add(this.lblRetypePassword);
            this.tabUser.Controls.Add(this.txtRetypePassword);
            this.tabUser.Controls.Add(this.txtPhone);
            this.tabUser.Controls.Add(this.lblEmail);
            this.tabUser.Controls.Add(this.lblPhone);
            this.tabUser.Controls.Add(this.txtEmail);
            this.tabUser.Controls.Add(this.txtAddress);
            this.tabUser.Controls.Add(this.lblAddress);
            this.tabUser.Location = new System.Drawing.Point(4, 29);
            this.tabUser.Name = "tabUser";
            this.tabUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabUser.Size = new System.Drawing.Size(627, 479);
            this.tabUser.TabIndex = 0;
            this.tabUser.Text = "Thông tin người dùng";
            this.tabUser.UseVisualStyleBackColor = true;
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.chbCheckAllGroup);
            this.tabGroup.Controls.Add(this.btnUpdateListGroup);
            this.tabGroup.Controls.Add(this.tbnResetListGroup);
            this.tabGroup.Controls.Add(this.grvGroup);
            this.tabGroup.Location = new System.Drawing.Point(4, 29);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup.Size = new System.Drawing.Size(627, 479);
            this.tabGroup.TabIndex = 1;
            this.tabGroup.Text = "Nhóm của người dùng";
            this.tabGroup.UseVisualStyleBackColor = true;
            // 
            // chbCheckAllGroup
            // 
            this.chbCheckAllGroup.AutoSize = true;
            this.chbCheckAllGroup.Location = new System.Drawing.Point(127, 14);
            this.chbCheckAllGroup.Name = "chbCheckAllGroup";
            this.chbCheckAllGroup.Size = new System.Drawing.Size(15, 14);
            this.chbCheckAllGroup.TabIndex = 20;
            this.chbCheckAllGroup.UseVisualStyleBackColor = true;
            this.chbCheckAllGroup.CheckedChanged += new System.EventHandler(this.chbCheckAllGroup_CheckedChanged);
            // 
            // grvGroup
            // 
            this.grvGroup.AllowUserToAddRows = false;
            this.grvGroup.AllowUserToDeleteRows = false;
            this.grvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkGroup,
            this.GroupID,
            this.GroupName});
            this.grvGroup.Location = new System.Drawing.Point(4, 6);
            this.grvGroup.Name = "grvGroup";
            this.grvGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvGroup.Size = new System.Drawing.Size(617, 412);
            this.grvGroup.TabIndex = 2;
            // 
            // checkGroup
            // 
            this.checkGroup.HeaderText = "Chọn";
            this.checkGroup.Name = "checkGroup";
            // 
            // GroupID
            // 
            this.GroupID.DataPropertyName = "GroupID";
            this.GroupID.HeaderText = "GroupID";
            this.GroupID.Name = "GroupID";
            this.GroupID.ReadOnly = true;
            this.GroupID.Visible = false;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "GroupName";
            this.GroupName.HeaderText = "Tên nhóm";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.Width = 475;
            // 
            // tabPermission
            // 
            this.tabPermission.Controls.Add(this.chbCheckAllPermission);
            this.tabPermission.Controls.Add(this.grvPermission);
            this.tabPermission.Controls.Add(this.btnResetPermission);
            this.tabPermission.Controls.Add(this.btnUpdatePermission);
            this.tabPermission.Location = new System.Drawing.Point(4, 29);
            this.tabPermission.Name = "tabPermission";
            this.tabPermission.Size = new System.Drawing.Size(627, 479);
            this.tabPermission.TabIndex = 2;
            this.tabPermission.Text = "Quyền truy cập";
            this.tabPermission.UseVisualStyleBackColor = true;
            // 
            // chbCheckAllPermission
            // 
            this.chbCheckAllPermission.AutoSize = true;
            this.chbCheckAllPermission.Location = new System.Drawing.Point(127, 14);
            this.chbCheckAllPermission.Name = "chbCheckAllPermission";
            this.chbCheckAllPermission.Size = new System.Drawing.Size(15, 14);
            this.chbCheckAllPermission.TabIndex = 19;
            this.chbCheckAllPermission.UseVisualStyleBackColor = true;
            this.chbCheckAllPermission.CheckedChanged += new System.EventHandler(this.chbCheckAllPermission_CheckedChanged);
            // 
            // grvPermission
            // 
            this.grvPermission.AllowUserToAddRows = false;
            this.grvPermission.AllowUserToDeleteRows = false;
            this.grvPermission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvPermission.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.grvPermission.Location = new System.Drawing.Point(4, 6);
            this.grvPermission.Name = "grvPermission";
            this.grvPermission.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvPermission.Size = new System.Drawing.Size(620, 412);
            this.grvPermission.TabIndex = 13;
            // 
            // Check
            // 
            this.Check.DataPropertyName = "Check";
            this.Check.HeaderText = "Chọn";
            this.Check.Name = "Check";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PermissionID";
            this.dataGridViewTextBoxColumn1.HeaderText = "PermissonID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Permission";
            this.dataGridViewTextBoxColumn2.HeaderText = "Quyền truy cập";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 475;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ECustoms.Properties.Resources.Exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(526, 438);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 28);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Thoát";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = global::ECustoms.Properties.Resources.edit;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(416, 438);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(102, 28);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::ECustoms.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(301, 438);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 28);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdateListGroup
            // 
            this.btnUpdateListGroup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdateListGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateListGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateListGroup.Image = global::ECustoms.Properties.Resources.edit;
            this.btnUpdateListGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateListGroup.Location = new System.Drawing.Point(366, 432);
            this.btnUpdateListGroup.Name = "btnUpdateListGroup";
            this.btnUpdateListGroup.Size = new System.Drawing.Size(147, 28);
            this.btnUpdateListGroup.TabIndex = 17;
            this.btnUpdateListGroup.Text = "Cập nhật nhóm";
            this.btnUpdateListGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateListGroup.UseVisualStyleBackColor = true;
            this.btnUpdateListGroup.Click += new System.EventHandler(this.btnUpdateListGroup_Click);
            // 
            // tbnResetListGroup
            // 
            this.tbnResetListGroup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tbnResetListGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbnResetListGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbnResetListGroup.Image = global::ECustoms.Properties.Resources.undo;
            this.tbnResetListGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbnResetListGroup.Location = new System.Drawing.Point(519, 432);
            this.tbnResetListGroup.Name = "tbnResetListGroup";
            this.tbnResetListGroup.Size = new System.Drawing.Size(89, 28);
            this.tbnResetListGroup.TabIndex = 16;
            this.tbnResetListGroup.Text = "Làm lại";
            this.tbnResetListGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tbnResetListGroup.UseVisualStyleBackColor = true;
            this.tbnResetListGroup.Click += new System.EventHandler(this.tbnResetListGroup_Click);
            // 
            // btnResetPermission
            // 
            this.btnResetPermission.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnResetPermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPermission.Image = global::ECustoms.Properties.Resources.undo;
            this.btnResetPermission.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetPermission.Location = new System.Drawing.Point(519, 433);
            this.btnResetPermission.Name = "btnResetPermission";
            this.btnResetPermission.Size = new System.Drawing.Size(92, 28);
            this.btnResetPermission.TabIndex = 15;
            this.btnResetPermission.Text = "Làm lại";
            this.btnResetPermission.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetPermission.UseVisualStyleBackColor = true;
            this.btnResetPermission.Click += new System.EventHandler(this.btnResetPermission_Click);
            // 
            // btnUpdatePermission
            // 
            this.btnUpdatePermission.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdatePermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePermission.Image = global::ECustoms.Properties.Resources.edit;
            this.btnUpdatePermission.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdatePermission.Location = new System.Drawing.Point(364, 433);
            this.btnUpdatePermission.Name = "btnUpdatePermission";
            this.btnUpdatePermission.Size = new System.Drawing.Size(149, 28);
            this.btnUpdatePermission.TabIndex = 14;
            this.btnUpdatePermission.Text = "Cập nhật quyền";
            this.btnUpdatePermission.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdatePermission.UseVisualStyleBackColor = true;
            this.btnUpdatePermission.Click += new System.EventHandler(this.btnUpdatePermission_Click_1);
            // 
            // frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 539);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddUser";
            this.Text = "Thông tin người dùng";
            this.Load += new System.EventHandler(this.frmAddUser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            this.tabUser.PerformLayout();
            this.tabGroup.ResumeLayout(false);
            this.tabGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvGroup)).EndInit();
            this.tabPermission.ResumeLayout(false);
            this.tabPermission.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermission)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtRetypePassword;
        private System.Windows.Forms.Label lblRetypePassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.TabPage tabGroup;
        private System.Windows.Forms.TabPage tabPermission;
        private System.Windows.Forms.DataGridView grvGroup;
        private System.Windows.Forms.DataGridView grvPermission;
        private System.Windows.Forms.Button btnUpdateListGroup;
        private System.Windows.Forms.Button tbnResetListGroup;
        private System.Windows.Forms.Button btnResetPermission;
        private System.Windows.Forms.Button btnUpdatePermission;
        private System.Windows.Forms.CheckBox chbCheckAllPermission;
        private System.Windows.Forms.CheckBox chbCheckAllGroup;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}