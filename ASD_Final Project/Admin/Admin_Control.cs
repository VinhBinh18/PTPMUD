using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASD_Final_Project.Program;

namespace ASD_Final_Project.Admin
{
    public partial class Admin_Control : Form
    {
        private readonly UserService _userService;
        private readonly User _admin;

        public Admin_Control(UserService userService, User Admin)
        {
            InitializeComponent();
            _userService = userService;
            _admin = Admin;
        }


        void Loaddata()
        {
            try
            {
                var user = _userService.GetAllUsers();
                if (user != null && user.Any())
                {
                    dgv.DataSource = user.ToList();
                }
                else
                {
                    MessageBox.Show("No data retrieved from the database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            

        }



        private void dgv_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pn_btn_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pn_txt_name.Text) || string.IsNullOrWhiteSpace(pn_txt_address.Text) || string.IsNullOrWhiteSpace(pn_txt_phone.Text))
            {
                MessageBox.Show("Please fill full infor User");
                return;
            }
            {
                User U = new User()
                {
                    Username = pn_txt_name.Text,
                    Address = pn_txt_address.Text,
                    Phone = pn_txt_phone.Text,
                    Role = cmb_role.SelectedItem?.ToString()
                };
                _userService.AddUser(U);
            }
            

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            pn.Visible = true;
            pn.Dock = DockStyle.Fill;
        }

        private void Admin_Control_Load(object sender, EventArgs e)
        {
            Loaddata();
            lbl_name.Text = _admin.Username.ToString();
            lbl_role.Text = _admin.Role.ToString();
        }

        private void pn_VisibleChanged(object sender, EventArgs e)
        {

        }
    }
}
