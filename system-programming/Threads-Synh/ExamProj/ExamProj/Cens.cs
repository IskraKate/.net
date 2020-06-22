using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ExamProj
{
    public partial class FormCens : System.Windows.Forms.Form
    {
        private List<FileInfo> _fileList = new List<FileInfo>();
        private List<string> _words = new List<string>();
        public FormCens()
        {
            InitializeComponent();
        }

        private void buttonAddWord_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBoxCens.Text))
            {
                listBoxCens.Items.Add(textBoxCens.Text);
                textBoxCens.Text = String.Empty;
            }
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

                if(!String.IsNullOrEmpty(fbd.SelectedPath))
                {
                    textBoxCopy.Text = fbd.SelectedPath;
                }
            }
        }

        private void textBoxCopy_TextChanged(object sender, EventArgs e)
        {
            if(listBoxCens.Items.Count > 0)
            {
                buttonStart.Enabled = true;
                progressBar1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (buttonStart.Enabled)
            {
                buttonStart.Enabled = false;
                Thread thread = new Thread(ThreadProc);
                thread.IsBackground = true;
                thread.Start(); 
            }
        }
         
        private void ThreadProc()
        {
            string[] drives = Environment.GetLogicalDrives();
             
                for (int i = 0; i < drives.Length; i++)
                {
                    Directories(drives[i]);
                }

            MessageBox.Show(_fileList.Count.ToString());
            buttonStart.Enabled = true;
            _fileList.Clear();
        }

        private void Directories(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

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

                getWords();
            }
            catch { }
        }

        private void getWords()
        {
            foreach (var file in _fileList)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(file.FullName))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string textFromFile = line;
                        }
                    }
                }
                catch
                {

                }
               
              // CheckSimilar(file);
            }
             
        }

        private void CheckSimilar(FileInfo file)
        {
            var text = File.ReadAllText(file.FullName); 
             
            foreach (var word in _words)
            {
                foreach ( var item in listBoxCens.Items)
                {
                    if (word == item as string)
                    {
                        try
                        {
                            var newText = text.Replace(word, "*******");
                            Directory.CreateDirectory(textBoxCopy.Text + "\\CopyCensored\\");
                            File.WriteAllText(textBoxCopy.Text + "\\CopyCensored\\" + file.Name, newText);
                        }
                        catch { }
                    }
                }
            }
        }

    }
}
