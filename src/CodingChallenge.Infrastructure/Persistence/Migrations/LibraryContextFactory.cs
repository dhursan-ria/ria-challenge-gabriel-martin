using CodingChallenge.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CodingChallenge.Infrastructure.Persistence.Migrations
{
    public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LibraryContext>();
            builder.UseNpgsql("Server=localhost;Port=5432;Database=Library;User Id=postgres;Password=mypass;",
                options =>
                {
                    options.MigrationsAssembly(typeof(LibraryContextFactory).Assembly.FullName);
                });

            return new LibraryContext(builder.Options);
        }
    }
}