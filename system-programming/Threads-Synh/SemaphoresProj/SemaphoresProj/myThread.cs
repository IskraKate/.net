using System;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace SemaphoresProj
{
    public class MyThread
    {
        private Thread _thread;
        private System.Timers.Timer _timer;
        private SemaphoresTest _semaphoresTest;
        private int _maxNum;
        private int _count;

        public int Num { get; private set; } = 1;
        public string State { get; set; } = "";

        public string Count
        {
            get
            {
                return $"Thread {_count } --> {State}";
            }
        }

        public MyThread(SemaphoresTest semaphoresTest, int count)
        {
            _semaphoresTest = semaphoresTest;      

            _thread = new Thread(ThreadProc);
            _thread.IsBackground = true;
            _maxNum = new Random().Next(50, 250);

            _count = count;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (Num != _maxNum)
            {
                Num++;

                State = Num.ToString();
            }
            else
            {
                _semaphoresTest.ReleaseSemaphore();
                _semaphoresTest.RemoveWorkingThread(this);

                _timer.Stop();
                _timer.Dispose();
            }
        }

        private void ThreadProc()
        {
            _timer = new System.Timers.Timer();
            _timer.Elapsed += _timer_Tick;
            _timer.Interval = 1000;

            _semaphoresTest.CaptureSemaphore();
            _semaphoresTest.MoveWaitingThread(this);
            _timer.Start();
        }

        public void Start() 
        {
            _thread.Start();
        }
    }
}