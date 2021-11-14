using CodingChallenge.Application.Domain.Repositories;
using CodingChallenge.Infrastructure.Persistence.Context;
using CodingChallenge.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodingChallenge.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("LibraryContext"));
            });

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}