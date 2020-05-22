using System;
using System.Windows.Forms;

namespace _3timersProj
{

    //1.	Написать приложение, показывающее диалоговое окно с тремя счетчиками и тремя кнопками: Старт, Стоп, Сброс.
    //Старт запускает счетчики(интервалы обновления — 0.5 сек, 1 сек, 1.5 сек), Стоп останавливает, Сброс останавливает
    //и сбрасывает счетчики в 0. Увеличение счетчиков реализовать в отдельных рабочих потоках.

    public partial class TimersForm : Form
    {
        private ThreadTimer[] _timers;

        public TimersForm()
        {
            InitializeComponent();

            _timers = new ThreadTimer[timersGroupBox.Controls.Count];
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            double interval = 500;

            for(int i = 0; i < _timers.Length; i++)
            {
                _timers[i] = new ThreadTimer(interval, timersGroupBox.Controls[i] as Label);

                interval += 500;
            }    

            startButton.Enabled = false;
            buttonDischarge.Enabled = true;
            buttonStop.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _timers.Length; i++)
            {
                _timers[i].StopOrContinue();
            }

            buttonStop.Text = buttonStop.Text == "Stop" ? "Continue" : "Stop";
        }

        private void buttonDischarge_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _timers.Length; i++)
            {
                _timers[i].Discharge();
            }

            startButton.Enabled = true;
            buttonDischarge.Enabled = false;
            buttonStop.Enabled = false;

            buttonStop.Text = "Stop";
        }
    }
}
