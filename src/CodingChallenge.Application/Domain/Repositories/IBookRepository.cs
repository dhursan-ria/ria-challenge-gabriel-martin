using System;
using CodingChallenge.Application.Domain.Models;

namespace CodingChallenge.Application.Domain.Repositories
{
    public interface IBookRepository : IRepository<Book, Guid>
    {
    }
}