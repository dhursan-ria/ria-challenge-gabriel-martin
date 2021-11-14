using System;
using MediatR;

namespace CodingChallenge.Application.Domain.Queries.Book
{
    public record GetBookByIdQuery(Guid BookId) : IRequest<Models.Book?>;
}