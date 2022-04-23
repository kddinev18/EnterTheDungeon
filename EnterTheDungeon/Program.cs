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
                UserAuthentication userAuthentication = new UserAuthentication();
                //userAuthentication.Register(dbContext,"asd", "asd@asd", "123456");
                userAuthentication.LogIn(dbContext, "asd", "123456");
            }
        }
    }
}
