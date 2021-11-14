using System;
using System.Collections.Generic;
using CodingChallenge.Application.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Infrastructure.Persistence.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryContext).Assembly);
            modelBuilder.HasDefaultSchema("Library");

            var authorIds = new[]
            {
                Guid.Parse("5469fa74-454a-11ec-81d3-0242ac130003"),
                Guid.Parse("5469fc9a-454a-11ec-81d3-0242ac130003"),
                Guid.Parse("5469fd8a-454a-11ec-81d3-0242ac130003"),
                Guid.Parse("5469fe52-454a-11ec-81d3-0242ac130003")
            };
            var bookIds = new[]
            {
                Guid.Parse("ef32bbb8-454a-11ec-81d3-0242ac130003"),
                Guid.Parse("ef32be1a-454a-11ec-81d3-0242ac130003"),
                Guid.Parse("ef32bf0a-454a-11ec-81d3-0242ac130003"),
                Guid.Parse("ef32c086-454a-11ec-81d3-0242ac130003"),
                Guid.Parse("ef32c14e-454a-11ec-81d3-0242ac130003"),
                Guid.Parse("ef32c220-454a-11ec-81d3-0242ac130003"),
                Guid.Parse("ef32c2de-454a-11ec-81d3-0242ac130003")
            };

            modelBuilder.Entity<Author>()
                .HasData(new List<Author>
                {
                    new() { Id = authorIds[0], Name = "Stephen King" },
                    new() { Id = authorIds[1], Name = "Lucy Foley" },
                    new() { Id = authorIds[2], Name = "Chris Colfer" },
                    new() { Id = authorIds[3], Name = "Brandon Dorman" }
                });
            modelBuilder.Entity<Book>()
                .HasData(new List<Book>
                {
                    new() { Id = bookIds[0], Name = "Later", Price = 29.90M, PublishDate = GetDate(2021, 3, 2) },
                    new() { Id = bookIds[1], Name = "Lisey's Story Tie-In Edition", Price = 24.90M, PublishDate = GetDate(2021, 6, 1) },
                    new() { Id = bookIds[2], Name = "Billy Summers", Price = 39.90M, PublishDate = GetDate(2021, 8, 3) },
                    new() { Id = bookIds[3], Name = "Rita Hayworth and Shawshank Redemption", Price = 19.90M, PublishDate = GetDate(2021, 9, 29) },
                    new() { Id = bookIds[4], Name = "The Guest List", Price = 29.90M, PublishDate = GetDate(2020, 1, 1) },
                    new() { Id = bookIds[5], Name = "The Hunting Party", Price = 29.90M, PublishDate = GetDate(2018, 1, 1) },
                    new() { Id = bookIds[6], Name = "An Author's Oddyssey", Price = 39.99M, PublishDate = GetDate(2021, 3, 1) }
                });
            modelBuilder.Entity("BookAuthors")
                .HasData(new List<object>
                {
                    new { AuthorId = authorIds[0], BookId = bookIds[0] },
                    new { AuthorId = authorIds[0], BookId = bookIds[1] },
                    new { AuthorId = authorIds[0], BookId = bookIds[2] },
                    new { AuthorId = authorIds[0], BookId = bookIds[3] },
                    new { AuthorId = authorIds[1], BookId = bookIds[4] },
                    new { AuthorId = authorIds[1], BookId = bookIds[5] },
                    new { AuthorId = authorIds[2], BookId = bookIds[6] },
                    new { AuthorId = authorIds[3], BookId = bookIds[6] }
                });
        }

        private static DateTime GetDate(int year, int month, int day) => new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc);
    }
}