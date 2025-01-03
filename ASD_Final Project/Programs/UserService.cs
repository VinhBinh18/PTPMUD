﻿using System;
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

        public User GetUser(int UserID)
        {
            return _userRepository.GetUser(UserID);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public IEnumerable<User> GetAllUsers(int Wh_ID)
        {
            return _userRepository.GetAllUsers(Wh_ID);
        }

        public IEnumerable<User> GetUsers(int WhID, string name)
        {
            return _userRepository.GetUsers(WhID, name);
        }

        public IEnumerable<User> GetUsers(string name)
        {
            return _userRepository.GetUsers(name);
        }

        public IEnumerable<User> GetUsersNonAdmin(int WhID, string name)
        {
            return _userRepository.GetUsersNonAdmin(WhID, name);
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
        public int CountUser(int Wh_ID)
        {
            return _userRepository.CountUser(Wh_ID);
        }
        public int CountUsers()
        {
            return _userRepository.CountUsers();
        }
 
    }
}
