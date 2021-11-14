using System.Threading;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Commands.Book;
using CodingChallenge.Application.Domain.Repositories;
using MediatR;

namespace CodingChallenge.Application.Handlers.Book
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, Domain.Models.Book>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookHandler(IBookRepository bookRepository) => _bookRepository = bookRepository;

        public async Task<Domain.Models.Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.Update(request.Book);

            return book;
        }
    }
}