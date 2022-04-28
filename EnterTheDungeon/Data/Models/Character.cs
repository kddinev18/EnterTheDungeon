using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheDungeon.Data.Models
{
    public class Character
    {
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
        public int Strenght { get; set; }

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
