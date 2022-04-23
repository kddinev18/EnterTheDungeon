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
    public class UserAuthentication
    {
        private string Hash(string data)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString().ToUpper();
            }
        }
        public void LogIn(EnterTheDungeonDbContext dbContext, string username, string password)
        {
            List<User> users = dbContext.Users
                .Where(u => u.Username == username)
                .ToList();

            if (users.Count == 0)
                throw new ArgumentException("Your password or username is incorrect");

            foreach (User user in users)
                if(Hash(password + user.Salt.ToString()) == user.PasswordHash)
                    Console.WriteLine("Nice :)");
        }
        public void Register(EnterTheDungeonDbContext dbContext, string username, string email, string password)
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
