using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Queries.Author;
using CodingChallenge.Application.Domain.Repositories;
using MediatR;

namespace CodingChallenge.Application.Handlers.Author
{
    public class GetAuthorListHandler : IRequestHandler<GetAuthorListQuery, IEnumerable<Domain.Models.Author>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorListHandler(IAuthorRepository authorRepository) => _authorRepository = authorRepository;

        public async Task<IEnumerable<Domain.Models.Author>> Handle(GetAuthorListQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetAll();

            return authors;
        }
    }
}