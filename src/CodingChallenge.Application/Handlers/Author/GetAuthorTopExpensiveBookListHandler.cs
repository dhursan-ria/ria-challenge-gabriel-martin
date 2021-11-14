using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Queries.Author;
using CodingChallenge.Application.Domain.Repositories;
using MediatR;

namespace CodingChallenge.Application.Handlers.Author
{
    public class GetAuthorTopExpensiveBookListHandler : IRequestHandler<GetAuthorTopExpensiveBookListQuery, IEnumerable<Domain.Models.Author>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorTopExpensiveBookListHandler(IAuthorRepository authorRepository) => _authorRepository = authorRepository;

        public async Task<IEnumerable<Domain.Models.Author>> Handle(GetAuthorTopExpensiveBookListQuery request, CancellationToken cancellationToken)
        {
            var books = await _authorRepository.GetAuthorsMostExpensiveBooks(request.Year, request.Top);

            return books;
        }
    }
}