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
    }
}
