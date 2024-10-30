using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ASD_Final_Project.Programs
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
                using (var command = new SqlCommand("SELECT Users.UserID, Users.UserName, Users.Addresss, Users.Phone, Roles.RolesName FROM Users JOIN Roles ON Users.RolesID = Roles.RolesID;", _dbConnection))
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
                                Role = reader.GetString(4)
                            };
                            users.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
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
                using (var command = new SqlCommand("INSERT INTO Users (Username, Address, Phone, RolesID) VALUES (@Username, @Address, @Phone, @RolesId)", _dbConnection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Address", user.Address);
                    command.Parameters.AddWithValue("@Phone", user.Phone);
                    if(user.Role == "Admin")
                    {
                        command.Parameters.AddWithValue("@RolesID", 1);
                    }
                    if (user.Role == "Manager")
                    {
                        command.Parameters.AddWithValue("@RolesID", 2);
                    }
                    if (user.Role == "Staff")
                    {
                        command.Parameters.AddWithValue("@RolesID", 3);
                    }

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
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
                    if (user.Role == "Admin")
                    {
                        command.Parameters.AddWithValue("@RolesID", 1);
                    }
                    if (user.Role == "Manager")
                    {
                        command.Parameters.AddWithValue("@RolesID", 2);
                    }
                    if (user.Role == "Staff")
                    {
                        command.Parameters.AddWithValue("@RolesID", 3);
                    }
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
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
            using (var command = new SqlCommand("DELETE FROM Users WHERE Id = @Id", _dbConnection))
            {
                command.Parameters.AddWithValue("@Id", userId);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            _dbConnection.Close();
        }
        }
    }
}
