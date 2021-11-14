using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace CodingChallenge.Web.Middlewares
{
    public class ValidationBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest: class, IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);
            var validationTasks = _validators.Select(v => v.ValidateAsync(context));
            await Task.WhenAll(validationTasks);

            var errors = validationTasks
                .Select(vt => vt.Result)
                .SelectMany(v => v.Errors)
                .Where(v => v is not null)
                .ToList();

            if (errors.Any())
            {
                throw new ValidationException(errors);
            }

            return await next();
        }
    }
}