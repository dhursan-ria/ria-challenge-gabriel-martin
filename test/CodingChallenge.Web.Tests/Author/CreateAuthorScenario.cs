using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CodingChallenge.Application.Domain.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace CodingChallenge.Web.Tests.Author
{
    public class CreateAuthorScenario : AuthorScenarioBase
    {
        [Fact]
        public async Task CreateAuthorResponseCodeCreated()
        {
            var author = new Application.Domain.Models.Author
            {
                Name = "test1",
                Books = new List<Book>()
            };
            using var server = CreateServer();
            var response = await server.CreateClient()
                .PostAsync(Post.CreateAuthor, new StringContent(JsonSerializer.Serialize(author), Encoding.UTF8, "application/json"));

            using var scope = new AssertionScope();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
        
        [Fact]
        public async Task CreateAuthorResponseCodeBadRequest()
        {
            var author = new Application.Domain.Models.Author
            {
                Name = string.Empty,
                Books = new List<Book>()
            };
            using var server = CreateServer();
            var response = await server.CreateClient()
                .PostAsync(Post.CreateAuthor, new StringContent(JsonSerializer.Serialize(author), Encoding.UTF8, "application/json"));

            using var scope = new AssertionScope();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            (await response.Content.ReadAsStringAsync()).Should().Contain("Author.Name");
        }
    }
}