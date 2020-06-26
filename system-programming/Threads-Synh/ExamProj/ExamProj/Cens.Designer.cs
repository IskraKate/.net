namespace ExamProj
{
    partial class FormCens
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCens));
            this.textBoxCens = new System.Windows.Forms.TextBox();
            this.buttonAddWord = new System.Windows.Forms.Button();
            this.listBoxCens = new System.Windows.Forms.ListBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelEnterObsceneWords = new System.Windows.Forms.Label();
            this.labelWList = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBoxAdding = new System.Windows.Forms.GroupBox();
            this.buttonFromFile = new System.Windows.Forms.Button();
            this.labelCopy = new System.Windows.Forms.Label();
            this.buttonCopyTo = new System.Windows.Forms.Button();
            this.textBoxCopy = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonAbort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxAdding.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCens
            // 
            this.textBoxCens.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCens.Location = new System.Drawing.Point(9, 44);
            this.textBoxCens.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCens.Name = "textBoxCens";
            this.textBoxCens.Size = new System.Drawing.Size(325, 22);
            this.textBoxCens.TabIndex = 0;
            this.textBoxCens.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCens_KeyDown);
            // 
            // buttonAddWord
            // 
            this.buttonAddWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddWord.Location = new System.Drawing.Point(340, 43);
            this.buttonAddWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddWord.Name = "buttonAddWord";
            this.buttonAddWord.Size = new System.Drawing.Size(75, 23);
            this.buttonAddWord.TabIndex = 1;
            this.buttonAddWord.Text = "Add";
            this.buttonAddWord.UseVisualStyleBackColor = true;
            this.buttonAddWord.Click += new System.EventHandler(this.buttonAddWord_Click);
            // 
            // listBoxCens
            // 
            this.listBoxCens.FormattingEnabled = true;
            this.listBoxCens.ItemHeight = 16;
            this.listBoxCens.Location = new System.Drawing.Point(461, 57);
            this.listBoxCens.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxCens.Name = "listBoxCens";
            this.listBoxCens.Size = new System.Drawing.Size(211, 164);
            this.listBoxCens.TabIndex = 2;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(576, 226);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(99, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete Word";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelEnterObsceneWords
            // 
            this.labelEnterObsceneWords.AutoSize = true;
            this.labelEnterObsceneWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEnterObsceneWords.Location = new System.Drawing.Point(5, 25);
            this.labelEnterObsceneWords.Name = "labelEnterObsceneWords";
            this.labelEnterObsceneWords.Size = new System.Drawing.Size(141, 17);
            this.labelEnterObsceneWords.TabIndex = 4;
            this.labelEnterObsceneWords.Text = "Enter obscene words";
            // 
            // labelWList
            // 
            this.labelWList.AutoSize = true;
            this.labelWList.Location = new System.Drawing.Point(459, 33);
            this.labelWList.Name = "labelWList";
            this.labelWList.Size = new System.Drawing.Size(70, 17);
            this.labelWList.TabIndex = 5;
            this.labelWList.Text = "Words list";
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(292, 313);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(115, 47);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // groupBoxAdding
            // 
            this.groupBoxAdding.Controls.Add(this.buttonFromFile);
            this.groupBoxAdding.Controls.Add(this.textBoxCens);
            this.groupBoxAdding.Controls.Add(this.labelEnterObsceneWords);
            this.groupBoxAdding.Controls.Add(this.buttonAddWord);
            this.groupBoxAdding.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxAdding.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAdding.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxAdding.Name = "groupBoxAdding";
            this.groupBoxAdding.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxAdding.Size = new System.Drawing.Size(673, 258);
            this.groupBoxAdding.TabIndex = 7;
            this.groupBoxAdding.TabStop = false;
            this.groupBoxAdding.Text = "Words adding";
            // 
            // buttonFromFile
            // 
            this.buttonFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFromFile.Location = new System.Drawing.Point(451, 214);
            this.buttonFromFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFromFile.Name = "buttonFromFile";
            this.buttonFromFile.Size = new System.Drawing.Size(108, 23);
            this.buttonFromFile.TabIndex = 15;
            this.buttonFromFile.Text = "From File";
            this.buttonFromFile.UseVisualStyleBackColor = true;
            this.buttonFromFile.Click += new System.EventHandler(this.buttonFromFile_Click);
            // 
            // labelCopy
            // 
            this.labelCopy.AutoSize = true;
            this.labelCopy.Location = new System.Drawing.Point(9, 282);
            this.labelCopy.Name = "labelCopy";
            this.labelCopy.Size = new System.Drawing.Size(56, 17);
            this.labelCopy.TabIndex = 8;
            this.labelCopy.Text = "Copy to";
            // 
            // buttonCopyTo
            // 
            this.buttonCopyTo.Location = new System.Drawing.Point(61, 276);
            this.buttonCopyTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCopyTo.Name = "buttonCopyTo";
            this.buttonCopyTo.Size = new System.Drawing.Size(31, 23);
            this.buttonCopyTo.TabIndex = 9;
            this.buttonCopyTo.Text = "...";
            this.buttonCopyTo.UseVisualStyleBackColor = true;
            this.buttonCopyTo.Click += new System.EventHandler(this.buttonCopyTo_Click);
            // 
            // textBoxCopy
            // 
            this.textBoxCopy.BackColor = System.Drawing.Color.White;
            this.textBoxCopy.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxCopy.Location = new System.Drawing.Point(99, 276);
            this.textBoxCopy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCopy.Name = "textBoxCopy";
            this.textBoxCopy.ReadOnly = true;
            this.textBoxCopy.Size = new System.Drawing.Size(411, 22);
            this.textBoxCopy.TabIndex = 10;
            this.textBoxCopy.TabStop = false;
            this.textBoxCopy.TextChanged += new System.EventHandler(this.textBoxCopy_TextChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 382);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(672, 37);
            this.progressBar.TabIndex = 11;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Enabled = false;
            this.buttonPlay.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlay.Location = new System.Drawing.Point(157, 425);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(111, 42);
            this.buttonPlay.TabIndex = 12;
            this.buttonPlay.Text = "►";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStop.Location = new System.Drawing.Point(296, 425);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(111, 42);
            this.buttonStop.TabIndex = 13;
            this.buttonStop.Text = "||";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonAbort
            // 
            this.buttonAbort.Enabled = false;
            this.buttonAbort.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAbort.Location = new System.Drawing.Point(435, 423);
            this.buttonAbort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(111, 42);
            this.buttonAbort.TabIndex = 14;
            this.buttonAbort.Text = "■";
            this.buttonAbort.UseVisualStyleBackColor = true;
            this.buttonAbort.Click += new System.EventHandler(this.buttonAbort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Getting files...";
            this.label1.Visible = false;
            // 
            // FormCens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 487);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAbort);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.textBoxCopy);
            this.Controls.Add(this.buttonCopyTo);
            this.Controls.Add(this.labelCopy);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelWList);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.listBoxCens);
            this.Controls.Add(this.groupBoxAdding);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormCens";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Censorship";
            this.groupBoxAdding.ResumeLayout(false);
            this.groupBoxAdding.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCens;
        private System.Windows.Forms.Button buttonAddWord;
        private System.Windows.Forms.ListBox listBoxCens;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelEnterObsceneWords;
        private System.Windows.Forms.Label labelWList;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.GroupBox groupBoxAdding;
        private System.Windows.Forms.Label labelCopy;
        private System.Windows.Forms.Button buttonCopyTo;
        private System.Windows.Forms.TextBox textBoxCopy;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonAbort;
        private System.Windows.Forms.Button buttonFromFile;
        private System.Windows.Forms.Label label1;
    }
}

