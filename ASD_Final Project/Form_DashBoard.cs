using ASD_Final_Project.Program;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ASD_Final_Project
{
    public partial class Form_DashBoard : Form
    {
        private readonly UserService _userService;
        private readonly ProductService _productService;
        private readonly User _user;
        private int wh_id;

        public Form_DashBoard(UserService userService, ProductService productService, User user)
        {
            _userService = userService;
            _user = user;
            _productService = productService;
            InitializeComponent();
            Customize();

        }

        private void Customize()
        {
            pn_MenuWH.Visible = false;
        }//done

        private void MoveSidePanel(Control C)
        {
            SidePanel.Height = C.Height;
            SidePanel.Top = C.Top;
        }//done

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
            pn_Welcome.Visible = false;
            pn_el_add.Visible = false;
            pn_setting.Visible = false;

        }//done

        private void ShowPanel(Panel panelToShow)
        {
            HideAllPanels();
            panelToShow.Visible = true;
            panelToShow.Dock = DockStyle.Fill;
        }//done

        private void btn_home_Click(object sender, EventArgs e)
        {
            if (!sidepartExpand)
            {
                Sidepart.Start();
            }
            if (_user.Role == "Admin")
            {
                wh_id = 0;
                quantity(wh_id);
                MoveSidePanel(btn_home);
                ShowPanel(pn_Home);
            } else if (_user.Role == "Manager")
            {
                wh_id = GetWareHouseID(_user.Warehouse);
                quantity(wh_id);
                MoveSidePanel(btn_home);
                ShowPanel(pn_Welcome);
            }
            else
            {
                wh_id = GetWareHouseID(_user.Warehouse);
                quantity(wh_id);
                MoveSidePanel(btn_home);
                ShowPanel(pn_Welcome);
            }

        }//done

        private void hideMenu()
        {
            if (pn_MenuWH.Visible == true)
                pn_MenuWH.Visible = false;
        }//done

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
        }//done

        private void btn_Menu_Click(object sender, EventArgs e)
        {
            if (!sidepartExpand)
            {
                Sidepart.Start();
            }
            showMenu(pn_MenuWH);
            MoveSidePanel(btn_Menu);

        }//done

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
                if (pn_Sidebar.Width >= 180)
                {
                    sidepartExpand = true;
                    Sidepart.Stop();
                }
            }

        }//done

        // link
        private void btn_Menuside_Click_1(object sender, EventArgs e)
        {
            Sidepart.Start();

        }//done
        private void btm_goods_Click(object sender, EventArgs e)
        {
            ShowPanel(pn_Good);
        }//done
        private void btn_Inventory_Click(object sender, EventArgs e)
        {
            ShowPanel(pn_Inventory);
        }//done
        private void btn_Employee_Click(object sender, EventArgs e)
        {
            ShowPanel(pn_Employee);
        }//done
        private void btn_Order_Click(object sender, EventArgs e)
        {
            ShowPanel(pn_Order);
        }//done

        //wh link
        private void btn_wh1_Click(object sender, EventArgs e)
        {
            hideMenu();
            wh_id = 1;
            quantity(wh_id);
            ShowPanel(pn_Wh1);
        }//done
        private void btn_wh2_Click(object sender, EventArgs e)
        {
            hideMenu();
            wh_id = 2;
            quantity(wh_id);
            ShowPanel(pn_Wh2);
        }//done
        private void btn_wh3_Click(object sender, EventArgs e)
        {
            hideMenu();
            wh_id = 3;
            quantity(wh_id);
            ShowPanel(pn_Wh3);
        }//done

        //Load
        private void Form_DashBoard_Load(object sender, EventArgs e)
        {
            lb_name.Text = _user.Username.ToString();
            lb_role.Text = _user.Role.ToString();
            if (_user.Role == "Admin")
            {
                quantity(0);
            }
            else {  quantity(wh_id); }
            checkRole(_user.Role, _user.Warehouse);
            btn_home.PerformClick();
        }//done

        // Employee loading
        private void dgv_employee_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_employee.SelectedRows.Count > 0)
            {
                var seclectRow = dgv_employee.SelectedRows[0];
                string name = seclectRow.Cells[1].Value.ToString();
                string phone = seclectRow.Cells[2].Value.ToString();
                string address = seclectRow.Cells[4].Value.ToString();
                string role = seclectRow.Cells[5].Value.ToString();
                string warehouse = seclectRow.Cells[6].Value.ToString();
                /* pn_user_txt_name.Text = name;
                 pn_user_txt_phone.Text = phone;
                 pn_user_txt_address.Text = address;
                 pn_user_txt_role.Text = role;
                 pn_user_txt_wh.Text = warehouse;*/

            }
        }//done
        void LoadDataUsers()
        {
            try
            {
                var user = _userService.GetAllUsers();
                if (user != null && user.Any())
                {
                    dgv_employee.DataSource = user.ToList();
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
        void LoadDataUsers(int Wh_ID)
        {
            try
            {
                var user = _userService.GetAllUsers(Wh_ID);
                if (user != null && user.Any())
                {
                    dgv_employee.DataSource = user.ToList();
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
        private void pn_Employee_VisibleChanged(object sender, EventArgs e)
        {
            if (pn_Employee.Visible)
            {
                if (wh_id != 0)
                {
                    LoadDataUsers(wh_id);
                }
                else
                {
                    LoadDataUsers();
                }
            }
        }//done

        //Inventory loading
        void LoadDataInventory()
        {
            try
            {
                _productService.InventoryProduct(dgv_inventory);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }//done
        void LoadDataInventory(int Wh_ID)
        {
            try
            {
                _productService.InventoryProduct(dgv_inventory, Wh_ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }//done
        private void pn_Inventory_VisibleChanged(object sender, EventArgs e)
        {
            if (pn_Inventory.Visible)
            {
                if (wh_id != 0)
                {
                    LoadDataInventory(wh_id);
                }
                else
                {
                    LoadDataInventory();
                }
            }
        }//done

        //Goods Loading
        void LoadDataGoods()
        {
            try
            {
                var product = _productService.GetAllProducts();
                if (product != null && product.Any())
                {
                    dgv_good.DataSource = product.ToList();
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
        }//done
        void LoadDataGoods(int Wh_ID)
        {
            try
            {
                var product = _productService.GetAllProducts(Wh_ID);
                if (product != null && product.Any())
                {
                    dgv_good.DataSource = product.ToList();
                }
                else
                {
                    MessageBox.Show("No data retrieved from the database int.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }//done
        private void pn_Good_VisibleChanged(object sender, EventArgs e)
        {
            if (pn_Good.Visible)
            {
                if (wh_id != 0)
                {
                    LoadDataGoods(wh_id);
                }
                else
                {
                    LoadDataGoods();
                }
            }
        }

        //Order Loading
        void LoadDataOrders()
        {
            try
            {
                _productService.OrderProduct(dgv_order);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        void LoadDataOrders(int Wh_ID)
        {
            try
            {
                _productService.OrderProduct(dgv_order, Wh_ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        private void pn_Order_VisibleChanged(object sender, EventArgs e)
        {
            if (pn_Order.Visible)
            {
                if (wh_id != 0)
                {
                    LoadDataOrders(wh_id);
                }
                else
                {
                    LoadDataOrders();
                }
            }
        }

        //count label
        private void quantity(int wh_id)
        {
            if (wh_id == 1)
            {
                label41.Text = _userService.CountUser(wh_id).ToString();
                label47.Text = _productService.CountProduct(wh_id).ToString();
            }
            else if (wh_id == 2)
            {
                label54.Text = _userService.CountUser(wh_id).ToString();
                label60.Text = _productService.CountProduct(wh_id).ToString();
            }
            else if (wh_id == 3)
            {
                label43.Text = _userService.CountUser(wh_id).ToString();
                label53.Text = _productService.CountProduct(wh_id).ToString();
            }
            else
            {
                label11.Text = _userService.CountUsers().ToString();
                label3.Text = _productService.CountProducts().ToString();
            }
        }

        //transfer function
        private void checkRole(string role, string wh)
        {
            if (role == "Admin")
            {
                btn_wh1.Visible = true;
                btn_wh2.Visible = true;
                btn_wh3.Visible = true;
            }
            else
            {
                if (wh == "Warehouse North")
                {
                    btn_wh2.Visible = false;
                    btn_wh3.Visible = false;
                }
                else if (wh == "Warehouse Central")
                {
                    btn_wh1.Visible = false;
                    btn_wh3.Visible = false;
                }
                else
                {
                    btn_wh2.Visible = false;
                    btn_wh3.Visible = false;
                }
            }

        }//done

        private int GetWareHouseID(string warehouse)
        {
            switch (warehouse)
            {
                case "Warehouse North": return 1;
                case "Warehouse South": return 2;
                case "Warehouse Central": return 3;
                default: throw new ArgumentException("Invalid warehouse name");
            }
        } //done

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

        private string GetWareHouseName(int warehouse)
        {
            switch (warehouse)
            {
                case 1: return "Warehouse North";
                case 2: return "Warehouse South";
                case 3: return "Warehouse Central";
                default: throw new ArgumentException("Invalid warehouse name");
            }
        } //done

        private int GetRoleID(string role)
        {
            switch (role)
            {
                case "Admin": return 1;
                case "Manager": return 2;
                case "Staff": return 3;
                default: throw new ArgumentException("Invalid role name");
            }
        } //done

        private void btn_el_add_Click(object sender, EventArgs e)
        {
            if (pn_el_add.Visible)
            {
                pn_el_add.Visible = false;
            } else
            {
                pn_el_add.Visible = true;
                pn_el_edit.Visible = false;
            }

        }

        private void btn_el_add_submit_Click(object sender, EventArgs e)
        {
            if (txt_el_name == null || cbx_el_role.SelectedIndex == -1 || cbx_el_wh.SelectedIndex== -1)
            {
                MessageBox.Show("vui lòng không để trống thông tin");
            }
            else
            {
                User user = new User();
                user.Username = txt_el_name.Text;
                user.Password = txt_el_pw.Text;
                user.Address = "Home";
                user.Phone = "12345678";
                user.Role = GetRoleName(cbx_el_role.SelectedIndex+1);
                user.Warehouse = GetWareHouseName(cbx_el_wh.SelectedIndex+1);
                try
                {
                    _userService.AddUser(user);
                    if (wh_id != 0)
                    {
                        LoadDataUsers(wh_id);
                    }
                    else
                    {
                        LoadDataUsers();
                    }
                    pn_el_add.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi he thong: " + ex);
                    pn_el_add.Visible = false;
                }
            }
            

        }

        private void btn_el_edit_Click(object sender, EventArgs e)
        {
            if (pn_el_edit.Visible == false)
            { 
                if (dgv_employee.SelectedRows.Count > 0)
                {
                    var seclectRow = dgv_employee.SelectedRows[0];
                    string UserID = seclectRow.Cells[0].Value.ToString();
                    pn_el_edit.Visible = true;
                    pn_el_add.Visible = false;
                    try
                    {
                        var user = _userService.GetUser(int.Parse(UserID));
                        if (user != null)
                        {
                            txt_el_edit_id.Text = user.Id.ToString();
                            txt_el_edit_name.Text = user.Username;
                            cbx_el_edit_role.SelectedIndex = GetRoleID(user.Role) - 1;
                            cbx_el_edit_wh.SelectedIndex = GetWareHouseID(user.Warehouse) - 1;
                        }
                        else
                        {
                            txt_el_edit_id.Text = string.Empty;
                            txt_el_edit_name.Text = string.Empty;
                            cbx_el_edit_role.SelectedIndex = -1;
                            cbx_el_edit_wh.SelectedIndex = -1;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading data: " + ex.Message);
                        pn_el_edit.Visible = false;
                        pn_el_add.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("vui lòng chọn dòng");
                    pn_el_edit.Visible = false;
                    pn_el_add.Visible = false;
                }
                
            }
            else
            {
               pn_el_edit.Visible = false;
                txt_el_edit_id.Text = string.Empty;
                txt_el_edit_name.Text = string.Empty;
                cbx_el_edit_role.SelectedIndex = -1;
                cbx_el_edit_wh.SelectedIndex = -1;
            }
        }

        private void btn_el_edit_submit_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_el_edit_id.Text);
            string role = GetRoleName(cbx_el_role.SelectedIndex + 1);
            string wh = GetWareHouseName(cbx_el_wh.SelectedIndex + 1);

            User user = _userService.GetUser(id);
            user.Role = role;
            user.Warehouse = wh;
            _userService.UpdateUser(user);
            if (wh_id != 0)
            {
                LoadDataUsers(wh_id);
            }
            else
            {
                LoadDataUsers();
            }
            pn_el_edit.Visible=false;
        }

        private void btn_el_delete_Click(object sender, EventArgs e)
        {
            if (dgv_employee.SelectedRows.Count > 0)
            {
                var selectRow = dgv_employee.SelectedRows[0];
                var cellValue = selectRow.Cells[0].Value;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out int userDelete))
                {
                    _userService.DeleteUser(userDelete);
                    MessageBox.Show("User deleted successfully!");
                    if (wh_id != 0)
                    {
                        LoadDataUsers(wh_id);
                    }
                    else
                    {
                        LoadDataUsers();
                    }
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

        private void btn_el_search_Click(object sender, EventArgs e)
        {
            if (wh_id == 0)
            {
                if (cbx_el_s_role.SelectedIndex == -1)
                {
                    loadDataSearch();
                }
                else
                {
                    loadDataSearch(cbx_el_s_role.SelectedIndex + 1);
                }
            }
            else
            {
                loadDataSearchNonAdmin(wh_id);
            }
        }
        private void loadDataSearch()
        {
            try
            {
                var user = _userService.GetUsers(txt_el_s_name.Text);
                if (user != null && user.Any())
                {
                    dgv_employee.DataSource = user.ToList();
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
        private void loadDataSearch(int whid)
        {
            try
            {
                var user = _userService.GetUsers(whid,txt_el_s_name.Text);
                if (user != null && user.Any())
                {
                    dgv_employee.DataSource = user.ToList();
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
        private void loadDataSearchNonAdmin(int whid)
        {
            try
            {
                var user = _userService.GetUsersNonAdmin(whid, txt_el_s_name.Text);
                if (user != null && user.Any())
                {
                    dgv_employee.DataSource = user.ToList();
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

        private void pn_setting_VisibleChanged(object sender, EventArgs e)
        {
            if (pn_setting.Visible)
            {
                txt_set_name.Text = _user.Username;
                txt_set_pw.Text = _user.Password;
                txt_set_phone.Text = _user.Phone;
                txt_set_address.Text = _user.Address;
                txt_set_wh.Text = _user.Warehouse;
                txt_set_role.Text = _user.Role;
            }else
            {
                txt_set_name.Text = string.Empty ;
                txt_set_pw.Text = string.Empty;
                txt_set_phone.Text = string.Empty;
                txt_set_address.Text = string.Empty;
                txt_set_wh.Text = string.Empty;
                txt_set_role.Text = string.Empty;
            }
        }

        private void btn_set_submit_Click(object sender, EventArgs e)
        {
            if(checkSettingChangce() == true)
            {
                try
                {
                    User user = new User();
                    user.Id = _user.Id;
                    user.Username = txt_set_name.Text;
                    user.Password = txt_set_pw.Text;
                    user.Address = txt_set_address.Text;
                    user.Warehouse = txt_set_wh.Text;
                    user.Phone = txt_set_phone.Text;
                    user.Role = txt_set_role.Text;
                    _userService.UpdateUser(user);
                    MessageBox.Show("Cập nhật thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cập nhật thất bại. Errol: " + ex);
                }
            }
        }

        private bool checkSettingChangce()
        {
            if(txt_set_name.Text == _user.Username)
            {
                return true;
            }
            if (txt_set_pw.Text == _user.Password)
            {
                return true;
            }
            if (txt_set_phone.Text == _user.Phone)
            {
                return true;
            }
            if (txt_set_address.Text == _user.Address)
            {
                return true;
            }
            return false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ShowPanel(pn_setting);
        }
    }
}
