using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaphoresProj
{
    public partial class SemaphoresTest : Form
    {
        private int _count = 0;
        private static Semaphore _semaphore;

        public SemaphoresTest()
        {
            InitializeComponent();

            listBoxCreated.DisplayMember = "Count";
            listBoxWaiting.DisplayMember = "Count";
            listBoxWorking.DisplayMember = "Count";
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
            listBoxWorking.Invoke((MethodInvoker)(() => listBoxWorking.Items.Remove(thread)));
            listBoxWorking.Invoke((MethodInvoker)(() => listBoxWorking.Items.Add(thread)));
        }

        public void RemoveWorkingThread(MyThread thread)
        {
            listBoxWorking.Invoke((MethodInvoker)(() => listBoxWorking.Items.Remove(thread)));
        }

        public void IncreaseNumber(MyThread thread)
        {
            thread.State = thread.Num.ToString();
        }


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            _count++;

            MyThread thread = new MyThread(this, _count);
            
            thread.State = "created";
            listBoxCreated.Items.Add(thread);
        }

        private void listBoxCreated_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MyThread thread = listBoxCreated.SelectedItem as MyThread;
            thread.State = "waiting";
            listBoxWaiting.Items.Add(thread);
            listBoxCreated.Items.RemoveAt(listBoxCreated.SelectedIndex);


            thread.Start();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            int count = int.Parse(domainUpDownPlaces.SelectedItem.ToString());

            buttonAccept.Enabled = false;
            buttonCreate.Enabled = true;

            _semaphore = new Semaphore(initialCount: count, maximumCount: count);
        }
    }
}
