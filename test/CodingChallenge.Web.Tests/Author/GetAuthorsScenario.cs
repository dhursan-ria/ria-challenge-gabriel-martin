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
        public async Task GetAuthorsResponseOkStatusCode()
        {
            using var server = CreateServer();
            var response = await server.CreateClient()
                .GetAsync(Get.GetAuthors);

            using var scope = new AssertionScope();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}