using EnterTheDungeon.BussinessLayer;
using EnterTheDungeon.Data.Models;
using System;
using System.Linq;

namespace EnterTheDungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EnterTheDungeonDbContext dbContext = new EnterTheDungeonDbContext())
            {
                //UserAuthentication.Register(dbContext,"asd3", "asd3@asd", "123456");
                //User user = dbContext.Users.First();
                //user.Username = "asd";
                //dbContext.SaveChanges();
                //UserAuthentication.LogIn(dbContext, "asd", "123456");
                //CharacterManager.CreateCharacter(dbContext,"milko",CharacterConstrants.CharacterClass.Fighter);
            }
        }
    }
}
