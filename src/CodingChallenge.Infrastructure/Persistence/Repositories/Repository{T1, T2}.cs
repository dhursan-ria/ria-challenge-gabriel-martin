using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Models;
using CodingChallenge.Application.Domain.Repositories;
using CodingChallenge.Infrastructure.Persistence.Context;

namespace CodingChallenge.Infrastructure.Persistence.Repositories
{
    public abstract class Repository<T1, T2> : IRepository<T1, T2> where T1 : class, IEntity<T2> where T2 : IComparable
    {
        protected readonly LibraryContext Context;

        protected Repository(LibraryContext libraryContext) => Context = libraryContext;

        public abstract Task<T1?> GetById(T2 entityId);

        public abstract Task<IEnumerable<T1>> GetAll();

        public async Task<T1> Create(T1 entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<T1> Update(T1 entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(T2 entityId)
        {
            var entity = await Context.FindAsync<T1>(entityId);
            if (entity is not null)
            {
                Context.Remove(entity);
                await Context.SaveChangesAsync();
            }
        }
    }
}