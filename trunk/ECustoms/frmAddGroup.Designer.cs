namespace ECustoms
{
    partial class frmAddGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddGroup));
            this.grbUser = new System.Windows.Forms.GroupBox();
            this.tabControlGroup = new System.Windows.Forms.TabControl();
            this.tabPageGroup = new System.Windows.Forms.TabPage();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageUser = new System.Windows.Forms.TabPage();
            this.grvUser = new System.Windows.Forms.DataGridView();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageRights = new System.Windows.Forms.TabPage();
            this.chbCheckAllPermission = new System.Windows.Forms.CheckBox();
            this.grvPermission = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUpdatePermission = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grbUser.SuspendLayout();
            this.tabControlGroup.SuspendLayout();
            this.tabPageGroup.SuspendLayout();
            this.tabPageUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvUser)).BeginInit();
            this.tabPageRights.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermission)).BeginInit();
            this.SuspendLayout();
            // 
            // grbUser
            // 
            this.grbUser.Controls.Add(this.tabControlGroup);
            this.grbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbUser.Location = new System.Drawing.Point(12, 12);
            this.grbUser.Name = "grbUser";
            this.grbUser.Size = new System.Drawing.Size(735, 412);
            this.grbUser.TabIndex = 2;
            this.grbUser.TabStop = false;
            this.grbUser.Text = "Danh sách nhóm";
            // 
            // tabControlGroup
            // 
            this.tabControlGroup.Controls.Add(this.tabPageGroup);
            this.tabControlGroup.Controls.Add(this.tabPageUser);
            this.tabControlGroup.Controls.Add(this.tabPageRights);
            this.tabControlGroup.Location = new System.Drawing.Point(6, 25);
            this.tabControlGroup.Name = "tabControlGroup";
            this.tabControlGroup.SelectedIndex = 0;
            this.tabControlGroup.Size = new System.Drawing.Size(713, 381);
            this.tabControlGroup.TabIndex = 0;
            this.tabControlGroup.Click += new System.EventHandler(this.tabControlGroup_Click);
            // 
            // tabPageGroup
            // 
            this.tabPageGroup.Controls.Add(this.txtName);
            this.tabPageGroup.Controls.Add(this.label1);
            this.tabPageGroup.Location = new System.Drawing.Point(4, 29);
            this.tabPageGroup.Name = "tabPageGroup";
            this.tabPageGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGroup.Size = new System.Drawing.Size(705, 348);
            this.tabPageGroup.TabIndex = 0;
            this.tabPageGroup.Text = "Nhóm";
            this.tabPageGroup.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(101, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(258, 26);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên nhóm";
            // 
            // tabPageUser
            // 
            this.tabPageUser.Controls.Add(this.btnDelete);
            this.tabPageUser.Controls.Add(this.btnAdd);
            this.tabPageUser.Controls.Add(this.grvUser);
            this.tabPageUser.Location = new System.Drawing.Point(4, 29);
            this.tabPageUser.Name = "tabPageUser";
            this.tabPageUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUser.Size = new System.Drawing.Size(705, 348);
            this.tabPageUser.TabIndex = 1;
            this.tabPageUser.Text = "Người dùng";
            this.tabPageUser.UseVisualStyleBackColor = true;
            // 
            // grvUser
            // 
            this.grvUser.AllowUserToAddRows = false;
            this.grvUser.AllowUserToDeleteRows = false;
            this.grvUser.AllowUserToOrderColumns = true;
            this.grvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.UserName,
            this.FirstName,
            this.Email,
            this.Address,
            this.PhoneNumber});
            this.grvUser.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grvUser.Location = new System.Drawing.Point(6, 10);
            this.grvUser.Name = "grvUser";
            this.grvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvUser.Size = new System.Drawing.Size(693, 294);
            this.grvUser.TabIndex = 1;
            this.grvUser.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grvUser_ColumnHeaderMouseClick);
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.UserID.Visible = false;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "Tên truy cập";
            this.UserName.Name = "UserName";
            this.UserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.UserName.Width = 150;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "UserFullName";
            this.FirstName.HeaderText = "Họ và tên";
            this.FirstName.Name = "FirstName";
            this.FirstName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.FirstName.Width = 150;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Địa chỉ";
            this.Address.Name = "Address";
            this.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Address.Width = 150;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.DataPropertyName = "PhoneNumber";
            this.PhoneNumber.HeaderText = "Điện thoại";
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.ReadOnly = true;
            this.PhoneNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.PhoneNumber.Width = 150;
            // 
            // tabPageRights
            // 
            this.tabPageRights.Controls.Add(this.chbCheckAllPermission);
            this.tabPageRights.Controls.Add(this.grvPermission);
            this.tabPageRights.Controls.Add(this.btnReset);
            this.tabPageRights.Controls.Add(this.btnUpdatePermission);
            this.tabPageRights.Location = new System.Drawing.Point(4, 29);
            this.tabPageRights.Name = "tabPageRights";
            this.tabPageRights.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRights.Size = new System.Drawing.Size(705, 348);
            this.tabPageRights.TabIndex = 2;
            this.tabPageRights.Text = "Quyền truy cập";
            this.tabPageRights.UseVisualStyleBackColor = true;
            // 
            // chbCheckAllPermission
            // 
            this.chbCheckAllPermission.AutoSize = true;
            this.chbCheckAllPermission.Location = new System.Drawing.Point(123, 15);
            this.chbCheckAllPermission.Name = "chbCheckAllPermission";
            this.chbCheckAllPermission.Size = new System.Drawing.Size(15, 14);
            this.chbCheckAllPermission.TabIndex = 13;
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
            this.GroupID,
            this.GroupName});
            this.grvPermission.Location = new System.Drawing.Point(6, 6);
            this.grvPermission.Name = "grvPermission";
            this.grvPermission.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvPermission.Size = new System.Drawing.Size(693, 296);
            this.grvPermission.TabIndex = 2;
            // 
            // Check
            // 
            this.Check.DataPropertyName = "Check";
            this.Check.HeaderText = "Chọn";
            this.Check.Name = "Check";
            // 
            // GroupID
            // 
            this.GroupID.DataPropertyName = "PermissionID";
            this.GroupID.HeaderText = "PermissonID";
            this.GroupID.Name = "GroupID";
            this.GroupID.ReadOnly = true;
            this.GroupID.Visible = false;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "Permission";
            this.GroupName.HeaderText = "Quyền truy cập";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.Width = 500;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ECustoms.Properties.Resources.Exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(665, 430);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Thoát";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::ECustoms.Properties.Resources._001_05;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(175, 309);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 33);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::ECustoms.Properties.Resources._001_01;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(6, 309);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(163, 33);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Thêm người dùng";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnReset
            // 
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::ECustoms.Properties.Resources._001_39;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(175, 308);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(102, 33);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Làm lại";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnUpdatePermission
            // 
            this.btnUpdatePermission.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdatePermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePermission.Image = global::ECustoms.Properties.Resources._001_01;
            this.btnUpdatePermission.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdatePermission.Location = new System.Drawing.Point(6, 308);
            this.btnUpdatePermission.Name = "btnUpdatePermission";
            this.btnUpdatePermission.Size = new System.Drawing.Size(163, 33);
            this.btnUpdatePermission.TabIndex = 5;
            this.btnUpdatePermission.Text = "Cập nhật quyền";
            this.btnUpdatePermission.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdatePermission.UseVisualStyleBackColor = true;
            this.btnUpdatePermission.Click += new System.EventHandler(this.btnUpdatePermission_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ECustoms.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(594, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 28);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 470);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grbUser);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddGroup";
            this.Text = "frmAddGroup";
            this.Load += new System.EventHandler(this.frmAddGroup_Load);
            this.grbUser.ResumeLayout(false);
            this.tabControlGroup.ResumeLayout(false);
            this.tabPageGroup.ResumeLayout(false);
            this.tabPageGroup.PerformLayout();
            this.tabPageUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvUser)).EndInit();
            this.tabPageRights.ResumeLayout(false);
            this.tabPageRights.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermission)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbUser;
        private System.Windows.Forms.TabControl tabControlGroup;
        private System.Windows.Forms.TabPage tabPageGroup;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tabPageUser;
        private System.Windows.Forms.TabPage tabPageRights;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView grvUser;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView grvPermission;
        private System.Windows.Forms.Button btnUpdatePermission;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.CheckBox chbCheckAllPermission;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;

    }
}