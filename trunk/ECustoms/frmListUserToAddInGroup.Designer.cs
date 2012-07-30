namespace ECustoms
{
  partial class frmListUserToAddInGroup
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListUserToAddInGroup));
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.btnSearch = new System.Windows.Forms.Button();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnClose = new System.Windows.Forms.Button();
        this.btnReset = new System.Windows.Forms.Button();
        this.grvUser = new System.Windows.Forms.DataGridView();
        this.IsSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.label1 = new System.Windows.Forms.Label();
        this.txtKeyWord = new System.Windows.Forms.TextBox();
        this.groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.grvUser)).BeginInit();
        this.SuspendLayout();
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.btnSearch);
        this.groupBox1.Controls.Add(this.btnSave);
        this.groupBox1.Controls.Add(this.btnClose);
        this.groupBox1.Controls.Add(this.btnReset);
        this.groupBox1.Controls.Add(this.grvUser);
        this.groupBox1.Controls.Add(this.label1);
        this.groupBox1.Controls.Add(this.txtKeyWord);
        this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.groupBox1.Location = new System.Drawing.Point(14, 12);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(858, 503);
        this.groupBox1.TabIndex = 0;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Danh sách người dùng";
        // 
        // btnSearch
        // 
        this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnSearch.Image = global::ECustoms.Properties.Resources.search41;
        this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnSearch.Location = new System.Drawing.Point(493, 23);
        this.btnSearch.Name = "btnSearch";
        this.btnSearch.Size = new System.Drawing.Size(111, 33);
        this.btnSearch.TabIndex = 15;
        this.btnSearch.Text = "Tìm kiếm";
        this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnSearch.UseVisualStyleBackColor = true;
        this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
        // 
        // btnSave
        // 
        this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnSave.Image = global::ECustoms.Properties.Resources.save_icon;
        this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnSave.Location = new System.Drawing.Point(566, 459);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(82, 33);
        this.btnSave.TabIndex = 13;
        this.btnSave.Text = "Lưu";
        this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        // 
        // btnClose
        // 
        this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnClose.Image = global::ECustoms.Properties.Resources.close;
        this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnClose.Location = new System.Drawing.Point(761, 459);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(86, 33);
        this.btnClose.TabIndex = 12;
        this.btnClose.Text = "Thoát";
        this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnClose.UseVisualStyleBackColor = true;
        this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        // 
        // btnReset
        // 
        this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnReset.Image = global::ECustoms.Properties.Resources._001_39;
        this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnReset.Location = new System.Drawing.Point(654, 459);
        this.btnReset.Name = "btnReset";
        this.btnReset.Size = new System.Drawing.Size(102, 33);
        this.btnReset.TabIndex = 11;
        this.btnReset.Text = "Làm lại";
        this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnReset.UseVisualStyleBackColor = true;
        this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
        // 
        // grvUser
        // 
        this.grvUser.AllowUserToAddRows = false;
        this.grvUser.AllowUserToDeleteRows = false;
        this.grvUser.AllowUserToOrderColumns = true;
        this.grvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.grvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsSelected,
            this.UserID,
            this.UserName,
            this.FirstName,
            this.Email,
            this.Address,
            this.PhoneNumber});
        this.grvUser.Location = new System.Drawing.Point(11, 86);
        this.grvUser.MultiSelect = false;
        this.grvUser.Name = "grvUser";
        this.grvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.grvUser.Size = new System.Drawing.Size(836, 365);
        this.grvUser.TabIndex = 7;
        // 
        // IsSelected
        // 
        this.IsSelected.HeaderText = "Chọn";
        this.IsSelected.Name = "IsSelected";
        this.IsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
        this.IsSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        this.IsSelected.Width = 50;
        // 
        // UserID
        // 
        this.UserID.DataPropertyName = "UserID";
        this.UserID.HeaderText = "UserID";
        this.UserID.Name = "UserID";
        this.UserID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
        // 
        // UserName
        // 
        this.UserName.DataPropertyName = "UserName";
        this.UserName.HeaderText = "Tên truy cập";
        this.UserName.Name = "UserName";
        this.UserName.ReadOnly = true;
        this.UserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
        this.UserName.Width = 150;
        // 
        // FirstName
        // 
        this.FirstName.DataPropertyName = "Name";
        this.FirstName.HeaderText = "Họ và tên";
        this.FirstName.Name = "FirstName";
        this.FirstName.ReadOnly = true;
        this.FirstName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
        this.FirstName.Width = 150;
        // 
        // Email
        // 
        this.Email.DataPropertyName = "Email";
        this.Email.HeaderText = "Email";
        this.Email.Name = "Email";
        this.Email.ReadOnly = true;
        this.Email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
        // 
        // Address
        // 
        this.Address.DataPropertyName = "Address";
        this.Address.HeaderText = "Địa chỉ";
        this.Address.Name = "Address";
        this.Address.ReadOnly = true;
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
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(7, 30);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(180, 20);
        this.label1.TabIndex = 6;
        this.label1.Text = "Tìm theo tên người dùng";
        // 
        // txtKeyWord
        // 
        this.txtKeyWord.Location = new System.Drawing.Point(206, 27);
        this.txtKeyWord.Name = "txtKeyWord";
        this.txtKeyWord.Size = new System.Drawing.Size(255, 26);
        this.txtKeyWord.TabIndex = 4;
        // 
        // frmListUserToAddInGroup
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(879, 527);
        this.Controls.Add(this.groupBox1);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "frmListUserToAddInGroup";
        this.Text = "Chọn người dùng cho nhóm";
        this.Load += new System.EventHandler(this.frmListUserToAddInGroup_Load);
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.grvUser)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.DataGridView grvUser;
    private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelected;
    private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
    private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
    private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
    private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    private System.Windows.Forms.DataGridViewTextBoxColumn Address;
    private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtKeyWord;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnReset;
    private System.Windows.Forms.Button btnSearch;

  }
}