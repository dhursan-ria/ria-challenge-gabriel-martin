using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Models;

namespace CodingChallenge.Application.Domain.Repositories
{
    public interface IRepository<T1, in T2> where T1 : IEntity<T2> where T2 : IComparable
    {
        Task<T1?> GetById(T2 entityId);
        Task<IEnumerable<T1>> GetAll();
        Task<T1> Create(T1 entity);
        Task<T1> Update(T1 entity);
        Task Delete(T2 entityId);
    }
}