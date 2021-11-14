using System.Collections.Generic;
using MediatR;

namespace CodingChallenge.Application.Domain.Queries.Author
{
    public record GetAuthorTopExpensiveBookListQuery(int Year, int Top = 3) : IRequest<IEnumerable<Models.Author>>;
}