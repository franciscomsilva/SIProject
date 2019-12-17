using ALERTS_APPLICATION.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALERTS_APPLICATION
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            lblErrors.Visible = false;

            LoginController.Instance.checkTokenSaved();

            DateTime startTime = DateTime.Now;

            while (LoginController.Instance.UserID == -1 && DateTime.Now.Subtract(startTime).Seconds <= 5) { }

            if(LoginController.Instance.UserID > 0)
            {
                Main main = new Main();
                main.Show();

                BeginInvoke(new MethodInvoker(delegate
                {
                    Hide();
                })); 
            }

            lblErrors.Text = "Error connecting to database!";
            lblErrors.Visible = true;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblErrors.Visible = false;

            if (txtUsername.Text.Length <= 0 || txtPassword.Text.Length <= 0)
            {
                lblErrors.Text = "Please insert an username and password!";
                lblErrors.Visible = true;
                return;
            }

            LoginController.Instance.login(txtUsername.Text, txtPassword.Text);

            DateTime startTime = DateTime.Now;

            while (LoginController.Instance.UserID == -1 && DateTime.Now.Subtract(startTime).Seconds <= 5) { }

            int userID = LoginController.Instance.UserID;

            if(userID == -1)
            {

                lblErrors.Text = "Error connecting to database!";
                lblErrors.Visible = true;
                txtPassword.Clear();

                return;
            }
            if (userID == 0)
            {
                lblErrors.Text = "Wrong username/password combination!";
                lblErrors.Visible = true;
                txtPassword.Clear();
                LoginController.Instance.UserID = -1;

                return;
            }

            Main main = new Main();
            main.Show();

            this.Visible = false;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
