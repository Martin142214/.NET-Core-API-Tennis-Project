using Bussiness_layer.Models.ManyToManyModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VTDataAccessLayer.Entities.AddedModels;

namespace VTDataAccessLayer
{
    public class VTDatabaseContext : DbContext
    {
        public DbSet<Player> Player { get; set; }
        public DbSet<Tournament> Tournament { get; set; }
        public DbSet<PlayersTournaments> PlayersTournament { get; set; }

       

        public VTDatabaseContext(DbContextOptions<VTDatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayersTournaments>()
                .HasKey(k => new { k.PlayerId, k.TournamentId });

            modelBuilder.Entity<Player>()
                .HasIndex(i => i.Name)
                .IsUnique();

            modelBuilder.Entity<Tournament>()
                .HasIndex(i => i.TournamentName)
                .IsUnique();

            modelBuilder.Entity<PlayersTournaments>()
                .HasOne(t => t.Tournament)
                .WithMany(pt => pt.PlayersTournament)
                .HasForeignKey(ti => ti.TournamentId);

            modelBuilder.Entity<PlayersTournaments>()
                .HasOne(p => p.Player)
                .WithMany(pt => pt.PlayersTournament)
                .HasForeignKey(pi => pi.PlayerId);


                
                
        }

    }
}
