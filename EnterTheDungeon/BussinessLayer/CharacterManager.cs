using EnterTheDungeon.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheDungeon.BussinessLayer
{
    public class NotLoggedException : Exception
    {
        public NotLoggedException() : base() { }
        public NotLoggedException(string message) : base(message) { }
        public NotLoggedException(string message, Exception inner) : base(message, inner) { }
        protected NotLoggedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    public static class CharacterConstrants
    {
        public static int InventoryMaxWeight { get; } = 10;
        public static int Strenght { get; } = 10;
        public static int Agility { get; } = 10;
        public static int Constitution { get; } = 10;
        public static int Money { get; } = 10;
        public enum CharacterClass
        {
            Fighter = 0,
            Mage = 1,
            Ranger = 2
        }
    }
    public static class CharacterManager
    {
        public static void CreateCharacter(EnterTheDungeonDbContext dbContext, string name, CharacterConstrants.CharacterClass characterClass)
        {
            dbContext.Inventories.Add(new Inventory()
            {
                MaxWeight = CharacterConstrants.InventoryMaxWeight
            });
            dbContext.SaveChanges();
            dbContext.Characters.Add(new Character() 
            { 
                UserId = UserAuthentication.GetCurrentUser(),
                Name = name,
                Class = ((int)characterClass),
                Strenght = CharacterConstrants.Strenght,
                Agility = CharacterConstrants.Agility,
                Constitution = CharacterConstrants.Constitution,
                Money = CharacterConstrants.Money,
                InventoryId = dbContext.Inventories.Last().Id
            });
            dbContext.SaveChanges();
        }

        public static void Heal(EnterTheDungeonDbContext dbContext)
        {
             
        }
    }
}
