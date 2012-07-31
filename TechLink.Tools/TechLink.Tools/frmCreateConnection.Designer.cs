namespace TechLink.Tools
{
    partial class frmCreateConnection
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
            this.databaseRegistration1 = new TechLink.Views.DatabaseRegistration();
            this.SuspendLayout();
            // 
            // databaseRegistration1
            // 
            this.databaseRegistration1.BackColor = System.Drawing.Color.White;
            this.databaseRegistration1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databaseRegistration1.Location = new System.Drawing.Point(0, 0);
            this.databaseRegistration1.Name = "databaseRegistration1";
            this.databaseRegistration1.Size = new System.Drawing.Size(821, 396);
            this.databaseRegistration1.TabIndex = 0;
            this.databaseRegistration1.Load += new System.EventHandler(this.databaseRegistration1_Load);
            // 
            // frmCreateConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 396);
            this.Controls.Add(this.databaseRegistration1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateConnection";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create a connection to database";
            this.ResumeLayout(false);

        }

        #endregion

        private Views.DatabaseRegistration databaseRegistration1;
    }
}