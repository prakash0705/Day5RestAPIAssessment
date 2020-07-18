﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieReview.Models;

namespace MovieReview.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    partial class MovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieReview.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LanguageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("MovieReview.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("languageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("languageId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieReview.Models.Review", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ReviewName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("moviesId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("moviesId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MovieReview.Models.Movie", b =>
                {
                    b.HasOne("MovieReview.Models.Language", "languages")
                        .WithMany("movie")
                        .HasForeignKey("languageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieReview.Models.Review", b =>
                {
                    b.HasOne("MovieReview.Models.Movie", "movies")
                        .WithMany()
                        .HasForeignKey("moviesId");
                });
#pragma warning restore 612, 618
        }
    }
}