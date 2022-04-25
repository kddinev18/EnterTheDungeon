using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheDungeon.Data.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();

        [Required]
        public int MaxWeight { get; set; }
    }
}
