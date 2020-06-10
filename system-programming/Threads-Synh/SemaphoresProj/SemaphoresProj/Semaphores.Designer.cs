namespace SemaphoresProj
{
    partial class SemaphoresTest
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.listBoxCreated = new System.Windows.Forms.ListBox();
            this.listBoxWaiting = new System.Windows.Forms.ListBox();
            this.listBoxWorking = new System.Windows.Forms.ListBox();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(30, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Working Threads";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(289, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Waiting Threads";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(543, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Created Threads";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(30, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Places in semaphore";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(626, 212);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(124, 23);
            this.buttonCreate.TabIndex = 8;
            this.buttonCreate.Text = "Create thread";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // listBoxCreated
            // 
            this.listBoxCreated.FormattingEnabled = true;
            this.listBoxCreated.ItemHeight = 16;
            this.listBoxCreated.Location = new System.Drawing.Point(546, 48);
            this.listBoxCreated.Name = "listBoxCreated";
            this.listBoxCreated.Size = new System.Drawing.Size(204, 100);
            this.listBoxCreated.TabIndex = 9;
            this.listBoxCreated.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxCreated_MouseDoubleClick);
            // 
            // listBoxWaiting
            // 
            this.listBoxWaiting.FormattingEnabled = true;
            this.listBoxWaiting.ItemHeight = 16;
            this.listBoxWaiting.Location = new System.Drawing.Point(292, 48);
            this.listBoxWaiting.Name = "listBoxWaiting";
            this.listBoxWaiting.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxWaiting.Size = new System.Drawing.Size(204, 100);
            this.listBoxWaiting.TabIndex = 10;
            // 
            // listBoxWorking
            // 
            this.listBoxWorking.FormattingEnabled = true;
            this.listBoxWorking.ItemHeight = 16;
            this.listBoxWorking.Location = new System.Drawing.Point(33, 48);
            this.listBoxWorking.Name = "listBoxWorking";
            this.listBoxWorking.Size = new System.Drawing.Size(204, 100);
            this.listBoxWorking.TabIndex = 11;
            this.listBoxWorking.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxWorking_MouseDoubleClick);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(33, 213);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(129, 22);
            this.numericUpDown.TabIndex = 12;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // SemaphoresTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 267);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.listBoxWorking);
            this.Controls.Add(this.listBoxWaiting);
            this.Controls.Add(this.listBoxCreated);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SemaphoresTest";
            this.Text = "Semaphores";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.ListBox listBoxCreated;
        private System.Windows.Forms.ListBox listBoxWaiting;
        private System.Windows.Forms.ListBox listBoxWorking;
        private System.Windows.Forms.NumericUpDown numericUpDown;
    }
}

