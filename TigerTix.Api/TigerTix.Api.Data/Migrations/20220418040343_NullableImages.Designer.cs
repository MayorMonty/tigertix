﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TigerTix.Api.Data.Contexts;

#nullable disable

namespace TigerTix.Api.Data.Migrations
{
    [DbContext(typeof(TigerTixContext))]
    [Migration("20220418040343_NullableImages")]
    partial class NullableImages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ShowUser", b =>
                {
                    b.Property<decimal>("ShowsId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("UsersId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("ShowsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ShowUser");
                });

            modelBuilder.Entity("TigerTix.Api.Data.Models.ContentBlock", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("ShowId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ShowId");

                    b.ToTable("ContentBlocks");
                });

            modelBuilder.Entity("TigerTix.Api.Data.Models.Show", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("numeric(20,0)");

                    b.Property<long>("Capacity")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<LocalDateTime>("End")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("EntryPrice")
                        .HasColumnType("double precision");

                    b.Property<string>("ImageHero")
                        .HasColumnType("text");

                    b.Property<string>("ImageThumbnail")
                        .HasColumnType("text");

                    b.Property<LocalDateTime>("Start")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("VenueId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("TigerTix.Api.Data.Models.ShowAssociate", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<decimal>("ShowId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("UserId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("ShowId");

                    b.HasIndex("UserId");

                    b.ToTable("Associates");
                });

            modelBuilder.Entity("TigerTix.Api.Data.Models.User", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Auth0Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Auth0Id", "Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TigerTix.Api.Data.Models.Venue", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("MaxCapacity")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("OwnerId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("ShowUser", b =>
                {
                    b.HasOne("TigerTix.Api.Data.Models.Show", null)
                        .WithMany()
                        .HasForeignKey("ShowsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TigerTix.Api.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TigerTix.Api.Data.Models.ContentBlock", b =>
                {
                    b.HasOne("TigerTix.Api.Data.Models.Show", null)
                        .WithMany("ContentBlocks")
                        .HasForeignKey("ShowId");
                });

            modelBuilder.Entity("TigerTix.Api.Data.Models.Show", b =>
                {
                    b.HasOne("TigerTix.Api.Data.Models.Venue", "Venue")
                        .WithMany("Shows")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("TigerTix.Api.Data.Models.ShowAssociate", b =>
                {
                    b.HasOne("TigerTix.Api.Data.Models.Show", "Show")
                        .WithMany()
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TigerTix.Api.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Show");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TigerTix.Api.Data.Models.Venue", b =>
                {
                    b.HasOne("TigerTix.Api.Data.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("TigerTix.Api.Data.Models.Show", b =>
                {
                    b.Navigation("ContentBlocks");
                });

            modelBuilder.Entity("TigerTix.Api.Data.Models.Venue", b =>
                {
                    b.Navigation("Shows");
                });
#pragma warning restore 612, 618
        }
    }
}
