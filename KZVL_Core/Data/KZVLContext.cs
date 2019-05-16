using KZVL_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KZVL_Core.Data
{
    public class KZVLContext : DbContext
    {
        public KZVLContext(DbContextOptions<KZVLContext> options) : base(options)
        {
        }

        public DbSet<Divizion> Divizions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Divizion>().ToTable("Divizion");
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Role>().ToTable("Role");


        }
    }
}
