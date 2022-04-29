using EnterTheDungeon.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheDungeon.BussinessLayer
{
    public static class CampaignManager
    { 
        public static void CreateCampaign(EnterTheDungeonDbContext dbContext, Character master, string name, string desciption = "", params Character[] participatingCharacters)
        {
            dbContext.Campaigns.Add(new Campaign()
            {
                Name = name,
                Description = desciption,
            });
            dbContext.SaveChanges();

            foreach (Character character in participatingCharacters)
            {
                dbContext.CharacterCampaigns.Add(new CharacterCampaign() 
                {
                    CampaignId = dbContext.Campaigns.Last().Id,
                    CharacterId = character.UserId,
                });
            }
            dbContext.CharacterCampaigns.Add(new CharacterCampaign()
            {
                CampaignId = dbContext.Campaigns.Last().Id,
                CharacterId = master.UserId,
            });

            dbContext.SaveChanges();
        }

        public static List<Character> GetCharacters(EnterTheDungeonDbContext dbContext, Campaign campaign)
        {
            return dbContext.CharacterCampaigns.Where(cc => cc.CampaignId == campaign.Id).Include(cc => cc.Character).Select(cc => cc.Character).ToList();
        }
    }
}
