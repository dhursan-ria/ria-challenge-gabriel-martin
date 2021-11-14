using System.Collections.Generic;
using MediatR;

namespace CodingChallenge.Application.Domain.Queries.Book
{
    public record GetBookListQuery() : IRequest<IEnumerable<Models.Book>>;
}