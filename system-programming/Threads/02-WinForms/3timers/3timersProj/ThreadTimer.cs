using System;
using System.Threading;
using System.Windows.Forms;

namespace _3timersProj
{
    public class ThreadTimer
    {
        private System.Timers.Timer _timer;
        private DateTime _stopWatch;
        private Label _timeLabel;

        private bool _isStopped;

        public ThreadTimer(double interval, Label timeLabel)
        {
            _isStopped = false;
            _timer = new System.Timers.Timer();
            _stopWatch = new DateTime();
            _timeLabel = timeLabel;

            Thread thread = new Thread(new ParameterizedThreadStart(ThreadProc));
            thread.Start(interval);
        }

        public void StopOrContinue()
        {
            if (_isStopped)
            {
                _timer.Start();
                _isStopped = false;
            }
            else
            {
                _timer.Stop();
                _isStopped = true;
            }
        }
        public void Discharge()
        {
            _timer.Stop();
            _stopWatch = new DateTime();
            _timeLabel.Text = "0:0:0";
            _isStopped = false;

            _timer.Dispose();
        }

        private void ThreadProc(object interval)
        {
            _timer.Interval = (double)interval;
            _timer.Elapsed += TickTimer;
            _timer.Start();
        }

        private void TickTimer(object sender, EventArgs e)
        {
            _stopWatch = _stopWatch.AddSeconds(1);

            _timeLabel.BeginInvoke((MethodInvoker)(() => _timeLabel.Text = _stopWatch.Hour.ToString() + ":" + _stopWatch.Minute.ToString() + ":" +_stopWatch.Second.ToString()));

        }
    }
}
