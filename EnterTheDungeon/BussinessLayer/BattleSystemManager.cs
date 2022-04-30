using EnterTheDungeon.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheDungeon.BussinessLayer
{
    public static class EntityConstants
    {
        public static List<string> Names { get; set; }
        enum AttackType
        {
            MeleAttack = 0,
            RangeAttack = 1
        }
        enum AfterEffect
        {
            None = 0,
            Posion = 1,
            HealingAllies = 2,
            StrengthDebuff = 4,
        }
    }
    public static class BattleSystemManager
    {
        public static List<Entity> Entities { get; set; }
        public static List<Character> Characters { get; set; }
        public static void InitiateBattle(EnterTheDungeonDbContext dbContext, Campaign campaign)
        {
            Characters = GetCharacters(dbContext, campaign);
            Entities = GenerateEntities(dbContext, campaign);
        }
        public static List<Entity> GenerateEntities(EnterTheDungeonDbContext dbContext, Campaign campaign)
        {
            foreach (Character character in Characters)
            {
                Entities.Add(new Entity() 
                { 
                    Name = "Random Name"
                });
            }
            throw new Exception();
        }
        public static List<Character> GetCharacters(EnterTheDungeonDbContext dbContext, Campaign campaign)
        {
           return dbContext.CharacterCampaigns.Where(cc => cc.CampaignId == campaign.Id).Include(cc => cc.Character).Select(cc => cc.Character).ToList();
        }
    }
}
