using EnterTheDungeon.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheDungeon.BussinessLayer
{
    public static class UserAuthentication
    {
        private static int? _logedUserId;
        public static int GetCurrentUser()
        {
            if (_logedUserId.HasValue)
                return _logedUserId.Value;
            else
                throw new NotLoggedException("You first have to be logged");
        }
        private static string Hash(string data)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(data))).ToUpper().Replace("-","");
        }
        public static void LogIn(EnterTheDungeonDbContext dbContext, string username, string password)
        {
            List<User> users = dbContext.Users
                .Where(u => u.Username == username)
                .ToList();

            if (users.Count == 0)
                throw new ArgumentException("Your password or username is incorrect");

            foreach (User user in users)
                if (Hash(password + user.Salt.ToString()) == user.PasswordHash)
                    _logedUserId = user.Id;
        }
        public static void Register(EnterTheDungeonDbContext dbContext, string username, string email, string password)
        {
            int salt = new Random().Next(10000, 99999);
            string hashPassword = Hash(password + salt.ToString());

            foreach (User user in dbContext.Users)
                 if(user.Email == email || user.Username == username)
                     throw new ArgumentException("There is already a user with that email or username");

            dbContext.Users.Add(new User()
            {
                Username = username,
                PasswordHash = hashPassword,
                Email = email,
                Salt = salt
            });

            dbContext.SaveChanges();
        }
    }
}
