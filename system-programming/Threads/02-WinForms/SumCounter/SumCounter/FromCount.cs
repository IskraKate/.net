using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SumCounter
{
    public partial class CounterForm : Form
    {
        private int _num;
        private int _interVal = 1;
        private int _newVal = 0;
        private System.Timers.Timer _timer;

        public CounterForm()
        {
            InitializeComponent();
            _timer = new System.Timers.Timer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBox1.Text))
            {
                _num = int.Parse(textBox1.Text);

                _timer.Interval = 500;
                _timer.Elapsed += TickTimer;
                _timer.Start();
            }
        }

        private void TickTimer(object sender, EventArgs e)
        {
            if(_interVal < _num)
            {
                _newVal += (_interVal) + (_interVal + 1);
                _interVal++;
            } 
           
            label1.Text = _newVal.ToString();
        }
    }
}
