using EnterTheDungeon.Data.Models;
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
        public void LogIn()
        {
        }
        public void Register(EnterTheDungeonDbContext dbContext, string username, string password, string email)
        {
            int salt = new Random().Next(0, 10000);
            byte[] hashValues = SHA256.Create().ComputeHash(new UTF8Encoding().GetBytes(password + salt.ToString()));
            string hashPassword = Encoding.UTF8.GetString(hashValues, 0, hashValues.Length);

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
