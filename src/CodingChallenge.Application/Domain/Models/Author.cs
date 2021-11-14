using System;
using System.Collections.Generic;

namespace CodingChallenge.Application.Domain.Models
{
    public class Author : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }

        public Author()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            Books = new List<Book>();
        }
    }
}