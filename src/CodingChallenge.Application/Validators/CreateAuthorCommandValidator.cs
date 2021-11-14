using CodingChallenge.Application.Domain.Commands.Author;
using FluentValidation;

namespace CodingChallenge.Application.Validators
{
    public sealed class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(a => a.Author).NotEmpty();
            RuleFor(a => a.Author.Name)
                .NotEmpty()
                .MaximumLength(250);
        }
    }
}