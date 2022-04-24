using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheDungeon.Data.Models
{
    public class Campain
    {
        public int Id { get; set; }

        public Character Character { get; set; }
        public int CharacterId { get; set; }

        public Character Character1 { get; set; }
        public int Character1Id { get; set; }

        public Character Character2 { get; set; }
        public int Character2Id { get; set; }

        public Character Character3 { get; set; }
        public int Character3Id { get; set; }
    }
}
