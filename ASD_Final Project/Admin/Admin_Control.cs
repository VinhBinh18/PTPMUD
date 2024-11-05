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
                    pn_user_dgv.DataSource = user.ToList();
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
        } // done

        void Loaddata(int Wh_ID)
        {
            try
            {
                var user = _userService.GetAllUsers(Wh_ID);
                if (user != null && user.Any())
                {
                    pn_user_dgv.DataSource = user.ToList();
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
        } //done

        private void label8_Click(object sender, EventArgs e)
        {

        } //??

        private void pn_btn_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pn_user_add_txt_name.Text) || string.IsNullOrWhiteSpace(pn_user_add_txt_address.Text) || string.IsNullOrWhiteSpace(pn_user_add_txt_phone.Text)|| string.IsNullOrWhiteSpace(pn_user_cmb_role.Text))
            {
                MessageBox.Show("Please fill full user information");
                return;
            }
            {
                User U = new User()
                {
                    Username = pn_user_add_txt_name.Text,
                    Address = pn_user_add_txt_address.Text,
                    Phone = pn_user_add_txt_phone.Text,
                    Role = GetRoleName(pn_user_cmb_role.SelectedIndex + 1)

                };
                _userService.AddUser(U);
            }
            Loaddata();

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            pn_user_add.Visible = true;
            pn_user_add.Dock = DockStyle.Right;
        }

        private void Admin_Control_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wH_MANAGEMENTDataSet.Roles' table. You can move, or remove it, as needed.
            Loaddata();
            lbl_name.Text = _admin.Username.ToString();
            lbl_role.Text = _admin.Role.ToString();
            btn_home.Select();
        }

        private void pn_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void pn_add_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (pn_user_dgv.SelectedRows.Count > 0)
            {
                var selectRow = pn_user_dgv.SelectedRows[0];
                var cellValue = selectRow.Cells[0].Value;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out int userDelete))
                {
                    _userService.DeleteUser(userDelete);
                    MessageBox.Show("User deleted successfully!");
                    Loaddata();
                }
                else
                {
                    MessageBox.Show("Invalid value for deletion.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }
       
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (pn_user_dgv.SelectedRows.Count > 0)
            {
                var seclectRow = pn_user_dgv.SelectedRows[0];
                string name = seclectRow.Cells[1].Value.ToString();
                string phone = seclectRow.Cells[2].Value.ToString();
                string address = seclectRow.Cells[4].Value.ToString();
                string role = seclectRow.Cells[5].Value.ToString();
                pn_user_txt_name.Text = name;
                pn_user_txt_phone.Text = phone;
                pn_user_txt_address.Text = address;
                pn_user_txt_role.Text = role;
            }
        }

        private void btn_user_Click(object sender, EventArgs e)
        {
            pn_user.Visible = true;
            pn_wh.Visible= false;
            pn_home.Visible = false;

        }

        private void pn_wh_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_warehouse_Click(object sender, EventArgs e)
        {
            pn_wh.Visible = true;
            pn_user.Visible = false;
            pn_home.Visible = false;
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            pn_home.Visible = true;
            pn_user.Visible = false;
            pn_wh.Visible = false;
        }
        
        private string GetRoleName(int role)
        {
            switch (role)
            {
                case 1: return "Admin";
                case 2: return "Manager";
                case 3: return "Staff";
                default: throw new ArgumentException("Invalid role name");
            }
        }

        private void pn_user_add_btn_close_Click(object sender, EventArgs e)
        {
            pn_user_add.Visible = false;
            pn_user_add_txt_address.Text = string.Empty;
            pn_user_add_txt_name.Text = string.Empty;
            pn_user_add_txt_phone.Text = string.Empty;
            pn_user_cmb_role.SelectedIndex = -1;
        }
    }
}
