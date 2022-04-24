using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheDungeon.Data.Models
{
    public class CharacterCampaign
    {
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
    }
}
