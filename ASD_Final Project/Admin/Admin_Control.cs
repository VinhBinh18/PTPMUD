﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASD_Final_Project.Admin
{
    public partial class Admin_Control : Form
    {
        public Admin_Control()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=PRIN\MSSQLSERVER02;Initial Catalog=WH_MANAGEMENT;Integrated Security=True;Encrypt=False";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from User ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void Admin_AddUser_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pn_btn_submit_Click(object sender, EventArgs e)
        {
            if(pn_txt_name == null || pn_txt_address == null || pn_txt_phone == null) 
            {
                MessageBox.Show("Please fill full infor User");
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
    }
}
