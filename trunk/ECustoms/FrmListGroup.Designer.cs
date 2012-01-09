namespace ECustoms
{
    partial class FrmListGroup
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListGroup));
          this.grbUser = new System.Windows.Forms.GroupBox();
          this.grvGroup = new System.Windows.Forms.DataGridView();
          this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.GroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.btnDelete = new System.Windows.Forms.Button();
          this.btnClose = new System.Windows.Forms.Button();
          this.btnAdd = new System.Windows.Forms.Button();
          this.btnUpdate = new System.Windows.Forms.Button();
          this.grbUser.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.grvGroup)).BeginInit();
          this.SuspendLayout();
          // 
          // grbUser
          // 
          this.grbUser.Controls.Add(this.grvGroup);
          this.grbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.grbUser.Location = new System.Drawing.Point(12, 12);
          this.grbUser.Name = "grbUser";
          this.grbUser.Size = new System.Drawing.Size(557, 317);
          this.grbUser.TabIndex = 1;
          this.grbUser.TabStop = false;
          this.grbUser.Text = "Danh sách nhóm";
          // 
          // grvGroup
          // 
          this.grvGroup.AllowUserToAddRows = false;
          this.grvGroup.AllowUserToDeleteRows = false;
          this.grvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.grvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupName,
            this.GroupID});
          this.grvGroup.Location = new System.Drawing.Point(6, 25);
          this.grvGroup.Name = "grvGroup";
          this.grvGroup.ReadOnly = true;
          this.grvGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
          this.grvGroup.Size = new System.Drawing.Size(543, 292);
          this.grvGroup.TabIndex = 1;
          this.grvGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvGroup_CellClick);
          this.grvGroup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvGroup_CellDoubleClick);
          // 
          // GroupName
          // 
          this.GroupName.DataPropertyName = "GroupName";
          this.GroupName.HeaderText = "Tên nhóm";
          this.GroupName.Name = "GroupName";
          this.GroupName.ReadOnly = true;
          this.GroupName.Width = 500;
          // 
          // GroupID
          // 
          this.GroupID.DataPropertyName = "GroupID";
          this.GroupID.HeaderText = "GroupID";
          this.GroupID.Name = "GroupID";
          this.GroupID.ReadOnly = true;
          this.GroupID.Visible = false;
          // 
          // btnDelete
          // 
          this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
          this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnDelete.Image = global::ECustoms.Properties.Resources._001_05;
          this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.btnDelete.Location = new System.Drawing.Point(317, 335);
          this.btnDelete.Name = "btnDelete";
          this.btnDelete.Size = new System.Drawing.Size(76, 33);
          this.btnDelete.TabIndex = 7;
          this.btnDelete.Text = "Xóa";
          this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          this.btnDelete.UseVisualStyleBackColor = true;
          this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
          // 
          // btnClose
          // 
          this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
          this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnClose.Image = global::ECustoms.Properties.Resources.close;
          this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.btnClose.Location = new System.Drawing.Point(399, 335);
          this.btnClose.Name = "btnClose";
          this.btnClose.Size = new System.Drawing.Size(84, 33);
          this.btnClose.TabIndex = 8;
          this.btnClose.Text = "Đóng";
          this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          this.btnClose.UseVisualStyleBackColor = true;
          this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
          // 
          // btnAdd
          // 
          this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
          this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnAdd.Image = global::ECustoms.Properties.Resources._001_01;
          this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.btnAdd.Location = new System.Drawing.Point(12, 335);
          this.btnAdd.Name = "btnAdd";
          this.btnAdd.Size = new System.Drawing.Size(141, 33);
          this.btnAdd.TabIndex = 5;
          this.btnAdd.Text = "Tạo mới nhóm";
          this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          this.btnAdd.UseVisualStyleBackColor = true;
          this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
          // 
          // btnUpdate
          // 
          this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
          this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnUpdate.Image = global::ECustoms.Properties.Resources._001_45;
          this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.btnUpdate.Location = new System.Drawing.Point(159, 335);
          this.btnUpdate.Name = "btnUpdate";
          this.btnUpdate.Size = new System.Drawing.Size(152, 33);
          this.btnUpdate.TabIndex = 6;
          this.btnUpdate.Text = "Cập nhật nhóm";
          this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          this.btnUpdate.UseVisualStyleBackColor = true;
          this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
          // 
          // FrmListGroup
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(572, 377);
          this.Controls.Add(this.btnDelete);
          this.Controls.Add(this.btnClose);
          this.Controls.Add(this.btnAdd);
          this.Controls.Add(this.grbUser);
          this.Controls.Add(this.btnUpdate);
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.Name = "FrmListGroup";
          this.Text = "FrmGroup";
          this.Load += new System.EventHandler(this.FrmListGroup_Load);
          this.grbUser.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.grvGroup)).EndInit();
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbUser;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView grvGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupID;
    }
}