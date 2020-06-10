using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SemaphoresProj
{
    public partial class SemaphoresTest : Form
    {
        private int _count = 0;
        private static Semaphore _semaphore;
        private object _locker;

        public SemaphoresTest()
        {
            InitializeComponent();

            listBoxCreated.DisplayMember = "CountState";
            listBoxWaiting.DisplayMember = "CountState";
            listBoxWorking.DisplayMember = "CountState";

            _locker = new object();
        }

        public void CaptureSemaphore()
        {
            _semaphore.WaitOne();
        }

        public void ReleaseSemaphore()
        {
            _semaphore.Release();
        }

        public void MoveWaitingThread(MyThread thread)
        {
            listBoxWorking.Invoke((MethodInvoker)(() => listBoxWorking.Items.Add(thread)));
            listBoxWaiting.Invoke((MethodInvoker)(() => listBoxWaiting.Items.Remove(thread)));
        }

        public void UpdateWorkingThread(MyThread thread)
        {
            lock (_locker)
            {
                int selectedIndex = 0;

                listBoxWorking.Invoke((MethodInvoker)(() => selectedIndex = listBoxWorking.SelectedIndex));
                int index = listBoxWorking.Items.IndexOf(thread);


                if (index != -1 && index < listBoxWorking.Items.Count)
                {
                    listBoxWorking.Invoke((MethodInvoker)(() => listBoxWorking.Items.Remove(thread)));
                    if (index < listBoxWorking.Items.Count)
                    {
                        listBoxWorking.Invoke((MethodInvoker)(() => listBoxWorking.Items.Insert(index, thread)));
                    }
                    else
                    {
                        listBoxWorking.Invoke((MethodInvoker)(() => listBoxWorking.Items.Add(thread)));
                    }

                    listBoxWorking.Invoke((MethodInvoker)(() => listBoxWorking.SelectedIndex = selectedIndex));
                }
            }
        }

        public void RemoveWorkingThread(MyThread thread)
        {
            listBoxWorking.Invoke((MethodInvoker)(() => listBoxWorking.Items.Remove(thread)));
        }


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (numericUpDown.Value != 0)
            {
                _count++;

                MyThread thread = new MyThread(this, _count);

                thread.State = "created";
                listBoxCreated.Items.Add(thread);
            }
        }

        private void listBoxCreated_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxCreated.SelectedItem != null)
            {
                if (listBoxWorking.Items.Count == 0)
                {
                    _semaphore = new Semaphore((int)numericUpDown.Value, (int)numericUpDown.Value);
                }

                MyThread thread = listBoxCreated.SelectedItem as MyThread;
                thread.State = "waiting";
                listBoxWaiting.Invoke((MethodInvoker)(() => listBoxWaiting.Items.Add(thread)));
                listBoxWaiting.Invoke((MethodInvoker)(() => listBoxCreated.Items.RemoveAt(listBoxCreated.SelectedIndex)));


                thread.Start();
            }
        }
        private void listBoxWorking_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxWorking.SelectedItem != null)
            {
                MyThread thread = listBoxWorking.SelectedItem as MyThread;
                thread.IsStopping = true;
                listBoxWorking.Items.RemoveAt(listBoxWorking.SelectedIndex);
            }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int count = (int)numericUpDown.Value;
            int indexWorking = 0;

            if (count != 0)
            {
                _semaphore = new Semaphore(initialCount: count, maximumCount: count);

                List<MyThread> oldThreadsWorking = new List<MyThread>();

                for (int i = 0; i < listBoxWorking.Items.Count; i++, indexWorking++)
                {
                    MyThread thread = listBoxWorking.Items[i] as MyThread;
                    if (indexWorking < count)
                    {
                        oldThreadsWorking.Add(new MyThread(this, thread.Count, thread.Num));
                    }

                    thread.Stop();
                }
                listBoxWorking.Invoke((MethodInvoker)(() => listBoxWorking.Items.Clear()));

                List<MyThread> oldThreadsWaiting = new List<MyThread>();
                oldThreadsWaiting.AddRange(oldThreadsWorking);

                for(int i = 0; i < listBoxWaiting.Items.Count; i++)
                {
                    MyThread thread = listBoxWaiting.Items[i] as MyThread;
                    oldThreadsWaiting.Add(new MyThread(this, thread.Count));
                    oldThreadsWaiting.Last().State = "waiting";


                    thread.Stop();
                }

                listBoxWaiting.Invoke((MethodInvoker)(() => listBoxWaiting.Items.Clear()));

                for (int i = 0; i < oldThreadsWaiting.Count; i++)
                {
                    listBoxWaiting.Invoke((MethodInvoker)(() => listBoxWaiting.Items.Add(oldThreadsWaiting[i])));

                    oldThreadsWaiting[i].Start();
                }
            }
            else
            {
                _semaphore = null;

                for (int i = 0; i < listBoxWorking.Items.Count; i++)
                {
                    MyThread thread = listBoxWorking.Items[i] as MyThread;
                    thread.Stop();
                }
                listBoxWorking.Invoke((MethodInvoker)(() => listBoxWorking.Items.Clear()));
            }
        }
    }
}