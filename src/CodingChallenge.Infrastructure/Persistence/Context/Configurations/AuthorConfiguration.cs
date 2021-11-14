using System.Collections.Generic;
using CodingChallenge.Application.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingChallenge.Infrastructure.Persistence.Context.Configurations
{
    internal sealed class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();
            builder.Property(a => a.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder.HasMany(a => a.Books)
                .WithMany(b => b.Authors)
                .UsingEntity<Dictionary<string, object>>("BookAuthors",
                    j => j.HasOne<Book>()
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Author>()
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade));

            builder.ToTable("Authors");
        }
    }
}