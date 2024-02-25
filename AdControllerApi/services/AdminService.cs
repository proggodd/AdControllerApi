using System;
using System.Collections.Generic;
using System.Linq;
using MyAdsApi.Data;
using MyAdsApi.Models;

namespace MyAdsApi.Services
{
    public class AdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int userId) => _context.Users.Find(userId);

        public void UpdateUser(User updatedUser)
        {
            var existingUser = _context.Users.Find(updatedUser.Id);
            if (existingUser != null)
            {
                existingUser.Username = updatedUser.Username;
                existingUser.Email = updatedUser.Email;
                existingUser.Password = updatedUser.Password;
                existingUser.Coins = updatedUser.Coins;

                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"User with ID {updatedUser.Id} not found.");
            }
        }

        public void AddUser(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var userToRemove = _context.Users.Find(userId);
            if (userToRemove != null)
            {
                _context.Users.Remove(userToRemove);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"User with ID {userId} not found.");
            }
        }

        internal object GetDashboardData()
        {
            throw new NotImplementedException();
        }

        internal void UpdateAdSettings(AdSettingsUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        // Other methods related to admin operations can be added here
    }
}
