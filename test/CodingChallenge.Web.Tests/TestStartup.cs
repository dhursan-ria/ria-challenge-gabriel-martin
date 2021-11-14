using Microsoft.Extensions.Configuration;

namespace CodingChallenge.Web.Tests
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }
    }
}