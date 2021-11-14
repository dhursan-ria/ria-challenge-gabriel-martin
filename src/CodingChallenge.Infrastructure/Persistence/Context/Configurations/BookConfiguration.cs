using CodingChallenge.Application.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingChallenge.Infrastructure.Persistence.Context.Configurations
{
    internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();
            builder.Property(b => b.Name)
                .HasMaxLength(500)
                .IsRequired();

            builder.ToTable("Books");
        }
    }
}