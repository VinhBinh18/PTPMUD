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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Username_Click(object sender, EventArgs e)
        {

        }

        private void btn_Mininize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txt_Username_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_Username.Text == "")
                {
                    txt_Username.Text = "";
                    return;
                }
                txt_Username.ForeColor = Color.Black;
            }
            catch { }
        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_Password.Text == "")
                {
                    txt_Password.Text = "";
                    return;
                }
                txt_Password.ForeColor = Color.Black;
            }
            catch { }
        }

        private void txt_Username_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void txt_Username_Click(object sender, EventArgs e)
        {
            txt_Username.SelectAll();   
        }

        private void txt_Password_Click(object sender, EventArgs e)
        {
            txt_Password.SelectAll();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
        }

        private void lbl_Newaccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup_Form signup_Form = new Signup_Form();
            signup_Form.Show();
            this.Hide();    
        }

        private void btn_Mininize_MouseHover(object sender, EventArgs e)
        {
            btn_Mininize.ForeColor = Color.DarkGray;
        }

        private void btn_Close_MouseHover(object sender, EventArgs e)
        {
            btn_Close.ForeColor = Color.Red;
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void btn_Login_Click_1(object sender, EventArgs e)
        {
            if (txt_Username.Text == "" || txt_Password.Text == "")
            {
              
                this.Alert("Please fill in all the required information", Form_Alert.enmType.Error);
            }
            else
            {
                this.Alert("Login successfully", Form_Alert.enmType.Success);
            }
        }

        private void lbl_Forget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
       /*     Form_Dashboard form_dashboard = new Form_Dashboard();
            form_dashboard.Show();
            this.Hide();*/
        }
    }
}
