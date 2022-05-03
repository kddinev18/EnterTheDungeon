using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheDungeon.Data.Models
{
    public class Attack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Effect { get; set; }
        public int Damage { get; set; }
        public int DamgeBoost { get; set; }
        public int Healing { get; set; }
        public int DefenceBoost { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
