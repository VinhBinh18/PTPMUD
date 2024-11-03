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
        public Form_Sign()
        {
            InitializeComponent();
        }

        private void Sign_Form_Load(object sender, EventArgs e)
        {

        }


        private void pn_lb_login_Click(object sender, EventArgs e)
        {
            pn_btn_register.Visible = false;
            pn_txt_confirm.Clear();
            pn_txt_name.Clear();
            pn_txt_password.Clear();
            pn_cb.Checked = false;
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            pn_register.Visible = true;
            pn_login.Visible = false;
            pn_register.Dock = DockStyle.Fill;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            pn_register.Visible = false;
            pn_login.Visible = true;
            pn_login.Dock = DockStyle.Fill;
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_password.Text == "")
            {

                this.Alert("Please fill in all the required information", Form_Alert.enmType.Error);
            }
            else
            {
                this.Alert("Login successfully", Form_Alert.enmType.Success);
            }
        }

        private void pn_btn_register_Click(object sender, EventArgs e)
        {
            if (pn_txt_name.Text == "" || pn_txt_password.Text == "" || pn_txt_confirm.Text == "")
            {

                this.Alert("Please fill in all the required information", Form_Alert.enmType.Error);
            }
            else
            {
                this.Alert("Login successfully", Form_Alert.enmType.Success);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_DashBoard dform = new Form_DashBoard();
            dform.Show();
            this.Hide();
        }
    }
}
