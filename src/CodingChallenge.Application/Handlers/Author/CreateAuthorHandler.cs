using System.Threading;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Commands.Author;
using CodingChallenge.Application.Domain.Repositories;
using MediatR;

namespace CodingChallenge.Application.Handlers.Author
{
    public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, Domain.Models.Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateAuthorHandler(IAuthorRepository authorRepository) => _authorRepository = authorRepository;

        public async Task<Domain.Models.Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.Create(request.Author);

            return author;
        }
    }
}