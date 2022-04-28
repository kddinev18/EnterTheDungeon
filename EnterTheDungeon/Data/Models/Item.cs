using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheDungeon.Data.Models
{
    public class Item
    {
        public int Id { get; set; }

        public Inventory Inventory { get; set; }
        public int InventoryId { get; set; }

        [MaxLength(128)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int Type { get; set; }
        [Required]
        public int Variant { get; set; }

        public int Strength { get; set; }

        public int Constitution { get; set; }
        public int Agility { get; set; }
        public int HealAmount { get; set; }
        public bool IsEquiped { get; set; }
    }
}
