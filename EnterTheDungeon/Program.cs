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
                //UserAuthentication.Register(dbContext,"Kokicha2", "kokicha2@gmail.com", "111111");
                UserAuthentication.LogIn(dbContext, "Kokicha2", "111111");

                //CharacterManager.CreateCharacter(dbContext, "Dum Kai'sa", CharacterConstants.CharacterClass.Fighter);
                /*ItemManager.CreateItem(
                    dbContext,
                    dbContext.Characters.OrderBy(c => c.Id).First(),
                    "Healing Potion",
                    ItemConstatnts.ItemType.Potion,
                    ItemConstatnts.PotionVariant.HealingPotion,
                    0,
                    0,
                    0,
                    2);*/
                dbContext.Characters.OrderBy(c => c.Id).First().CurrentHealth -= 2;
                dbContext.SaveChanges();
                CharacterManager.Heal();
            }
        }
    }
}
