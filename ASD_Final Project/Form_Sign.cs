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
            pn_register.Visible=true;
            pn_register.Dock = DockStyle.Fill;

        }
        private void Sign_Form_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_submit_Click(object sender, EventArgs e)
        {
            User userLog = _userService.LoginUser(txt_name.Text, txt_password.Text);
            if(userLog.Role == "Admin")
            {
                Admin_Control admin_Control = new Admin_Control(_userService, userLog);
                admin_Control.ShowDialog();
            }
            if(userLog.Role == "Manager")
            {
                Admin_Control admin_Control = new Admin_Control(_userService, userLog);
                admin_Control.ShowDialog();
            }
            if (userLog.Role == "Staff")
            {
                Admin_Control admin_Control = new Admin_Control(_userService, userLog);
                admin_Control.ShowDialog();
            }
        }
    }
}
