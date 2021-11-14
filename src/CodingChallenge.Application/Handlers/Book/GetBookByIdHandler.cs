using System.Threading;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Queries.Book;
using CodingChallenge.Application.Domain.Repositories;
using MediatR;

namespace CodingChallenge.Application.Handlers.Book
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Domain.Models.Book?>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdHandler(IBookRepository bookRepository) => _bookRepository = bookRepository;

        public async Task<Domain.Models.Book?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetById(request.BookId);

            return book;
        }
    }
}