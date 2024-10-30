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
using ASD_Final_Project.Programs;

namespace ASD_Final_Project.Admin
{
    public partial class Admin_Control : Form
    {
        private UserRepository _userRepository;
      /*  SqlConnection connection;
        SqlCommand command;*/
        string str = @"Data Source=DESKTOP-PGRLH9O;Initial Catalog=WH_MANAGEMENT;Integrated Security=True;Encrypt=False";
        /*SqlDataAdapter adapter = new SqlDataAdapter();*/
        DataTable table = new DataTable();

        public Admin_Control()
        {
            InitializeComponent();
            _userRepository = new UserRepository(str);
        }


        void loaddata()
        {
            /*command = connection.CreateCommand();
            //command.CommandText = "SELECT Users.UserID, Users.UserName, Users.Addresss, Users.Phone, Roles.RolesName FROM Users JOIN Roles ON Users.RolesID = Roles.RolesID; ";
            adapter.SelectCommand = command;
            adapter.Fill(table);
            table.Clear();
            dataGridView1.DataSource = table;*/
            try
            {
                var user = _userRepository.GetAllUsers();
                dataGridView1.DataSource = user.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            

        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
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
                _userRepository.AddUser(U);
            }
            
            /* command = connection.CreateCommand();
            command.CommandText = "insert into User values('" + txt_name.Text + "','" + txt_phone.Text + "')";
            command.ExecuteNonQuery();*/
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            pn.Visible = true;
            pn.Dock = DockStyle.Fill;
        }

        private void Admin_Control_Load(object sender, EventArgs e)
        {
            
            
            loaddata();
        }
    }
}
