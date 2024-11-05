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
        
        private void Admin_Control_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wH_MANAGEMENTDataSet.Roles' table. You can move, or remove it, as needed.
            Loaddata();
            lbl_name.Text = _admin.Username.ToString();
            lbl_role.Text = _admin.Role.ToString();
            btn_home.Select();
        } //done

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (pn_user_dgv.SelectedRows.Count > 0)
            {
                var seclectRow = pn_user_dgv.SelectedRows[0];
                string name = seclectRow.Cells[1].Value.ToString();
                string phone = seclectRow.Cells[2].Value.ToString();
                string address = seclectRow.Cells[4].Value.ToString();
                string role = seclectRow.Cells[5].Value.ToString();
                string warehouse = seclectRow.Cells[6].Value.ToString();
                pn_user_txt_name.Text = name;
                pn_user_txt_phone.Text = phone;
                pn_user_txt_address.Text = address;
                pn_user_txt_role.Text = role;
                pn_user_txt_wh.Text = warehouse;
                
            }
        } //done

        //open panel action
        private void btn_home_Click(object sender, EventArgs e)
        {
            pn_home.Visible = true;
            pn_user.Visible = false;
            pn_wh.Visible = false;
        } //done

        private void btn_user_Click(object sender, EventArgs e)
        {
            pn_user.Visible = true;
            pn_wh.Visible= false;
            pn_home.Visible = false;

        } //done

        private void btn_warehouse_Click(object sender, EventArgs e)
        {
            pn_wh.Visible = true;
            pn_user.Visible = false;
            pn_home.Visible = false;
        } //done

        //add action
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (pn_user_add.Visible == false)
            {
                pn_user_edit.Visible = false;
                pn_user_add.Visible = true;
                pn_user_add.Dock = DockStyle.Right;
            }
            else
            {
                pn_user_add.Visible = false;
                pn_user_add_txt_address.Text = string.Empty;
                pn_user_add_txt_name.Text = string.Empty;
                pn_user_add_txt_phone.Text = string.Empty;
                pn_user_add_cmb_role.SelectedIndex = -1;
                pn_user_add_cmb_wh.SelectedIndex = -1;

            }
        } //done

        private void pn_btn_add_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pn_user_add_txt_name.Text) || string.IsNullOrWhiteSpace(pn_user_add_txt_address.Text) || string.IsNullOrWhiteSpace(pn_user_add_txt_phone.Text)|| string.IsNullOrWhiteSpace(pn_user_add_cmb_role.Text) || string.IsNullOrEmpty(pn_user_add_cmb_wh.Text))
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
                    Role = GetRoleName(pn_user_add_cmb_role.SelectedIndex + 1),
                    Warehouse = GetWareHouseName(pn_user_add_cmb_wh.SelectedIndex + 1)
                };
                _userService.AddUser(U);
            }
            MessageBox.Show("Da them user thanh cong");
            Loaddata();

        } //done

        private void pn_user_add_btn_close_Click(object sender, EventArgs e)
        {
            pn_user_add.Visible = false;
            pn_user_add_txt_address.Text = string.Empty;
            pn_user_add_txt_name.Text = string.Empty;
            pn_user_add_txt_phone.Text = string.Empty;
            pn_user_add_cmb_role.SelectedIndex = -1;
        } //done

        //delete action
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
        } //done

        //edit action
        private void pn_user_btn_edit_Click(object sender, EventArgs e)
        {
            if(pn_user_dgv.SelectedRows.Count > 0)
            {
                var seclectRow = pn_user_dgv.SelectedRows[0];
                string UserID = seclectRow.Cells[0].Value.ToString();
                try
                {
                    var user = _userService.GetUser(int.Parse(UserID));
                    if(user != null)
                    {
                        pn_user_edit_txt_id.Text = user.Id.ToString();
                        pn_user_edit_txt_name.Text= user.Username;
                        pn_user_edit_txt_address.Text = user.Address;
                        pn_user_edit_txt_phone.Text = user.Phone;
                        pn_user_edit_cmb_role.SelectedIndex = GetRoleID(user.Role)-1;
                        pn_user_edit_cmb_wh.SelectedIndex = GetWareHouseID(user.Warehouse)-1;
                    }
                    if(pn_user_edit.Visible==false)
                    {
                        pn_user_add.Visible = false;
                        pn_user_edit.Visible = true;
                        pn_user_edit.Dock = DockStyle.Right;

                    }
                    else
                    {
                        pn_user_edit.Visible = false;
                        pn_user_edit_txt_id.Text = string.Empty;
                        pn_user_edit_txt_name.Text = string.Empty;
                        pn_user_edit_txt_address.Text = string.Empty;
                        pn_user_edit_txt_phone.Text = string.Empty;
                        pn_user_edit_cmb_role.SelectedIndex = -1;
                        pn_user_edit_cmb_wh.SelectedIndex = -1;
                    }
                   
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("vui lòng chọn dòng");
            }

        } //done

        private void pn_user_edit_btn_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pn_user_edit_txt_name.Text) || string.IsNullOrWhiteSpace(pn_user_edit_txt_address.Text) || string.IsNullOrWhiteSpace(pn_user_edit_txt_phone.Text) || string.IsNullOrWhiteSpace(pn_user_edit_cmb_role.Text) || string.IsNullOrEmpty(pn_user_edit_cmb_wh.Text))
            {
                MessageBox.Show("Please fill full user information");
                return;
            }
            {
                User U = new User()
                {   Id = int.Parse(pn_user_edit_txt_id.Text),
                    Username = pn_user_edit_txt_name.Text,
                    Address = pn_user_edit_txt_address.Text,
                    Phone = pn_user_edit_txt_phone.Text,
                    Role = GetRoleName(pn_user_edit_cmb_role.SelectedIndex + 1),
                    Warehouse = GetWareHouseName(pn_user_edit_cmb_wh.SelectedIndex + 1)
                };
                _userService.UpdateUser(U);
            }
            MessageBox.Show("Da chỉnh sửa user thanh cong");
            Loaddata();
        } 

        private void pn_user_edit_btn_close_Click(object sender, EventArgs e)
        {
            pn_user_edit.Visible = false;
        } //done

        //transfer function
        private string GetRoleName(int role)
        {
            switch (role)
            {
                case 1: return "Admin";
                case 2: return "Manager";
                case 3: return "Staff";
                default: throw new ArgumentException("Invalid role name");
            }
        } //done

        private string GetWareHouseName(int role)
        {
            switch (role)
            {
                case 1: return "Kho Miền Bắc";
                case 2: return "Kho Miền Nam";
                case 3: return "Kho Miền Trung";
                default: throw new ArgumentException("Invalid warehouse name");
            }
        } //done

        private int GetRoleID(string role)
        {
            switch (role)
            {
                case "Admin": return 1 ;
                case "Manager": return 2;
                case "Staff": return 3;
                default: throw new ArgumentException("Invalid role name");
            }
        } //done

        private int GetWareHouseID(string warehouse)
        {
            switch (warehouse)
            {
                case "Kho Miền Bắc": return 1;
                case "Kho Miền Nam": return 2;
                case "Kho Miền Trung": return 3;
                default: throw new ArgumentException("Invalid warehouse name");
            }
        } //done
    }
}
