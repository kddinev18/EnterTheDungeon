using EnterTheDungeon.Data.Models;
using Microsoft.EntityFrameworkCore;
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

    public static class CharacterConstants
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
        public static void CreateCharacter(EnterTheDungeonDbContext dbContext, string name, CharacterConstants.CharacterClass characterClass)
        {
            dbContext.Inventories.Add(new Inventory()
            {
                MaxWeight = CharacterConstants.InventoryMaxWeight
            });
            dbContext.SaveChanges();
            dbContext.Characters.Add(new Character() 
            { 
                UserId = UserAuthentication.GetCurrentUser(),
                Name = name,
                Class = ((int)characterClass),
                Strength = CharacterConstants.Strenght,
                Agility = CharacterConstants.Agility,
                MaxHealth = CharacterConstants.Health,
                CurrentHealth = CharacterConstants.Health,
                Armor = 0,
                Money = CharacterConstants.Money,
                InventoryId = dbContext.Inventories.OrderBy(i => i.Id).Last().Id
            });
            dbContext.SaveChanges();
        }

        public static void Heal(EnterTheDungeonDbContext dbContext, Character character)
        {
            if (character.MaxHealth == character.CurrentHealth)
                throw new UnableToDoTheAction("Can't heal your character when his health is full");

            Item healingPotions = dbContext.Items.Where(i => i.InventoryId == character.InventoryId && i.Type == 4 && i.Variant == 0).OrderBy(i => i.Id).First();

            if(healingPotions is null)
                throw new UnableToDoTheAction("Can't heal your character when you don't have potions");

            character.CurrentHealth += healingPotions.HealingAmount;
            ItemManager.DiscradItem(dbContext, healingPotions);

            if (character.MaxHealth < character.CurrentHealth)
                character.CurrentHealth = character.MaxHealth;

            dbContext.SaveChanges();
        }

        public static void EquipItem(EnterTheDungeonDbContext dbContext ,Character character, Item item)
        {
            if (item.IsEquiped == true)
                throw new UnableToDoTheAction("Can't equip already equiped item");

            Item EquippedItem = dbContext.Items
                .Where(i => i.IsEquiped == true)
                .Where(i => i.InventoryId == character.InventoryId)
                .Where(i => i.Type == item.Type && i.Variant == item.Variant)
                .First();
            EquippedItem.IsEquiped = false;

            Character desiredCharacter = dbContext.Characters.Where(c => c == character).First();

            desiredCharacter -= EquippedItem;
            desiredCharacter += item;

            dbContext.SaveChanges();
        }

        public static void UnequipItem(EnterTheDungeonDbContext dbContext, Character character, Item item)
        {
            if (item.IsEquiped == false)
                throw new UnableToDoTheAction("Can't unequip already unequiped item");

            Item EquipedItem = dbContext.Items
                .Where(i => i.IsEquiped == true)
                .Where(i => i.InventoryId == character.InventoryId)
                .Where(i => i.Type == item.Type && i.Variant == item.Variant)
                .First();
            EquipedItem.IsEquiped = false;

            Character desiredCharacter = dbContext.Characters.Where(c => c == character).First();
            desiredCharacter -= item;

            dbContext.SaveChanges();
        }

        public static List<Campaign> GetCampaigns(EnterTheDungeonDbContext dbContext, Character character)
        {
            return dbContext.CharacterCampaigns.Where(cc => cc.CharacterId == character.Id).Include(cc => cc.Campaign).Select(cc => cc.Campaign).ToList();
        }
    }
}
