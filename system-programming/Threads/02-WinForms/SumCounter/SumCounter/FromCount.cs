using System;
using System.Threading;
using System.Windows.Forms;

namespace SumCounter
{
    public partial class CounterForm : Form
    {
        public CounterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadTimer threadTimer = new ThreadTimer(textBox1, label1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThreadTimer threadTimer = new ThreadTimer(textBox2, label2);
        }

    }
}
