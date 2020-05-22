namespace NewDialogProj
{
    partial class FormMain
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
            this.buttonShowNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonShowNew
            // 
            this.buttonShowNew.Location = new System.Drawing.Point(12, 12);
            this.buttonShowNew.Name = "buttonShowNew";
            this.buttonShowNew.Size = new System.Drawing.Size(234, 68);
            this.buttonShowNew.TabIndex = 0;
            this.buttonShowNew.Text = "Show new dialog";
            this.buttonShowNew.UseVisualStyleBackColor = true;
            this.buttonShowNew.Click += new System.EventHandler(this.buttonShowNew_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 92);
            this.Controls.Add(this.buttonShowNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "MainDlg";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonShowNew;
    }
}

