using System.Threading;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Queries.Author;
using CodingChallenge.Application.Domain.Repositories;
using MediatR;

namespace CodingChallenge.Application.Handlers.Author
{
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, Domain.Models.Author?>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorByIdHandler(IAuthorRepository authorRepository) => _authorRepository = authorRepository;

        public async Task<Domain.Models.Author?> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetById(request.AuthorId);

            return author;
        }
    }
}