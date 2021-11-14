using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace CodingChallenge.Web.Tests.Author
{
    public class GetAuthorScenario : AuthorScenarioBase
    {
        [Fact]
        public async Task GetAuthorResponseOkStatusCode()
        {
            using var server = CreateServer();
            var response = await server.CreateClient()
                .GetAsync(Get.GetAuthor(Guid.Parse("5469fa74-454a-11ec-81d3-0242ac130003")));

            using var scope = new AssertionScope();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task GetAuthorResponseNotFoundStatusCode()
        {
            using var server = CreateServer();
            var response = await server.CreateClient()
                .GetAsync(Get.GetAuthor(Guid.NewGuid()));

            using var scope = new AssertionScope();
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}