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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBoxAdding.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCens
            // 
            this.textBoxCens.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCens.Location = new System.Drawing.Point(9, 44);
            this.textBoxCens.Name = "textBoxCens";
            this.textBoxCens.Size = new System.Drawing.Size(325, 22);
            this.textBoxCens.TabIndex = 0;
            // 
            // buttonAddWord
            // 
            this.buttonAddWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddWord.Location = new System.Drawing.Point(340, 43);
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
            this.listBoxCens.Location = new System.Drawing.Point(462, 56);
            this.listBoxCens.Name = "listBoxCens";
            this.listBoxCens.Size = new System.Drawing.Size(211, 164);
            this.listBoxCens.TabIndex = 2;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(576, 226);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(98, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete Word";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelEnterObsceneWords
            // 
            this.labelEnterObsceneWords.AutoSize = true;
            this.labelEnterObsceneWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEnterObsceneWords.Location = new System.Drawing.Point(6, 24);
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
            this.buttonStart.Location = new System.Drawing.Point(293, 328);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(114, 47);
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
            this.groupBoxAdding.Name = "groupBoxAdding";
            this.groupBoxAdding.Size = new System.Drawing.Size(673, 258);
            this.groupBoxAdding.TabIndex = 7;
            this.groupBoxAdding.TabStop = false;
            this.groupBoxAdding.Text = "Words adding";
            // 
            // buttonFromFile
            // 
            this.buttonFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFromFile.Location = new System.Drawing.Point(450, 214);
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
            this.buttonCopyTo.Location = new System.Drawing.Point(62, 276);
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
            this.textBoxCopy.Name = "textBoxCopy";
            this.textBoxCopy.ReadOnly = true;
            this.textBoxCopy.Size = new System.Drawing.Size(411, 22);
            this.textBoxCopy.TabIndex = 10;
            this.textBoxCopy.TabStop = false;
            this.textBoxCopy.TextChanged += new System.EventHandler(this.textBoxCopy_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 381);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(672, 37);
            this.progressBar1.TabIndex = 11;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Enabled = false;
            this.buttonPlay.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlay.Location = new System.Drawing.Point(157, 425);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(111, 42);
            this.buttonPlay.TabIndex = 12;
            this.buttonPlay.Text = "►";
            this.buttonPlay.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(296, 425);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 42);
            this.button2.TabIndex = 13;
            this.button2.Text = "||";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(435, 424);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 42);
            this.button3.TabIndex = 14;
            this.button3.Text = "■";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // FormCens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 488);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.progressBar1);
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
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonFromFile;
    }
}

