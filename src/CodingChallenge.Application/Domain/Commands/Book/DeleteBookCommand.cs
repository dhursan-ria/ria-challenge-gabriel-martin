using System;
using MediatR;

namespace CodingChallenge.Application.Domain.Commands.Book
{
    public record DeleteBookCommand(Guid BookId) : IRequest;
}