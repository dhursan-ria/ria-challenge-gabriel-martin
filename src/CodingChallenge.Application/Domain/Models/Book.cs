using System;
using System.Collections.Generic;

namespace CodingChallenge.Application.Domain.Models
{
    public class Book : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
        public ICollection<Author> Authors { get; set; }

        public Book()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            Price = decimal.Zero;
            PublishDate = DateTime.UtcNow;
            Authors = new List<Author>();
        }
    }
}