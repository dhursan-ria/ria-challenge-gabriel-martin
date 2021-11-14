using System.Threading;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Commands.Author;
using CodingChallenge.Application.Domain.Repositories;
using MediatR;

namespace CodingChallenge.Application.Handlers.Author
{
    public class DeleteAuthorHandler : AsyncRequestHandler<DeleteAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorHandler(IAuthorRepository authorRepository) => _authorRepository = authorRepository;
        
        protected override async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            await _authorRepository.Delete(request.AuthorId);
        }
    }
}