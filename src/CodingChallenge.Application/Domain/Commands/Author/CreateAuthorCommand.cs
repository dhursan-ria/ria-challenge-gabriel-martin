using MediatR;

namespace CodingChallenge.Application.Domain.Commands.Author
{
    public record CreateAuthorCommand(Models.Author Author) : IRequest<Models.Author>;
}