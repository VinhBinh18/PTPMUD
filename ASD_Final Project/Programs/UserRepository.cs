using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ASD_Final_Project.Program
{
    public class UserRepository
    {
        private readonly SqlConnection _dbConnection;

        public UserRepository(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>();

            try
            {
                _dbConnection.Open();
                using (var command = new SqlCommand("SELECT U.U_ID, U.U_UserName, U.U_Address, U.U_Phone, R.Rl_Name FROM Users U JOIN Roles R ON U.Rl_ID = R.Rl_ID;", _dbConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Address = reader.GetString(2),
                                Phone = reader.GetString(3),
                                Role = reader.GetString(4),
                                Password= "********"
                            };
                            users.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                _dbConnection.Close();
            }

            return users;
        }

        public void AddUser(User user)
        {
            try
            {
                _dbConnection.Open();
                using (var command = new SqlCommand("INSERT INTO Users (U_Username,U_Password, U_Address, U_Phone, Rl_ID) VALUES (@Username ,@Password, @Address, @Phone, @RolesId)", _dbConnection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Address", user.Address);
                    command.Parameters.AddWithValue("@Phone", user.Phone);
                    command.Parameters.AddWithValue("@RolesID", GetRoleId(user.Role));
                    command.Parameters.AddWithValue("@Password", "123");

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                _dbConnection.Open();
                using (var command = new SqlCommand("UPDATE Users SET Username = @Username, Address = @Address, Phone = @Phone, RolesId = @RolesID WHERE Id = @Id", _dbConnection))
                {
                    command.Parameters.AddWithValue("@Id", user.Id);
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Address", user.Address);
                    command.Parameters.AddWithValue("@Phone", user.Phone);
                    command.Parameters.AddWithValue("@RolesID", GetRoleId(user.Role));
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                _dbConnection.Open();
                using (var command = new SqlCommand("DELETE FROM Users WHERE U_ID = @Id", _dbConnection))
                {
                    command.Parameters.AddWithValue("@Id", userId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                _dbConnection.Close();
            }
        }
        public User LoginUser(string username, string password)
        { 
            var userSigned = new User();

            try
            {
                _dbConnection.Open();
                using (var command = new SqlCommand("SELECT U.U_ID, U.U_UserName, U.U_Address, U.U_Phone, R.Rl_Name FROM Users U JOIN Roles R ON U.Rl_ID = R.Rl_ID WHERE U.U_UserName = @Username AND U.U_Password = @Password", _dbConnection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userSigned.Id = reader.GetInt32(0);
                            userSigned.Username = reader.GetString(1);
                            userSigned.Address = reader.GetString(2);
                            userSigned.Phone = reader.GetString(3);
                            userSigned.Role = reader.GetString(4);
                            return userSigned; // Trả về người dùng nếu đăng nhập thành công
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                _dbConnection.Close();
            }

            return null; // Trả về null nếu đăng nhập thất bại
        }

        public bool RegisterUser(User user, string password)
        {
            try
            {
                _dbConnection.Open();
                using (var checkUserCommand = new SqlCommand("SELECT COUNT(*) FROM Users WHERE U_Name = @Username", _dbConnection))
                {
                    checkUserCommand.Parameters.AddWithValue("@Username", user.Username);
                    int userExists = (int)checkUserCommand.ExecuteScalar();

                    if (userExists > 0)
                    {
                        MessageBox.Show("Username already exists.");
                        return false;
                    }
                }

                using (var command = new SqlCommand("INSERT INTO Users (U_Name, U_Password, U_Address, U_Phone, Rl_ID) VALUES (@Username, @Password, @Address, @Phone, @RolesID)", _dbConnection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Address", user.Address);
                    command.Parameters.AddWithValue("@Phone",  user.Phone);
                    command.Parameters.AddWithValue("@RolesID", GetRoleId("Staff")); // Đặt role mặc định là "Staff"
                    command.ExecuteNonQuery();
                    return true; // Trả về true nếu tạo tài khoản thành công
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                _dbConnection.Close();
            }

            return false; // Trả về false nếu tạo tài khoản thất bại
        }

        private int GetRoleId(string role)
        {
            if (string.IsNullOrEmpty(role))
            {
                return 3; 
            }

            switch (role)
            {
                case "Admin": return 1;
                case "Manager": return 2;
                case "Staff": return 3;
                default: throw new ArgumentException("Invalid role name");
            }
        }

    }
}
