using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Models;
using CodingChallenge.Application.Domain.Repositories;
using CodingChallenge.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Infrastructure.Persistence.Repositories
{
    internal class AuthorRepository : Repository<Author, Guid>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        public override async Task<Author?> GetById(Guid entityId)
        {
            var author = await Context.Set<Author>()
                .AsNoTracking()
                .Include(a => a.Books)
                .SingleOrDefaultAsync(a => a.Id == entityId);

            return author;
        }

        public override async Task<IEnumerable<Author>> GetAll()
        {
            var authors = await Context.Set<Author>()
                .AsNoTracking()
                .Include(a => a.Books.OrderBy(b => b.Name))
                .OrderBy(a => a.Name)
                .ToListAsync();

            return authors;
        }
        
        
        public async Task<IEnumerable<Author>> GetAuthorsMostExpensiveBooks(int year, int top = 3)
        {
            var authors = await Context.Set<Author>()
                .AsNoTracking()
                .Include(a => a.Books.Where(b => b.PublishDate.Year == year).OrderByDescending(b => b.Price).Take(top))
                .ToListAsync();

            return authors.Where(a => a.Books.Any());
        }
    }
}