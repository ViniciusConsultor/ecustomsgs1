namespace ECustomsEncode
{
    partial class frmEncode
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnEnclode = new System.Windows.Forms.Button();
            this.bntCancel = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đầu vào";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 29);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(476, 20);
            this.txtInput.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dữ liệu sau khi mã hóa";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(16, 72);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(472, 141);
            this.txtOutput.TabIndex = 3;
            // 
            // btnEnclode
            // 
            this.btnEnclode.Location = new System.Drawing.Point(16, 230);
            this.btnEnclode.Name = "btnEnclode";
            this.btnEnclode.Size = new System.Drawing.Size(75, 23);
            this.btnEnclode.TabIndex = 4;
            this.btnEnclode.Text = "Mã hóa";
            this.btnEnclode.UseVisualStyleBackColor = true;
            this.btnEnclode.Click += new System.EventHandler(this.btnEnclode_Click);
            // 
            // bntCancel
            // 
            this.bntCancel.Location = new System.Drawing.Point(178, 230);
            this.bntCancel.Name = "bntCancel";
            this.bntCancel.Size = new System.Drawing.Size(75, 23);
            this.bntCancel.TabIndex = 5;
            this.bntCancel.Text = "Hủy";
            this.bntCancel.UseVisualStyleBackColor = true;
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(97, 230);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(75, 23);
            this.btnDecode.TabIndex = 6;
            this.btnDecode.Text = "Giải mã";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // frmEncode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 262);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.bntCancel);
            this.Controls.Add(this.btnEnclode);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label1);
            this.Name = "frmEncode";
            this.Text = "ECustoms - Mã hõa dữ liệu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnEnclode;
        private System.Windows.Forms.Button bntCancel;
        private System.Windows.Forms.Button btnDecode;
    }
}

