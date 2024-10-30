using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
                using (var command = new SqlCommand("SELECT Id, Username, Email FROM Users", _dbConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Email = reader.GetString(2)
                                // Chưa bao gồm Password vì lý do bảo mật
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
                using (var command = new SqlCommand("INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password)", _dbConnection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password); // Chưa mã hóa

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
                using (var command = new SqlCommand("UPDATE Users SET Username = @Username, Email = @Email, Password = @Password WHERE Id = @Id", _dbConnection))
                {
                    command.Parameters.AddWithValue("@Id", user.Id);
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password); // Chưa mã hóa

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
