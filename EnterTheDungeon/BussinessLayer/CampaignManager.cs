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

            List<CharacterCampaign> characterCampaigns = new();
            int CampaignId = dbContext.Campaigns.OrderBy(c => c.Id).Last().Id;

            foreach (Character character in participatingCharacters)
            {
                if(character.Id == master.Id)
                    characterCampaigns.Add(new CharacterCampaign()
                    {
                        CampaignId = CampaignId,
                        CharacterId = character.UserId,
                        IsMaster = true
                    });
                else
                    characterCampaigns.Add(new CharacterCampaign()
                    {
                        CampaignId = CampaignId,
                        CharacterId = character.UserId,
                        IsMaster = false
                    });
            }

            dbContext.CharacterCampaigns.AddRange(characterCampaigns);

            dbContext.SaveChanges();
        }

        public static List<Character> GetCharacters(EnterTheDungeonDbContext dbContext, Campaign campaign)
        {
            return dbContext.CharacterCampaigns.Where(cc => cc.CampaignId == campaign.Id).Include(cc => cc.Character).Select(cc => cc.Character).ToList();
        }
    }
}
