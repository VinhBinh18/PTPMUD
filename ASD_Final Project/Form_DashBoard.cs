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
        private readonly User _admin;

        public Form_DashBoard(UserService userService, User Admin)
        {
            InitializeComponent();
            Customize();
            _userService = userService;
            _admin = Admin;
        }

        private void SidePanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Customize()
        {
            pn_MenuWH.Visible = false;
        }
        private void MoveSidePanel(Control C)
        {
            SidePanel.Height = C.Height;
            SidePanel.Top = C.Top;
        }

        private void HideAllPanels()
        {
            pn_Home.Visible = false;
            pn_Good.Visible = false;
            pn_Inventory.Visible = false;
            pn_Employee.Visible = false;
            pn_Order.Visible = false;
            pn_Wh1.Visible = false;
            pn_Wh2.Visible = false;
            pn_Wh3.Visible = false;

        }

        private void ShowPanel(Panel panelToShow)
        {
            pn_Home.Visible = false;
            HideAllPanels();
            panelToShow.Visible = true;
            panelToShow.Dock = DockStyle.Fill;
        }
        private void btn_home_Click(object sender, EventArgs e)
        {
            if (!sidepartExpand)
            {
                Sidepart.Start();
            }
            MoveSidePanel(btn_home);
            ShowPanel(pn_Home);
        }


        private void btn_wh1_Click(object sender, EventArgs e)
        {
            hideMenu();
            ShowPanel(pn_Wh1);
        }

        private void hideMenu()
        {
            if (pn_MenuWH.Visible == true)
                pn_MenuWH.Visible = false;
        }

        private void showMenu(Panel Menu)
        {
            if (Menu.Visible == false)
            {
                hideMenu();
                Menu.Visible = true;
            }
            else
            {
                Menu.Visible = false;
            }
        }

        private void btn_Menu_Click(object sender, EventArgs e)
        {
            if (!sidepartExpand)
            {
                Sidepart.Start();
            }
            showMenu(pn_MenuWH);
            MoveSidePanel(btn_Menu);
           
        }

        private void pn_Wh1_Paint(object sender, PaintEventArgs e)
        {

        }
        bool sidepartExpand = true;
        private void Sidepart_Tick(object sender, EventArgs e)
        {
            if (sidepartExpand)
            {
                pn_Sidebar.Width -= 5;
                if (pn_Sidebar.Width <= 50)
                {
                    sidepartExpand = false;
                    Sidepart.Stop();
                }
            }
            else
            {
                pn_Sidebar.Width += 5;
                if(pn_Sidebar.Width >= 180)
                {
                    sidepartExpand = true;
                    Sidepart.Stop();
                }
            }

        }

        private void btn_Menuside_Click_1(object sender, EventArgs e)
        {
            Sidepart.Start();

        }

        private void lb_Wh1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btm_goods_Click(object sender, EventArgs e)
        {
            ShowPanel(pn_Good);
        }

        private void btn_Inventory_Click(object sender, EventArgs e)
        {
            ShowPanel(pn_Inventory);
        }

        private void btn_Employee_Click(object sender, EventArgs e)
        {
            ShowPanel(pn_Employee);
        }

        private void btn_Order_Click(object sender, EventArgs e)
        {
            ShowPanel(pn_Order);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_Name_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void cb_Role_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_wh2_Click(object sender, EventArgs e)
        {
            hideMenu();
            ShowPanel(pn_Wh2);
        }

        private void btn_wh3_Click(object sender, EventArgs e)
        {
            hideMenu();
            ShowPanel(pn_Wh3);
        }

        private void pn_Wh1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Form_DashBoard_Load(object sender, EventArgs e)
        {
            label1.Text = _admin.Username;
            label2.Text = _admin.Role;
        }
    }
}
