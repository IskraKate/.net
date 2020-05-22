using System;
using System.Threading;
using System.Windows.Forms;

//3.	Написать приложение, показывающее диалоговое окно с одной кнопкой.При нажатии на эту кнопку открывается второе
//   немодальное диалоговое окно, в котором в диапазоне от 1 до 20 с интервалом в 0.5 сек изменяется счетчик.Когда
//   счетчик доходит до 20, немодальное диалоговое окно закрывается.Показ немодального диалогового окна и увеличение
//   счетчика реализовать в отдельном потоке пользовательского интерфейса.

namespace NewDialogProj
{
    public partial class FormMain : Form
    {        
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonShowNew_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(ThreadProc);
            thread.Start();
        }

        private void ThreadProc()
        {
            NumForm numForm = new NumForm();
            numForm.ShowDialog();
        }
    }
}
