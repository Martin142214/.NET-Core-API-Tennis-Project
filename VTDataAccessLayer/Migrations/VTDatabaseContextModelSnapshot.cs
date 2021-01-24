﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VTDataAccessLayer;

namespace VTDataAccessLayer.Migrations
{
    [DbContext(typeof(VTDatabaseContext))]
    partial class VTDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Bussiness_layer.Models.ManyToManyModel.PlayersTournaments", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TournamentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PlayerId", "TournamentId");

                    b.HasIndex("TournamentId");

                    b.ToTable("PlayersTournament");
                });

            modelBuilder.Entity("VTDataAccessLayer.Entities.AddedModels.Player", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthenticationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PrRoles")
                        .HasColumnType("int");

                    b.Property<int>("RankListPoints")
                        .HasColumnType("int");

                    b.Property<int>("TournamentsPlayed")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("VTDataAccessLayer.Entities.AddedModels.Tournament", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Award")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TournamentName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("TournamentName")
                        .IsUnique()
                        .HasFilter("[TournamentName] IS NOT NULL");

                    b.ToTable("Tournament");
                });

            modelBuilder.Entity("Bussiness_layer.Models.ManyToManyModel.PlayersTournaments", b =>
                {
                    b.HasOne("VTDataAccessLayer.Entities.AddedModels.Player", "Player")
                        .WithMany("PlayersTournament")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VTDataAccessLayer.Entities.AddedModels.Tournament", "Tournament")
                        .WithMany("PlayersTournament")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("VTDataAccessLayer.Entities.AddedModels.Player", b =>
                {
                    b.Navigation("PlayersTournament");
                });

            modelBuilder.Entity("VTDataAccessLayer.Entities.AddedModels.Tournament", b =>
                {
                    b.Navigation("PlayersTournament");
                });
#pragma warning restore 612, 618
        }
    }
}
