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
    internal class BookRepository : Repository<Book, Guid>, IBookRepository
    {
        public BookRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        public override async Task<Book?> GetById(Guid entityId)
        {
            var book = await Context.Set<Book>()
                .AsNoTracking()
                .Include(b => b.Authors)
                .SingleOrDefaultAsync(b => b.Id == entityId);

            return book;
        }

        public override async Task<IEnumerable<Book>> GetAll()
        {
            var books = await Context.Set<Book>()
                .AsNoTracking()
                .Include(b => b.Authors.OrderBy(a => a.Name))
                .OrderBy(b => b.Name)
                .ToListAsync();

            return books;
        }
    }
}