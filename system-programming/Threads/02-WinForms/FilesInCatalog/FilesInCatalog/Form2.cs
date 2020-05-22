using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace FilesInCatalog
{
    public partial class Form2 : Form
    {
        List<FileInfo> fiList;
        int numOfFiles = 0;
        long sizeOfFiles = 0;
        System.Timers.Timer timer;
        private string _folderName;


        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string folderName)
        {
            InitializeComponent();

            _folderName = folderName;

            Thread thread = new Thread(ThreadProc);

            thread.Start();
        }

        private void ThreadProc()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 500;
            timer.Elapsed += timerTick;
            timer.Start();
        }

        private void timerTick(object sender, EventArgs eventArgs)
        {
            DirectoryInfo di = new DirectoryInfo(_folderName);

            sizeOfFiles = 0;
            numOfFiles = 0;

            numOfFiles = di.GetFiles().Length;

            fiList = di.GetFiles().ToList();

            foreach (var file in fiList)
            {
                sizeOfFiles += file.Length;
            }

            label2.BeginInvoke((MethodInvoker)(() => label2.Text = numOfFiles.ToString()));
            label4.BeginInvoke((MethodInvoker)(() => label4.Text = sizeOfFiles.ToString()));
        }

    }
}
