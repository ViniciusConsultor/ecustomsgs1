namespace ECustoms
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cboHour = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboMinute = new System.Windows.Forms.ComboBox();
            this.optAfterNoon = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.optMorning = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkUseSyncInterval = new System.Windows.Forms.CheckBox();
            this.txtSyncInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastimeSync = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkUseSyncInterval);
            this.groupBox1.Controls.Add(this.txtSyncInterval);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLastimeSync);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtVersion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "+";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboHour);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboMinute);
            this.panel1.Controls.Add(this.optAfterNoon);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.optMorning);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(15, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 61);
            this.panel1.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Đồng bộ vào thời điểm:";
            // 
            // cboHour
            // 
            this.cboHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHour.FormattingEnabled = true;
            this.cboHour.Location = new System.Drawing.Point(149, 6);
            this.cboHour.Name = "cboHour";
            this.cboHour.Size = new System.Drawing.Size(62, 22);
            this.cboHour.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(209, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "giờ";
            // 
            // cboMinute
            // 
            this.cboMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMinute.FormattingEnabled = true;
            this.cboMinute.Location = new System.Drawing.Point(246, 6);
            this.cboMinute.Name = "cboMinute";
            this.cboMinute.Size = new System.Drawing.Size(62, 22);
            this.cboMinute.TabIndex = 11;
            // 
            // optAfterNoon
            // 
            this.optAfterNoon.AutoSize = true;
            this.optAfterNoon.Location = new System.Drawing.Point(188, 34);
            this.optAfterNoon.Name = "optAfterNoon";
            this.optAfterNoon.Size = new System.Drawing.Size(74, 18);
            this.optAfterNoon.TabIndex = 14;
            this.optAfterNoon.Text = "Chiều/tối";
            this.optAfterNoon.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(306, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "phút";
            // 
            // optMorning
            // 
            this.optMorning.AutoSize = true;
            this.optMorning.Checked = true;
            this.optMorning.Location = new System.Drawing.Point(130, 34);
            this.optMorning.Name = "optMorning";
            this.optMorning.Size = new System.Drawing.Size(52, 18);
            this.optMorning.TabIndex = 13;
            this.optMorning.TabStop = true;
            this.optMorning.Text = "Sáng";
            this.optMorning.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(304, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.Location = new System.Drawing.Point(215, 198);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(367, 14);
            this.label8.TabIndex = 15;
            this.label8.Text = "---------------------------------------------------------------------------------" +
    "---------";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(205, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "phút";
            // 
            // chkUseSyncInterval
            // 
            this.chkUseSyncInterval.AutoSize = true;
            this.chkUseSyncInterval.Checked = true;
            this.chkUseSyncInterval.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseSyncInterval.Location = new System.Drawing.Point(22, 68);
            this.chkUseSyncInterval.Name = "chkUseSyncInterval";
            this.chkUseSyncInterval.Size = new System.Drawing.Size(246, 18);
            this.chkUseSyncInterval.TabIndex = 6;
            this.chkUseSyncInterval.Text = "Sử dụng cơ chế đồng bộ thường xuyên";
            this.chkUseSyncInterval.UseVisualStyleBackColor = true;
            this.chkUseSyncInterval.CheckedChanged += new System.EventHandler(this.chkUseSyncInterval_CheckedChanged);
            // 
            // txtSyncInterval
            // 
            this.txtSyncInterval.Location = new System.Drawing.Point(128, 89);
            this.txtSyncInterval.Name = "txtSyncInterval";
            this.txtSyncInterval.Size = new System.Drawing.Size(78, 22);
            this.txtSyncInterval.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đồng bộ sau mỗi:";
            // 
            // txtLastimeSync
            // 
            this.txtLastimeSync.Location = new System.Drawing.Point(164, 40);
            this.txtLastimeSync.Name = "txtLastimeSync";
            this.txtLastimeSync.ReadOnly = true;
            this.txtLastimeSync.Size = new System.Drawing.Size(167, 22);
            this.txtLastimeSync.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lần đồng bộ gần nhất:";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(164, 13);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(167, 22);
            this.txtVersion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phiên bản cơ sở dữ liệu:";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(430, 270);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.ShowInTaskbar = false;
            this.Text = "Tham số hệ thống";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optAfterNoon;
        private System.Windows.Forms.RadioButton optMorning;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboMinute;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboHour;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkUseSyncInterval;
        private System.Windows.Forms.TextBox txtSyncInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLastimeSync;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel1;
    }
}