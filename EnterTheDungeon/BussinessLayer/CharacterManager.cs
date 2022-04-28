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

    public class UnableToDoTheAction : Exception
    {
        public UnableToDoTheAction() : base() { }
        public UnableToDoTheAction(string message) : base(message) { }
        public UnableToDoTheAction(string message, Exception inner) : base(message, inner) { }
        protected UnableToDoTheAction(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public static class CharacterConstrants
    {
        public static int InventoryMaxWeight { get; } = 10;
        public static int Strenght { get; } = 10;
        public static int Agility { get; } = 10;
        public static int Health { get; } = 10;
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
                MaxHealth = CharacterConstrants.Health,
                CurrentHealth = CharacterConstrants.Health,
                Armor = 0,
                Money = CharacterConstrants.Money,
                InventoryId = dbContext.Inventories.Last().Id
            });
            dbContext.SaveChanges();
        }

        public static void Heal(EnterTheDungeonDbContext dbContext, Character character)
        {
            if (character.MaxHealth == character.CurrentHealth)
                throw new UnableToDoTheAction("Can't heal your character when his health is full");

            List<Item> healingPotions = dbContext.Items.Where(i => i.InventoryId == character.InventoryId && i.Type == 4 && i.Variant == 0).ToList();

            if(healingPotions.Count == 0)
                throw new UnableToDoTheAction("Can't heal your character when you don't have potions");

            character.CurrentHealth += healingPotions.First().HealAmount;

            if (character.MaxHealth < character.CurrentHealth)
                character.CurrentHealth = character.MaxHealth;
        }

        public static void EquipItem(EnterTheDungeonDbContext dbContext ,Character character, Item item)
        {
            if (item.IsEquiped == true)
                throw new UnableToDoTheAction("Can't equip already equiped item");

            
        } 
    }
}
