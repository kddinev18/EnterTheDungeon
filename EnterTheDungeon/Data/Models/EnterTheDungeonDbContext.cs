using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheDungeon.Data.Models
{
    public class EnterTheDungeonDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CharacterCampaign> CharacterCampaigns { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            { 
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EnterTheDungeon;Integrated Security=True;"); 
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CharacterCampaign>().HasKey(t => new { t.CampaignId, t.CharacterId });
        }

    }
}
