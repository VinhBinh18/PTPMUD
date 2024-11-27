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

namespace ASD_Final_Project.Staff
{
    public partial class Staff_Control : Form
    {
        private readonly UserService _userService;
        private readonly User _admin;

        public Staff_Control(UserService userService, User Admin)
        {
            InitializeComponent();
            _userService = userService;
            _admin = Admin;
        }


    }
}
