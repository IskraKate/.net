namespace _3timersProj
{
    partial class TimersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimersForm));
            this.button1 = new System.Windows.Forms.Button();
            this.buttonDischarge = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Label();
            this.timersGroupBox = new System.Windows.Forms.GroupBox();
            this.timersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 149);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonDischarge
            // 
            this.buttonDischarge.Enabled = false;
            this.buttonDischarge.Location = new System.Drawing.Point(368, 149);
            this.buttonDischarge.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDischarge.Name = "buttonDischarge";
            this.buttonDischarge.Size = new System.Drawing.Size(111, 53);
            this.buttonDischarge.TabIndex = 2;
            this.buttonDischarge.Text = "Dischardge";
            this.buttonDischarge.UseVisualStyleBackColor = true;
            this.buttonDischarge.Click += new System.EventHandler(this.buttonDischarge_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(9, 149);
            this.startButton.Margin = new System.Windows.Forms.Padding(2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(111, 53);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(188, 149);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(111, 53);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // timer1
            // 
            this.timer1.AutoSize = true;
            this.timer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timer1.Location = new System.Drawing.Point(29, 45);
            this.timer1.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.timer1.Name = "timer1";
            this.timer1.Size = new System.Drawing.Size(44, 20);
            this.timer1.TabIndex = 3;
            this.timer1.Text = "0:0:0";
            // 
            // timer2
            // 
            this.timer2.AutoSize = true;
            this.timer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timer2.Location = new System.Drawing.Point(391, 45);
            this.timer2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timer2.Name = "timer2";
            this.timer2.Size = new System.Drawing.Size(44, 20);
            this.timer2.TabIndex = 4;
            this.timer2.Text = "0:0:0";
            // 
            // timer3
            // 
            this.timer3.AutoSize = true;
            this.timer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timer3.Location = new System.Drawing.Point(208, 45);
            this.timer3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timer3.Name = "timer3";
            this.timer3.Size = new System.Drawing.Size(44, 20);
            this.timer3.TabIndex = 5;
            this.timer3.Text = "0:0:0";
            // 
            // timersGroupBox
            // 
            this.timersGroupBox.Controls.Add(this.timer1);
            this.timersGroupBox.Controls.Add(this.timer3);
            this.timersGroupBox.Controls.Add(this.timer2);
            this.timersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timersGroupBox.Location = new System.Drawing.Point(12, 12);
            this.timersGroupBox.Name = "timersGroupBox";
            this.timersGroupBox.Size = new System.Drawing.Size(467, 100);
            this.timersGroupBox.TabIndex = 6;
            this.timersGroupBox.TabStop = false;
            this.timersGroupBox.Text = "Timers";
            // 
            // TimersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 211);
            this.Controls.Add(this.timersGroupBox);
            this.Controls.Add(this.buttonDischarge);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimersForm";
            this.Text = "3Timers";
            this.timersGroupBox.ResumeLayout(false);
            this.timersGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDischarge;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label timer1;
        private System.Windows.Forms.Label timer2;
        private System.Windows.Forms.Label timer3;
        private System.Windows.Forms.GroupBox timersGroupBox;
    }
}

