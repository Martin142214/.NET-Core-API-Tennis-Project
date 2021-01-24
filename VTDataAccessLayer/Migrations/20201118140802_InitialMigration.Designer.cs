﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VTDataAccessLayer;

namespace VTDataAccessLayer.Migrations
{
    [DbContext(typeof(VTDatabaseContext))]
    [Migration("20201118140802_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

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

            modelBuilder.Entity("VTDataAccessLayer.Entities.AddedModels.Players", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("AuthenticationCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RankListPoints")
                        .HasColumnType("int");

                    b.Property<int>("TournamentsPlayed")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AuthenticationCode")
                        .IsUnique()
                        .HasFilter("[AuthenticationCode] IS NOT NULL");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("VTDataAccessLayer.Entities.AddedModels.Tournaments", b =>
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
                    b.HasOne("VTDataAccessLayer.Entities.AddedModels.Players", "Player")
                        .WithMany("PlayersTournament")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VTDataAccessLayer.Entities.AddedModels.Tournaments", "Tournament")
                        .WithMany("PlayersTournament")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("VTDataAccessLayer.Entities.AddedModels.Players", b =>
                {
                    b.Navigation("PlayersTournament");
                });

            modelBuilder.Entity("VTDataAccessLayer.Entities.AddedModels.Tournaments", b =>
                {
                    b.Navigation("PlayersTournament");
                });
#pragma warning restore 612, 618
        }
    }
}