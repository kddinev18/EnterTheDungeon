using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheDungeon.Data.Models
{
    class EnterTheDungeonDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            { 
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EnterTheDungeon;Integrated Security=True;"); 
            }
        }
    }
}
