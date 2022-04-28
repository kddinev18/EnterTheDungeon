using EnterTheDungeon.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheDungeon.BussinessLayer
{
    public static class ItemConstatnts
    {
        public enum ItemType
        {
            Armor = 0,
            Weapon = 1,
            Shield = 2,
            Potion = 4,
        }
        public enum ArmorVariant
        {
            Helmet = 0,
            ChestPlate = 2,
            Leggings = 4,
            Boots = 8,
        }
        public enum ShieldVariant
        {
            HeavyShield = 0,
            LightShield = 1,
        }
        public enum PotionVariant
        {
            HealingPotion = 0,
            StrenghtPotion = 1,
            PoisonPotion = 2,
            SpeedPotion = 4,
        }
        public enum WeaponVariant
        {
            Sword = 0,
            TwoHandedSword = 1,
            Axe = 2,
            TwoHandedAxe = 4,
            Staff = 8,
            TwoHandedStaff = 16,
            Bow = 32,
        }
    }

    public static class ItemManager
    {
        public static void CreateItem(EnterTheDungeonDbContext dbContext, Character character, string name, ItemConstatnts.ItemType itemType, ItemConstatnts.PotionVariant potionVariant,int strength, int constitution, int agility, int healAmount)
        {
            dbContext.Items.Add(new Item() {
                InventoryId = character.InventoryId,
                Name = name,
                Type = (int)itemType,
                Variant = (int)potionVariant,
                Strength = strength,
                Health = constitution,
                Agility = agility,
                HealAmount = healAmount,
                IsEquiped = false,
            });;
            dbContext.SaveChanges();
        }

        public static void CreateItem(EnterTheDungeonDbContext dbContext, Character character, string name, ItemConstatnts.ItemType itemType, ItemConstatnts.ShieldVariant shieldVariant, int strength, int constitution, int agility, int healAmount)
        {
            dbContext.Items.Add(new Item()
            {
                InventoryId = character.InventoryId,
                Name = name,
                Type = (int)itemType,
                Variant = (int)shieldVariant,
                Strength = strength,
                Health = constitution,
                Agility = agility,
                HealAmount = healAmount,
                IsEquiped = false
            }); ;
            dbContext.SaveChanges();
        }

        public static void CreateItem(EnterTheDungeonDbContext dbContext, Character character, string name, ItemConstatnts.ItemType itemType, ItemConstatnts.WeaponVariant weaponVariant, int strength, int constitution, int agility, int healAmount)
        {
            dbContext.Items.Add(new Item()
            {
                InventoryId = character.InventoryId,
                Name = name,
                Type = (int)itemType,
                Variant = (int)weaponVariant,
                Strength = strength,
                Health = constitution,
                Agility = agility,
                HealAmount = healAmount,
                IsEquiped = false
            }); ;
            dbContext.SaveChanges();
        }

        public static void CreateItem(EnterTheDungeonDbContext dbContext, Character character, string name, ItemConstatnts.ArmorVariant armorVariant, ItemConstatnts.WeaponVariant weaponVariant, int strength, int constitution, int agility, int healAmount)
        {
            dbContext.Items.Add(new Item()
            {
                InventoryId = character.InventoryId,
                Name = name,
                Type = (int)armorVariant,
                Variant = (int)weaponVariant,
                Strength = strength,
                Health = constitution,
                Agility = agility,
                HealAmount = healAmount,
                IsEquiped = false
            }); ;
            dbContext.SaveChanges();
        }
    }
}
