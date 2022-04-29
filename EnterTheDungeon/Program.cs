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

                /*CharacterManager.CreateCharacter(dbContext, "Dum Kai'sa1", CharacterConstants.CharacterClass.Mage);
                CharacterManager.CreateCharacter(dbContext, "Dum Kai'sa2", CharacterConstants.CharacterClass.Mage);
                CharacterManager.CreateCharacter(dbContext, "Dum Kai'sa3", CharacterConstants.CharacterClass.Mage);
                CharacterManager.CreateCharacter(dbContext, "Dum Kai'sa4", CharacterConstants.CharacterClass.Mage);
                CharacterManager.CreateCharacter(dbContext, "Dum Kai'sa5", CharacterConstants.CharacterClass.Mage);
                CharacterManager.CreateCharacter(dbContext, "Dum Kai'sa6", CharacterConstants.CharacterClass.Mage);*/
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
                CampaignManager.CreateCampaign(dbContext, dbContext.Characters.OrderBy(c => c.Id).First(), "alo", "",dbContext.Characters.ToArray());
            }
        }
    }
}
