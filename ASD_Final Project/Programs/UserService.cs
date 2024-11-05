using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_Final_Project.Program
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public IEnumerable<User> GetAllUsers(int Wh_ID)
        {
            return _userRepository.GetAllUsers(Wh_ID);
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
        }
        public User LoginUser(string username, string password)
        {
            return _userRepository.LoginUser(username, password);
        }
        public int CountUsers(int Wh_ID)
        {
            return _userRepository.CountUsers(Wh_ID);
        }


    }
}
