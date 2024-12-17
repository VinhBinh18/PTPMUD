using ASD_Final_Project.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;

namespace ASD_Final_Project.Program
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connectionString = @"Data Source=PRIN\MSSQLSERVER02;Initial Catalog=WH_MANAGEMENT;Integrated Security=True;Encrypt=False";

            var userRepository = new UserRepository(connectionString);
            var userService = new UserService(userRepository);
            Application.Run(new Form_Sign(userService)); 
        }
    }
}
// create read update delete 
