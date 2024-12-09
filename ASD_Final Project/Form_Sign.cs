﻿using ASD_Final_Project.Admin;
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

  

        private void btn_login_submit_Click(object sender, EventArgs e)
        {
            if(txt_name.Text == "" ||txt_password.Text == "")
            {
                MessageBox.Show("vui long dien ten dang nhap hoac mat khau");
                return;
            }
            else
            {
                var userLog = _userService.LoginUser(txt_name.Text, txt_password.Text);
                if(userLog == null)
                {
                    return;
                }
                else
                {
                   
                    Form_DashBoard admin_Dashboard = new Form_DashBoard(_userService, userLog);
                    admin_Dashboard.ShowDialog();
                    this.Hide();
                   
                }
                
               
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
