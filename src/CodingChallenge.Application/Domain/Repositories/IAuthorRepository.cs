using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Models;

namespace CodingChallenge.Application.Domain.Repositories
{
    public interface IAuthorRepository : IRepository<Author, Guid>
    {
        Task<IEnumerable<Author>> GetAuthorsMostExpensiveBooks(int year, int top = 3);
    }
}