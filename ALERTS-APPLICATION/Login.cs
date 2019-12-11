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
            /*CHECKS IF USER IS LOGGED IN ALREADY*/
            if(LoginController.Instance.checkUserLogin() != -1)
            {
                Main main = new Main();
                main.Show();
                this.Close();
            }

            lblErrors.Visible = false;

            
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



           while (MQTTHandler.Instance.UserID == -1) { }


            int userID = MQTTHandler.Instance.UserID;


            if (userID == 0)
            {
                lblErrors.Text = "Wrong username/password combination!";
                lblErrors.Visible = true;
                txtPassword.Clear();

                MQTTHandler.Instance.UserID = -1;
                return;
            }


            Main main = new Main();
            main.Show();
            this.Close();
          
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
