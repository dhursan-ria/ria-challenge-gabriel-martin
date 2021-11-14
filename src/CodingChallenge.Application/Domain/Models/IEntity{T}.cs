using System;

namespace CodingChallenge.Application.Domain.Models
{
    public interface IEntity<T> where T : IComparable
    {
        Guid Id { get; set; }
    }
}