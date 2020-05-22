using System;
using System.Windows.Forms;

namespace FilesInCatalog
{
    public partial class FormFiles : Form
    {
        //4.	Написать приложение, показывающее диалоговое окно с полем ввода для указания каталога и кнопкой для показа
        //немодального диалогового окна.В этом окне показывается постоянно обновляющаяся информация о количестве файлов
        //в этом каталоги и их суммарном размере.

        string folderName;
        FolderBrowserDialog fbd;

        public FormFiles()
        {
            fbd = new FolderBrowserDialog();
            
            fbd.ShowDialog();
            folderName = fbd.SelectedPath;

            InitializeComponent();

            textBox1.Text = folderName;

        }

        private void buttonDir_Click(object sender, System.EventArgs e)
        {
            Form2 form = new Form2(folderName);
            form.Show();
        }

        private void buttonDirAgain_Click(object sender, EventArgs e)
        {
            fbd = new FolderBrowserDialog();

            fbd.ShowDialog();
            folderName = fbd.SelectedPath;

            textBox1.Text = folderName;
        }
    }
}
