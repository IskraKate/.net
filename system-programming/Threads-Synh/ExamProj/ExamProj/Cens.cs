using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ExamProj
{
    public partial class FormCens : System.Windows.Forms.Form
    {
        private List<FileInfo> _fileList = new List<FileInfo>();
        private List<CensoredFileInfo> _cencoredFileList = new List<CensoredFileInfo>();
        private List<Word> _words = new List<Word>();
        private Thread _thread;
        private ManualResetEvent _event;

        private ReportFile _report;

        public FormCens()
        {
            InitializeComponent();
            _event = new ManualResetEvent(true);
        }

        private void AddCen()
        {
            if (!String.IsNullOrEmpty(textBoxCens.Text))
            {
                listBoxCens.Items.Add(textBoxCens.Text);

                _words.Add(new Word(textBoxCens.Text));

                textBoxCens.Text = String.Empty;

                if (!string.IsNullOrEmpty(textBoxCopy.Text))
                {
                    buttonStart.Enabled = true;
                }
            }
        }

        private void buttonAddWord_Click(object sender, EventArgs e)
        {
            AddCen();
        }

        private void buttonFromFile_Click(object sender, EventArgs e)
        {
            string[] readText;

            using (var ofd = new OpenFileDialog())
            {
                ofd.ShowDialog();

                if (!String.IsNullOrEmpty(ofd.FileName))
                {
                    readText = File.ReadAllLines(ofd.FileName);
                    AddWordsToListBox(readText);
                }
            }
        }

        private void AddWordsToListBox(string[] ar)
        {
            for (int i = 0; i < ar.Length; i++)
            {
                var word = ar[i].Split(' ');
                for (int j = 0; j < word.Length; j++)
                {
                    listBoxCens.Items.Add(word[j]);
                    _words.Add(new Word(word[j]));
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxCens.Items.Count != 0 && listBoxCens.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show("Are you sure, you want to delete the world?:)", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);

                if (result == DialogResult.Yes)
                {
                    foreach (Word word in _words)
                    {
                        if (word.CenWord == listBoxCens.SelectedItem.ToString())
                        {
                            _words.Remove(word);
                            break;
                        }
                    }
                    listBoxCens.Items.RemoveAt(listBoxCens.SelectedIndex);
                }
            }
            else
            {
                MessageBox.Show(@"You can`t delete, because you din`t choose smth or smth doesn`t exist at all ¯\_(ツ)_/¯", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
            }
        }

        private void buttonCopyTo_Click(object sender, EventArgs e)
        {
            textBoxCopy.Text = String.Empty;

            using (var fbd = new FolderBrowserDialog())
            {
                fbd.ShowDialog();

                if (!String.IsNullOrEmpty(fbd.SelectedPath))
                {
                    textBoxCopy.Text = fbd.SelectedPath;
                }
            }
        }

        private void textBoxCopy_TextChanged(object sender, EventArgs e)
        {
            if (listBoxCens.Items.Count > 0)
            {
                buttonStart.Enabled = true;
                progressBar.Enabled = true;
                buttonStop.Enabled = true;
                buttonAbort.Enabled = true;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;

            _thread = new Thread(ThreadProc);
            _thread.IsBackground = true;
            _thread.Start();
        }
    
        private void ThreadProc()
        {
            string[] drives = Environment.GetLogicalDrives();

            progressBar.Invoke((MethodInvoker)(() => progressBar.Value = 0));

            Task[] tasks = new Task[drives.Length];

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    Directories(drives[i]);
                });

                Thread.Sleep(100); 
            }

            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            Task.WaitAll(tasks);

            timer.Stop();

            GetWords();

            progressBar.Invoke((MethodInvoker)(() => progressBar.Value = 0));
            _fileList.Clear();


            label1.Invoke((MethodInvoker)(() => label1.Text = "Save..."));
            _report = new ReportFile(_cencoredFileList, _words);
            _report.SaveReportFile(textBoxCopy.Text + "\\Report File\\");
            _report.SaveMostPopularWord(textBoxCopy.Text + "\\Report File\\");

            buttonStart.Invoke((MethodInvoker)(() => buttonStart.Enabled = true));
            label1.Invoke((MethodInvoker)(() => label1.Visible = false));
            label1.Invoke((MethodInvoker)(() => label1.Text = "Getting files..."));
            MessageBox.Show("Done!:)");
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string text = label1.Text;
            string lastSymbols = text.Substring(13);

            if (lastSymbols.Length == 3)
            {
                text = text.Remove(13, 3);
            }

            text += '.';

            label1.Invoke((MethodInvoker)(() => label1.Text = text));
        }

        private void Directories(string path)
        {
            _event.WaitOne(Timeout.Infinite);

            DirectoryInfo di = new DirectoryInfo(path);
            label1.Invoke((MethodInvoker)(() => label1.Visible = true));  

            try
            {
                var dirs = di.GetDirectories();

                for (int i = 0; i < dirs.Length; i++)
                {
                    Directories(dirs[i].FullName);
                }


                var files = di.GetFiles();

                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Extension == ".txt" || files[i].Extension == ".doc" || files[i].Extension == ".docx")
                    {
                        _fileList.Add(files[i]);
                    }
                }
            }
            catch
            {

            }
        }

        private void Replacer(int startIndex, int endIndex, ref int value)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                try
                {
                    _event.WaitOne(Timeout.Infinite);

                    using (StreamReader sr = new StreamReader(_fileList[i].FullName))
                    {
                        string text = sr.ReadToEnd();
                        string newText = string.Empty;

                        foreach (var word in _words)
                        {
                            if (text.Contains(word.CenWord))
                            {
                                _cencoredFileList.Add(new CensoredFileInfo(_fileList[i]));

                                newText = ReplaseWord(_cencoredFileList.Last(), text);
                                SaveReplacedText(_fileList[i], newText);

                                break;
                            }
                        }
                    }
                }
                catch
                {

                }
                int progressBarValue = value;
                progressBar.Invoke((MethodInvoker)(() => progressBar.Value = progressBarValue));
                value++;
            }
        }
        private void GetWords()
        {
            label1.Invoke((MethodInvoker)(() => label1.Text = "Censoring files and copy them...")); 

            progressBar.Invoke((MethodInvoker)(() => progressBar.Maximum = _fileList.Count));
            progressBar.Invoke((MethodInvoker)(() => progressBar.Value = 0));
            int value = 1;

            int taskcount = _fileList.Count / 10000;
            Task[] tasks = new Task[taskcount + 1];
            int startIndex = 0;
            int endIndex = 10000;

            for(int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    Replacer(startIndex, endIndex, ref value);
                });

                startIndex = endIndex;
                if((_fileList.Count - endIndex) < 10000)
                {
                    endIndex = _fileList.Count;
                }
                else
                {
                    endIndex += 10000;
                }
            }

            Task.WaitAll(tasks);             
        }

        private string ReplaseWord(CensoredFileInfo file, string text)
        {
            string newText = text;
            foreach (var word in _words)
            {
                word.ReplacementCount += CountWords(text, word.CenWord);
                file.ReplacementCount++;
            }

            return newText;
        }
        private int CountWords(string text, string word)
        {
            int count = (text.Length - text.Replace($" {word} ", "*******").Length) / word.Length;
            return count * -1;
        }

        private void SaveReplacedText(FileInfo file, string newText)
        {
            Directory.CreateDirectory(textBoxCopy.Text + "\\CopyCensored\\");
            File.WriteAllText(textBoxCopy.Text + "\\CopyCensored\\" + file.Name, newText);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            buttonPlay.Enabled = false;
            _event.Set();
        }
        private void buttonPause_Click(object sender, EventArgs e)
        {
            buttonPlay.Enabled = true;   
            _event.Reset();
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            _thread.Abort();
            progressBar.Invoke((MethodInvoker)(() => progressBar.Value = 0));

            label1.Visible = false;
            buttonStop.Enabled = false;
            buttonAbort.Enabled = false;

            if(listBoxCens.Items.Count>0 && !String.IsNullOrEmpty(textBoxCopy.Text))
            {
                buttonStart.Enabled = true; 
            }
        }

        private void textBoxCens_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                AddCen();
            }
        }
    }
}
