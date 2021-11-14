using System.Threading;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Commands.Book;
using CodingChallenge.Application.Domain.Repositories;
using MediatR;

namespace CodingChallenge.Application.Handlers.Book
{
    public class DeleteBookHandler : AsyncRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookHandler(IBookRepository bookRepository) => _bookRepository = bookRepository;

        protected override async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.Delete(request.BookId);
        }
    }
}