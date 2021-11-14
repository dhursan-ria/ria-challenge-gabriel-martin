using MediatR;

namespace CodingChallenge.Application.Domain.Commands.Author
{
    public record UpdateAuthorCommand(Models.Author Author) : IRequest<Models.Author>;
}