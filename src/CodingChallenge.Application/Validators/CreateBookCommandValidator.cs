using CodingChallenge.Application.Domain.Commands.Book;
using FluentValidation;

namespace CodingChallenge.Application.Validators
{
    public sealed class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(b => b.Book).NotNull();
            RuleFor(b => b.Book.Name)
                .NotEmpty()
                .MaximumLength(500);
        }
    }
}