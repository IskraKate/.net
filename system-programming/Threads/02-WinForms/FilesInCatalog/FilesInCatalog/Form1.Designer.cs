namespace FilesInCatalog
{
    partial class FormFiles
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonDir = new System.Windows.Forms.Button();
            this.buttonDirAgain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 76);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(717, 22);
            this.textBox1.TabIndex = 0;
            // 
            // buttonDir
            // 
            this.buttonDir.Location = new System.Drawing.Point(735, 69);
            this.buttonDir.Name = "buttonDir";
            this.buttonDir.Size = new System.Drawing.Size(91, 36);
            this.buttonDir.TabIndex = 1;
            this.buttonDir.Text = "Files";
            this.buttonDir.UseVisualStyleBackColor = true;
            this.buttonDir.Click += new System.EventHandler(this.buttonDir_Click);
            // 
            // buttonDirAgain
            // 
            this.buttonDirAgain.Location = new System.Drawing.Point(12, 28);
            this.buttonDirAgain.Name = "buttonDirAgain";
            this.buttonDirAgain.Size = new System.Drawing.Size(91, 36);
            this.buttonDirAgain.TabIndex = 2;
            this.buttonDirAgain.Text = "Choose dir";
            this.buttonDirAgain.UseVisualStyleBackColor = true;
            this.buttonDirAgain.Click += new System.EventHandler(this.buttonDirAgain_Click);
            // 
            // FormFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 117);
            this.Controls.Add(this.buttonDirAgain);
            this.Controls.Add(this.buttonDir);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormFiles";
            this.Text = "Files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonDir;
        private System.Windows.Forms.Button buttonDirAgain;
    }
}

