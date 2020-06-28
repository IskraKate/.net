using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    //Написать программу, которая копирует файл блоками по 4096 байт в указанное место.Программа должна отображать прогресс копирования с помощью элемента управления «ProgressBar». Пользователь может указать пути к файлам с помощью клавиатуры или с помощью диалогового окна, которое отображается при нажатии кнопок Файл… Запуск копирования происходит при нажатии кнопки «Копировать». Копирование файла необходимо выполнить асинхронно с использованием асинхронных делегатов.
    public partial class FormAsyncCopy : System.Windows.Forms.Form
    {
        public FormAsyncCopy()
        {
            InitializeComponent();
            progressBar.Value = 0;
        }

        private void buttonFileFrom_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd =new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();

            if (!String.IsNullOrEmpty(ofd.FileName))
            {
                ChooseFile(textBoxFrom, ofd.FileName);
            }
        } 

        private void buttonWhere_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text file (.txt)|*.txt|Document (.doc)|*.doc";
            DialogResult result = sfd.ShowDialog();

            if (!String.IsNullOrEmpty(sfd.FileName))
            {
                ChooseFile(textBoxWhere, sfd.FileName);
            }
        }

        private void ChooseFile(TextBox txtBox, string path)
        {
             txtBox.Text = path;
        }

        private void CopyAsync()
        {
            buttonCopy.Enabled = false;
            Task.Run(() => WorkAsync());
        }

        private void WorkAsync()
        {
            using (var input = new FileStream(textBoxFrom.Text, FileMode.Open, FileAccess.Read))
            using (var output = new FileStream(textBoxWhere.Text, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[4096];
                int read;

                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    output.Write(buffer, 0, read);
                    float pct = (1.0f * input.Position) / input.Length * 100.0f;
                    progressBar.Invoke((MethodInvoker)(() => progressBar.Value = (int)pct));
                }

                if(progressBar.Value == 100)
                        buttonCopy.Invoke((MethodInvoker)(() => buttonCopy.Enabled = true));
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            CopyAsync();
        }
    }
}
