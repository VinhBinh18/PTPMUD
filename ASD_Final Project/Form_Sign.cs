using ASD_Final_Project.Admin;
using ASD_Final_Project.Program;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASD_Final_Project
{
    public partial class Form_Sign : Form
    {
        private readonly UserService _userService;
        public Form_Sign(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void pn_lb_login_Click(object sender, EventArgs e)
        {
            pn_register.Visible = false;
            pn_txt_confirm.Clear();
            pn_txt_name.Clear();
            pn_txt_password.Clear();
            pn_cb.Checked = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            pn_login.Visible = false;
            pn_register.Visible = true;
            pn_register.Dock = DockStyle.Fill;

        }
        private void label8_Click(object sender, EventArgs e)
        {
            pn_login.Visible = true;
            pn_register.Visible = false;
            pn_login.Dock = DockStyle.Fill;
        }


        private void btn_login_submit_Click(object sender, EventArgs e)
        {
            User userLog = _userService.LoginUser(txt_name.Text, txt_password.Text);
            if (userLog.Role == "Admin")
            {
                /*Admin_Control admin_Control = new Admin_Control(_userService, userLog);
                admin_Control.ShowDialog();
                this.Close();*/
                Form_DashBoard admin_Dashboard = new Form_DashBoard(_userService);
                admin_Dashboard.ShowDialog();
                this.Hide();
            }
            if (userLog.Role == "Manager")
            {
                Admin_Control admin_Control = new Admin_Control(_userService, userLog);
                admin_Control.ShowDialog();
            }
            if (userLog.Role == "Staff")
            {
                Admin_Control admin_Control = new Admin_Control(_userService, userLog);
                admin_Control.ShowDialog();
            }
            if (userLog.Role == null)
            {
                return;
            }
        }

        private void pn_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (pn_txt_password.PasswordChar == '*')
            {
                // Show password
                pn_txt_confirm.PasswordChar = '\0';
                pn_txt_password.PasswordChar = '\0';
                pn_cb.Text = "Hide Password";
            }
            else
            {
                // Hide password
                pn_txt_confirm.PasswordChar = '*';
                pn_txt_password.PasswordChar = '*';
                pn_cb.Text = "Show Password";
            }
        }

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_password.PasswordChar == '*')
            {
                // Show password
                
                txt_password.PasswordChar = '\0';
                cb.Text = "Hide Password";
            }
            else
            {
                // Hide password
                txt_password.PasswordChar = '*';
                cb.Text = "Show Password";
            }
        }

       
    }
}
