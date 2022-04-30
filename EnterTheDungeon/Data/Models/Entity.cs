using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheDungeon.Data.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int AttackType { get; set; }
        public int AfterEffect { get; set; }
    }
}
