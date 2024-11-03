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
    public partial class Form_DashBoard : Form
    {
        UserService _userService;
        public Form_DashBoard(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void SidePanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void MoveSidePanel(Control C)
        {
            SidePanel.Height = C.Height;
            SidePanel.Top = C.Top;
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn_home);
        }

        private void btn_product_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn_product);
        }

        private void btn_Employee_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn_Employee);
        }

        private void btn_wh1_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn_wh1);
        }

        private void btn_wh2_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn_wh2);
        }

        private void btn_wh3_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn_wh3);
        }
    }
}
