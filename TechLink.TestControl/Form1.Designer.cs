namespace TechLink.TestControl
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.niqInputGroup1 = new Niq.Msd.Layout.NiqInputGroup(this.components);
            this.SuspendLayout();
            // 
            // niqInputGroup1
            // 
            this.niqInputGroup1.AutoUpperCase = false;
            this.niqInputGroup1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(155)))), ((int)(((byte)(197)))));
            this.niqInputGroup1.ButtonCellBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(155)))), ((int)(((byte)(197)))));
            this.niqInputGroup1.DataSource = null;
            this.niqInputGroup1.InputType = Niq.Msd.Layout.InputTypes.Text;
            this.niqInputGroup1.IsValidTextInput = false;
            this.niqInputGroup1.Location = new System.Drawing.Point(21, 21);
            this.niqInputGroup1.Name = "niqInputGroup1";
            this.niqInputGroup1.SelectedItems = ((System.Collections.Generic.List<object>)(resources.GetObject("niqInputGroup1.SelectedItems")));
            this.niqInputGroup1.Size = new System.Drawing.Size(244, 37);
            this.niqInputGroup1.TabIndex = 0;
            this.niqInputGroup1.TextField = null;
            this.niqInputGroup1.ValueField = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.niqInputGroup1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Niq.Msd.Layout.NiqInputGroup niqInputGroup1;
    }
}

