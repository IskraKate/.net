using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SumCounter
{
    class ThreadTimer
    {
        private int _num;
        private int _interVal = 1;
        private int _newVal = 0;
        private System.Timers.Timer _timer;

        private TextBox _textBox;
        private Label _label;

        public ThreadTimer(TextBox textBox, Label label)
        {
            _textBox = textBox;
            _label = label;

            _timer = new System.Timers.Timer();

            Thread thread = new Thread(ThreadProc);
            thread.Start();
        }

        private void ThreadProc()
        {
            if (!String.IsNullOrEmpty(_textBox.Text))
            {
                _timer = new System.Timers.Timer();
                _num = int.Parse(_textBox.Text);

                _timer.Interval = 500;
                _timer.Elapsed += TickTimer;
                _timer.Start();
            }
        }

        private void TickTimer(object sender, EventArgs e)
        {
            if (_interVal < _num)
            {
                _newVal += (_interVal) + (_interVal + 1);
                _interVal++;
            }

            _label.BeginInvoke((MethodInvoker)(() => _label.Text = _label.Text = _newVal.ToString()));
        }
    }
}
