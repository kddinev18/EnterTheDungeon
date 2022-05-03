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
        public enum AttackType
        {
            MeleAttack = 0,
            RangeAttack = 1,
        }
        public enum AfterEffect
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
            GenerateEntities(dbContext, campaign);
            GetCharacters(dbContext, campaign);
        }
        public static void GenerateEntities(EnterTheDungeonDbContext dbContext, Campaign campaign)
        {
            foreach (Character character in Characters)
            {
                Entities.Add(new Entity()
                {
                    CampaignId = campaign.Id,
                    Name = "Random Name",
                    Strength = character.Strength + new Random().Next(-4, 4),
                    Health = character.MaxHealth + new Random().Next(-4, 4),
                    Armor = character.Armor + new Random().Next(-4, 4),
                    AttackType = (int)Enum.GetValues(typeof(EntityConstants.AttackType)).GetValue(new Random().Next(Enum.GetValues(typeof(EntityConstants.AttackType)).Length)),
                    AfterEffect = (int)Enum.GetValues(typeof(EntityConstants.AfterEffect)).GetValue(new Random().Next(Enum.GetValues(typeof(EntityConstants.AfterEffect)).Length))
                });
            }
            dbContext.Entities.AddRange(Entities);
            dbContext.SaveChanges();
        }
        public static void GetCharacters(EnterTheDungeonDbContext dbContext, Campaign campaign)
        {
            Characters.AddRange(dbContext.CharacterCampaigns.Where(cc => cc.CampaignId == campaign.Id).Include(cc => cc.Character).Select(cc => cc.Character).ToList());
        }
        public static void DiscradEntity(EnterTheDungeonDbContext dbContext, Entity entity)
        {
            dbContext.Entities.Remove(entity);
            dbContext.SaveChanges();
        }
        public static void DiscradEntities(EnterTheDungeonDbContext dbContext, IEnumerable<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                dbContext.Entities.Remove(entity);
            }
            dbContext.SaveChanges();
        }
    }
}
