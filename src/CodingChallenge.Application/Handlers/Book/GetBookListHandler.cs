using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Queries.Book;
using CodingChallenge.Application.Domain.Repositories;
using MediatR;

namespace CodingChallenge.Application.Handlers.Book
{
    public class GetBookListHandler : IRequestHandler<GetBookListQuery, IEnumerable<Domain.Models.Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookListHandler(IBookRepository bookRepository) => _bookRepository = bookRepository;

        public async Task<IEnumerable<Domain.Models.Book>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAll();

            return books;
        }
    }
}