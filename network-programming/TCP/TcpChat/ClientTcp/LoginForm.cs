using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTcp
{
    public partial class LoginForm : Form
    {
        private delegate void SendLoginHandler(string login);
        private event SendLoginHandler SendLogin;

        public LoginForm(Chat chat)
        {
            InitializeComponent();

            SendLogin += chat.RecieveLogin;
        }

        private bool ValidateLogin()
        {
            string login = loginTextBox.Text;

            foreach(char symbol in login)
            {
                if (!Char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (ValidateLogin())
            {
                SendLogin(loginTextBox.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Your login is not valid");
            }

        }

        private void loginTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                loginButton_Click(sender, new EventArgs());
            }
        }
    }
}
