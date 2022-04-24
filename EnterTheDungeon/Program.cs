using EnterTheDungeon.BussinessLayer;
using EnterTheDungeon.Data.Models;
using System;

namespace EnterTheDungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EnterTheDungeonDbContext dbContext = new EnterTheDungeonDbContext())
            {
                UserAuthentication.Register(dbContext,"asd3", "asd3@asd", "123456");
                UserAuthentication.LogIn(dbContext, "asd", "123456");
                Console.WriteLine(UserAuthentication.GetCurrentUser());
            }
        }
    }
}
