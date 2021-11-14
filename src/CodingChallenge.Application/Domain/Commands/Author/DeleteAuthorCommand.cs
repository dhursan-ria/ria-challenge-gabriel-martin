using System;
using MediatR;

namespace CodingChallenge.Application.Domain.Commands.Author
{
    public record DeleteAuthorCommand(Guid AuthorId) : IRequest;
}