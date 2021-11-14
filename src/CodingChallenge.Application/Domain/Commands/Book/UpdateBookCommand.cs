using MediatR;

namespace CodingChallenge.Application.Domain.Commands.Book
{
    public record UpdateBookCommand(Models.Book Book) : IRequest<Models.Book>;
}