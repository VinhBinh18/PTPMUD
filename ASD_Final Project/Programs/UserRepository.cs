using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ASD_Final_Project.Program
{
    public class UserRepository
    {
        private readonly SqlConnection _dbConnection;

        public UserRepository(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }
        
        public User GetUser(int UserID)
        {
            User user = null;

            try
            {
                _dbConnection.Open();
                using (var command = new SqlCommand("SELECT U.U_ID, U.U_UserName, U.U_Address, U.U_Phone, R.Rl_Name, W.Wh_Name  FROM Users U, Roles R, WareHouse W WHERE U.U_ID = @U_ID and U.Rl_ID = R.Rl_ID and W.Wh_ID = U.Wh_ID;", _dbConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Address = reader.GetString(2),
                                Phone = reader.GetString(3),
                                Role = reader.GetString(4),
                                Warehouse = reader.GetString(5),
                            };
                            
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

            return user;
        }

        public IEnumerable<User> GetAllUsers(int WhID)
        {
            var users = new List<User>();

            try
            {
                _dbConnection.Open();
                using (var command = new SqlCommand("SELECT U.U_ID, U.U_UserName, U.U_Address, U.U_Phone, R.Rl_Name, W.Wh_Name FROM Users U, Roles R, WareHouse W WHERE U.Wh_ID = @Wh_ID and U.Rl_ID = R.Rl_ID and W.Wh_ID = U.Wh_ID;", _dbConnection))
                {   
                    command.Parameters.AddWithValue("@Wh_ID", WhID);
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
                                Warehouse = reader.GetString(5),
                            };
                            users.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error 11: {ex.Message}");
            }
            finally
            {
                _dbConnection.Close();
            }

            return users;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>();

            try
            {
                _dbConnection.Open();
                using (var command = new SqlCommand("SELECT U.U_ID, U.U_UserName, U.U_Address, U.U_Phone, R.Rl_Name, U.U_Password, W.Wh_Name FROM Users U, WareHouse W, Roles R WHERE U.Rl_ID = R.Rl_ID and U.Wh_ID = W.Wh_ID;", _dbConnection))
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
                                Password = reader.GetString(5),
                                Warehouse = reader.GetString(6)
                            };
                            users.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message} + 1");
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
                using (var command = new SqlCommand("INSERT INTO Users (U_Username,U_Password, U_Address, U_Phone, Rl_ID, Wh_ID) VALUES (@Username ,@Password, @Address, @Phone, @RolesId, @Wh_ID)", _dbConnection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Address", user.Address);
                    command.Parameters.AddWithValue("@Phone", user.Phone);
                    command.Parameters.AddWithValue("@RolesID", GetRoleId(user.Role));
                    command.Parameters.AddWithValue("@Password", "123");
                    command.Parameters.AddWithValue("@Wh_ID", user.Warehouse);

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
                using (var command = new SqlCommand("UPDATE Users SET U_Username = @Username, U_Address = @Address, U_Phone = @Phone, Rl_ID = @RolesID , Wh_ID = @WhID WHERE U_ID = @Id", _dbConnection))
                {
                    command.Parameters.AddWithValue("@Id", user.Id);
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Address", user.Address);
                    command.Parameters.AddWithValue("@Phone", user.Phone);
                    command.Parameters.AddWithValue("@RolesID", GetRoleId( user.Role));
                    command.Parameters.AddWithValue("@WhID" , GetWareHouseID(user.Warehouse));
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error1: {ex.Message}");
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
            var (isValid, message) = CheckUser(username, password);
            if (!isValid)
            {
                MessageBox.Show(message); // Hiển thị thông báo lỗi
                return null;
            }

            var userSigned = new User();
            try
            {
                _dbConnection.Open();
                using (var command = new SqlCommand("SELECT U.U_ID, U.U_UserName, U.U_Address, U.U_Phone, R.Rl_Name, W.Wh_Name FROM Users U JOIN Roles R ON U.Rl_ID = R.Rl_ID JOIN WareHouse W ON U.Wh_ID = W.Wh_ID WHERE U.U_UserName = @Username AND U.U_Password = @Password", _dbConnection))
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
                            userSigned.Warehouse = reader.GetString(5);
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

            return null;
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



        public int CountUser (int Wh_ID)
        {
            try
            {
                _dbConnection.Open();
                using (var countUserCommand = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Wh_ID = @Wh_ID;", _dbConnection))
                {
                    countUserCommand.Parameters.AddWithValue("@Wh_ID", Wh_ID);
                    int userCount = (int)countUserCommand.ExecuteScalar();
                    return userCount;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errol: " + ex.Message );
                return 0;
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        public int CountUsers()
        {
            try
            {
                _dbConnection.Open();
                using (var countUserCommand = new SqlCommand("SELECT COUNT(*) FROM Users;", _dbConnection))
                {
                    int userCount = (int)countUserCommand.ExecuteScalar();
                    return userCount;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errol: " + ex.Message);
                return 0;
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        public (bool isValid, string message) CheckUser(string username, string password)
        {
            try
            {
                _dbConnection.Open();
                using (var command = new SqlCommand("SELECT U.U_Password FROM Users U WHERE U.U_UserName = @Username", _dbConnection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader.GetString(0); // Lấy mật khẩu từ cơ sở dữ liệu
                            if (storedPassword == password)
                            {
                                return (true, "Đăng nhập thành công");
                            }
                            else
                            {
                                return (false, "Mật khẩu không chính xác");
                            }
                        }
                    }
                }
                return (false, "Tên người dùng không tồn tại");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return (false, "Lỗi hệ thống");
            }
            finally
            {
                _dbConnection.Close();
            }
        }
    }
}
