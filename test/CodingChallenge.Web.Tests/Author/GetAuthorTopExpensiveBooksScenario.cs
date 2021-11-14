using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace CodingChallenge.Web.Tests.Author
{
    public class GetAuthorTopExpensiveBooksScenario : AuthorScenarioBase
    {
        [Fact]
        public async Task GetAuthorsTopExpensiveBooksResponseOkStatusCode()
        {
            using var server = CreateServer();
            var response = await server.CreateClient()
                .GetAsync(Get.GetAuthorTopBooks);

            using var scope = new AssertionScope();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}