using System.Collections.Generic;
using MediatR;

namespace CodingChallenge.Application.Domain.Queries.Author
{
    public record GetAuthorListQuery() : IRequest<IEnumerable<Models.Author>>;
}