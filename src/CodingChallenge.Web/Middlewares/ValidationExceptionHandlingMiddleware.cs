using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace CodingChallenge.Web.Middlewares
{
    public class ValidationExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException exception)
            {
                await HandleException(context, exception);
            }
        }

        private static async Task HandleException(HttpContext context, ValidationException exception)
        {
            var errors = exception.Errors
                .GroupBy(vf => vf.PropertyName, vf => vf.ErrorMessage,
                    (property, errorList) => (Property: property, Errors: errorList.Distinct().ToArray()))
                .ToDictionary(k => k.Property, k => k.Errors);

            var content = new
            {
                Errors = errors
            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(content);
        }
    }
}