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
            Customize();
            _userService = userService;
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


        private void ShowPanel(Panel panelToShow)
        {
            pn_Home.Visible = false;

            panelToShow.Visible = true;
            panelToShow.Dock = DockStyle.Fill;
        }
        private void btn_home_Click(object sender, EventArgs e)
        {
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
            showMenu(pn_MenuWH);
            MoveSidePanel(btn_Menu);
        }

        private void pn_Wh1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lb_GoogWh1_Click(object sender, EventArgs e)
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
    }
}
