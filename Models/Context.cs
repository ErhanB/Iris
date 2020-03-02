using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Iris.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Agent> Agents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(new Position
            {
                Id = 1,
                Name = "Goal Keeper",
            }, new Position
            {
                Id = 2,
                Name = "Defence",
            }, new Position
            {
                Id = 3,
                Name = "Midfielder",
            }, new Position
            {
                Id = 4,
                Name = "Winger",
            }, new Position
            {
                Id = 5,
                Name = "Forward",
            }
            );
        }
    }
}
