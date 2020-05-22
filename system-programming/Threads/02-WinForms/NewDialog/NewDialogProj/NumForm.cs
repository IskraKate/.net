using System;
using System.Windows.Forms;

namespace NewDialogProj
{
    public partial class NumForm : Form
    {
        private int _num;
        private System.Timers.Timer _timer;

        public NumForm()
        {
            InitializeComponent();

            _num = 0;
            _timer = new System.Timers.Timer();

            _timer.Interval = 500;
            _timer.Elapsed += TickTimer;
            _timer.Start();
        }

        private void TickTimer(object sender, EventArgs e)
        {
            if (_num < 20)
            {
                _num++;
                numLabel.BeginInvoke((MethodInvoker)(() => numLabel.Text = _num.ToString()));          
            }
            else
            {
                this.Close();

                _num = 0;
            }
        }

        private void NumForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Stop();
            _timer.Dispose();

            this.Dispose();
        }
    }
}
