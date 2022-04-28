using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheDungeon.Data.Models
{
    public class Character
    {
        public static Character operator -(Character character, Item item)
        {
            character.Agility -= item.Agility;
            character.MaxHealth -= item.Health;
            character.Strength -= item.Strength;
            character.Armor -= item.Armor;

            return character;
        }
        public static Character operator +(Character character, Item item)
        {
            character.Agility += item.Agility;
            character.MaxHealth += item.Health;
            character.Strength += item.Strength;
            character.Armor += item.Armor;

            return character;
        }
        public int Id { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public Inventory Inventory { get; set; }
        public int InventoryId { get; set; }

        public ICollection<CharacterCampaign> CharacterCampaigns { get; set; }

        [MaxLength(128)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int Class { get; set; }

        [Required]
        public int Strength { get; set; }

        [Required]
        public int MaxHealth { get; set; }

        [Required]
        public int CurrentHealth { get; set; }

        [Required]
        public int Armor { get; set; }

        [Required]
        public int Agility { get; set; }

        [Required]
        public int Money { get; set; }
    }
}
