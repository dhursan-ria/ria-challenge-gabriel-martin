using System.Threading;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Commands.Author;
using CodingChallenge.Application.Domain.Repositories;
using MediatR;

namespace CodingChallenge.Application.Handlers.Author
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, Domain.Models.Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public UpdateAuthorHandler(IAuthorRepository authorRepository) => _authorRepository = authorRepository;

        public async Task<Domain.Models.Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.Update(request.Author);

            return author;
        }
    }
}