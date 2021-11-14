using System.Text.Json;
using System.Text.Json.Serialization;
using CodingChallenge.Application.Domain.Commands.Author;
using CodingChallenge.Application.Domain.Commands.Book;
using CodingChallenge.Application.Validators;
using CodingChallenge.Infrastructure;
using CodingChallenge.Web.Middlewares;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CodingChallenge.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            services.AddMediatR(typeof(Application.Handlers.Author.CreateAuthorHandler).Assembly);
            services.AddScoped<IValidator<CreateAuthorCommand>, CreateAuthorCommandValidator>();
            services.AddScoped<IValidator<CreateBookCommand>, CreateBookCommandValidator>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddPersistence(Configuration);

            services.AddScoped<ValidationExceptionHandlingMiddleware>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Coding Challenge API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ValidationExceptionHandlingMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Coding Challenge API v1");
            });
            app.UseRouting();
            app.UseEndpoints(options => options.MapControllers());
        }
    }
}