using System;
using MediatR;

namespace CodingChallenge.Application.Domain.Queries.Author
{
    public record GetAuthorByIdQuery(Guid AuthorId) : IRequest<Models.Author?>;
}