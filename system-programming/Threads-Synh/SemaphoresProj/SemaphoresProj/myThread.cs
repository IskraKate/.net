using System;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Threading;

namespace SemaphoresProj
{
    public class MyThread
    {
        private Thread _thread;
        private System.Timers.Timer _timer;
        private SemaphoresTest _semaphoresTest;

        public int Count { get; private set; }
        public bool IsStopping { get; set; }
        public int Num { get; set; }
        public string State { get; set; } = "";

        public string CountState
        {
            get
            {
                return $"Thread {Count } --> {State}";
            }
        }

        public MyThread(SemaphoresTest semaphoresTest, int count)
        {
            _semaphoresTest = semaphoresTest;

            _thread = new Thread(ThreadProc);
            _thread.IsBackground = true;

            Count = count;
        }

        public MyThread(SemaphoresTest semaphoresTest, int count, int num)
        {
            _semaphoresTest = semaphoresTest;

            _thread = new Thread(ThreadProc);
            _thread.IsBackground = true;

            Count = count;
            Num = num;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (!IsStopping)
            {
                Num++;
                State = Num.ToString();
                _semaphoresTest.UpdateWorkingThread(this);
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

            State = Num.ToString();

            _semaphoresTest.MoveWaitingThread(this);
            _timer.Start();
        }


        public void Start() 
        {
            _thread.Start();
        }
        public void Stop()
        {
            _thread.Abort();
        }
    }
}