﻿// <auto-generated />
using System;
using LitExplore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LitExplore.Repository.Migrations
{
    [DbContext(typeof(LitExploreContext))]
    [Migration("20211201131349_RelationMigration")]
    partial class RelationMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AuthorPaper", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("PapersId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "PapersId");

                    b.HasIndex("PapersId");

                    b.ToTable("AuthorPaper");
                });

            modelBuilder.Entity("LitExplore.Repository.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GivenName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LitExplore.Repository.Entities.Paper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Abstract")
                        .HasMaxLength(2200)
                        .HasColumnType("nvarchar(2200)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("URL")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Papers");
                });

            modelBuilder.Entity("LitExplore.Repository.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("LitExplore.Repository.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PaperPaper", b =>
                {
                    b.Property<int>("CitedById")
                        .HasColumnType("int");

                    b.Property<int>("CitingsId")
                        .HasColumnType("int");

                    b.HasKey("CitedById", "CitingsId");

                    b.HasIndex("CitingsId");

                    b.ToTable("PaperPaper");
                });

            modelBuilder.Entity("PaperProject", b =>
                {
                    b.Property<int>("PapersId")
                        .HasColumnType("int");

                    b.Property<int>("UsedInId")
                        .HasColumnType("int");

                    b.HasKey("PapersId", "UsedInId");

                    b.HasIndex("UsedInId");

                    b.ToTable("PaperProject");
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.Property<Guid>("CollaboratorsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("HasAccessToId")
                        .HasColumnType("int");

                    b.HasKey("CollaboratorsId", "HasAccessToId");

                    b.HasIndex("HasAccessToId");

                    b.ToTable("ProjectUser");
                });

            modelBuilder.Entity("AuthorPaper", b =>
                {
                    b.HasOne("LitExplore.Repository.Entities.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LitExplore.Repository.Entities.Paper", null)
                        .WithMany()
                        .HasForeignKey("PapersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LitExplore.Repository.Entities.Project", b =>
                {
                    b.HasOne("LitExplore.Repository.Entities.User", "Owner")
                        .WithMany("IsOwnerOf")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("PaperPaper", b =>
                {
                    b.HasOne("LitExplore.Repository.Entities.Paper", null)
                        .WithMany()
                        .HasForeignKey("CitedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LitExplore.Repository.Entities.Paper", null)
                        .WithMany()
                        .HasForeignKey("CitingsId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaperProject", b =>
                {
                    b.HasOne("LitExplore.Repository.Entities.Paper", null)
                        .WithMany()
                        .HasForeignKey("PapersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LitExplore.Repository.Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("UsedInId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.HasOne("LitExplore.Repository.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("CollaboratorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LitExplore.Repository.Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("HasAccessToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LitExplore.Repository.Entities.User", b =>
                {
                    b.Navigation("IsOwnerOf");
                });
#pragma warning restore 612, 618
        }
    }
}
