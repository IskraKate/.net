namespace WindowsFormsApp1
{
    partial class FormAsyncCopy
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
            this.buttonFileFrom = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.textBoxWhere = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelWhere = new System.Windows.Forms.Label();
            this.buttonWhere = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFileFrom
            // 
            this.buttonFileFrom.Location = new System.Drawing.Point(485, 43);
            this.buttonFileFrom.Name = "buttonFileFrom";
            this.buttonFileFrom.Size = new System.Drawing.Size(75, 29);
            this.buttonFileFrom.TabIndex = 0;
            this.buttonFileFrom.Text = "File...";
            this.buttonFileFrom.UseVisualStyleBackColor = true;
            this.buttonFileFrom.Click += new System.EventHandler(this.buttonFileFrom_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(570, 168);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 39);
            this.buttonCopy.TabIndex = 2;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(114, 46);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(365, 22);
            this.textBoxFrom.TabIndex = 3;
            // 
            // textBoxWhere
            // 
            this.textBoxWhere.Location = new System.Drawing.Point(114, 107);
            this.textBoxWhere.Name = "textBoxWhere";
            this.textBoxWhere.Size = new System.Drawing.Size(365, 22);
            this.textBoxWhere.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(26, 168);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(534, 39);
            this.progressBar1.TabIndex = 5;
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(23, 49);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(44, 17);
            this.labelFrom.TabIndex = 6;
            this.labelFrom.Text = "From:";
            // 
            // labelWhere
            // 
            this.labelWhere.AutoSize = true;
            this.labelWhere.Location = new System.Drawing.Point(23, 109);
            this.labelWhere.Name = "labelWhere";
            this.labelWhere.Size = new System.Drawing.Size(54, 17);
            this.labelWhere.TabIndex = 7;
            this.labelWhere.Text = "Where:";
            // 
            // buttonWhere
            // 
            this.buttonWhere.Location = new System.Drawing.Point(485, 104);
            this.buttonWhere.Name = "buttonWhere";
            this.buttonWhere.Size = new System.Drawing.Size(75, 29);
            this.buttonWhere.TabIndex = 8;
            this.buttonWhere.Text = "File...";
            this.buttonWhere.UseVisualStyleBackColor = true;
            this.buttonWhere.Click += new System.EventHandler(this.buttonWhere_Click);
            // 
            // FormAsyncCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 219);
            this.Controls.Add(this.buttonWhere);
            this.Controls.Add(this.labelWhere);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBoxWhere);
            this.Controls.Add(this.textBoxFrom);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.buttonFileFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAsyncCopy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AscyncCopy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFileFrom;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.TextBox textBoxWhere;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelWhere;
        private System.Windows.Forms.Button buttonWhere;
    }
}

