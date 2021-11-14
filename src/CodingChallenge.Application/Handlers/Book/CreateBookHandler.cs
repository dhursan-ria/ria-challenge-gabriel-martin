using System.Threading;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Commands.Book;
using CodingChallenge.Application.Domain.Repositories;
using MediatR;

namespace CodingChallenge.Application.Handlers.Book
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, Domain.Models.Book>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookHandler(IBookRepository bookRepository) => _bookRepository = bookRepository;

        public async Task<Domain.Models.Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.Create(request.Book);

            return book;
        }
    }
}