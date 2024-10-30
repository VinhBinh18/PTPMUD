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
    public partial class Signup_Form : Form
    {
        public Signup_Form()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Mininize_Click(object sender, EventArgs e)
        {
            btn_Mininize.ForeColor = Color.DarkGray;
        }

        private void btn_Close_MouseHover(object sender, EventArgs e)
        {
            btn_Close.ForeColor = Color.Red;
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void btn_Createnew_Click(object sender, EventArgs e)
        {
            if (txt_Username.Text == "" || txt_Password.Text == "" )
            {

                this.Alert("Please fill in all the required information", Form_Alert.enmType.Error);
            }
            else
            {
                this.Alert("Login successfully", Form_Alert.enmType.Success);
            }
        }
    }
}
