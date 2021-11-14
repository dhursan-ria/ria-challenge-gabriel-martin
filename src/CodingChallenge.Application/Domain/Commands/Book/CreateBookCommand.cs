using MediatR;

namespace CodingChallenge.Application.Domain.Commands.Book
{
    public record CreateBookCommand(Models.Book Book) : IRequest<Models.Book>;
}