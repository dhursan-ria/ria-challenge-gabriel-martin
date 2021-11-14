﻿// <auto-generated />
using System;
using CodingChallenge.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CodingChallenge.Infrastructure.Persistence.Migrations.Schema
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Library")
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookAuthors", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthors", "Library");

                    b.HasData(
                        new
                        {
                            AuthorId = new Guid("5469fa74-454a-11ec-81d3-0242ac130003"),
                            BookId = new Guid("ef32bbb8-454a-11ec-81d3-0242ac130003")
                        },
                        new
                        {
                            AuthorId = new Guid("5469fa74-454a-11ec-81d3-0242ac130003"),
                            BookId = new Guid("ef32be1a-454a-11ec-81d3-0242ac130003")
                        },
                        new
                        {
                            AuthorId = new Guid("5469fa74-454a-11ec-81d3-0242ac130003"),
                            BookId = new Guid("ef32bf0a-454a-11ec-81d3-0242ac130003")
                        },
                        new
                        {
                            AuthorId = new Guid("5469fa74-454a-11ec-81d3-0242ac130003"),
                            BookId = new Guid("ef32c086-454a-11ec-81d3-0242ac130003")
                        },
                        new
                        {
                            AuthorId = new Guid("5469fc9a-454a-11ec-81d3-0242ac130003"),
                            BookId = new Guid("ef32c14e-454a-11ec-81d3-0242ac130003")
                        },
                        new
                        {
                            AuthorId = new Guid("5469fc9a-454a-11ec-81d3-0242ac130003"),
                            BookId = new Guid("ef32c220-454a-11ec-81d3-0242ac130003")
                        },
                        new
                        {
                            AuthorId = new Guid("5469fd8a-454a-11ec-81d3-0242ac130003"),
                            BookId = new Guid("ef32c2de-454a-11ec-81d3-0242ac130003")
                        },
                        new
                        {
                            AuthorId = new Guid("5469fe52-454a-11ec-81d3-0242ac130003"),
                            BookId = new Guid("ef32c2de-454a-11ec-81d3-0242ac130003")
                        });
                });

            modelBuilder.Entity("CodingChallenge.Application.Domain.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("Authors", "Library");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5469fa74-454a-11ec-81d3-0242ac130003"),
                            Name = "Stephen King"
                        },
                        new
                        {
                            Id = new Guid("5469fc9a-454a-11ec-81d3-0242ac130003"),
                            Name = "Lucy Foley"
                        },
                        new
                        {
                            Id = new Guid("5469fd8a-454a-11ec-81d3-0242ac130003"),
                            Name = "Chris Colfer"
                        },
                        new
                        {
                            Id = new Guid("5469fe52-454a-11ec-81d3-0242ac130003"),
                            Name = "Brandon Dorman"
                        });
                });

            modelBuilder.Entity("CodingChallenge.Application.Domain.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Books", "Library");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ef32bbb8-454a-11ec-81d3-0242ac130003"),
                            Name = "Later",
                            Price = 29.90m,
                            PublishDate = new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("ef32be1a-454a-11ec-81d3-0242ac130003"),
                            Name = "Lisey's Story Tie-In Edition",
                            Price = 24.90m,
                            PublishDate = new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("ef32bf0a-454a-11ec-81d3-0242ac130003"),
                            Name = "Billy Summers",
                            Price = 39.90m,
                            PublishDate = new DateTime(2021, 8, 3, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("ef32c086-454a-11ec-81d3-0242ac130003"),
                            Name = "Rita Hayworth and Shawshank Redemption",
                            Price = 19.90m,
                            PublishDate = new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("ef32c14e-454a-11ec-81d3-0242ac130003"),
                            Name = "The Guest List",
                            Price = 29.90m,
                            PublishDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("ef32c220-454a-11ec-81d3-0242ac130003"),
                            Name = "The Hunting Party",
                            Price = 29.90m,
                            PublishDate = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("ef32c2de-454a-11ec-81d3-0242ac130003"),
                            Name = "An Author's Oddyssey",
                            Price = 39.99m,
                            PublishDate = new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("BookAuthors", b =>
                {
                    b.HasOne("CodingChallenge.Application.Domain.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodingChallenge.Application.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}