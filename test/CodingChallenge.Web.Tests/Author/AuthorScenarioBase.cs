using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace CodingChallenge.Web.Tests.Author
{
    public class AuthorScenarioBase
    {
        private const string BaseUrl = "author";

        protected AuthorScenarioBase()
        {
        }

        protected static TestServer CreateServer()
        {
            var path = Assembly.GetAssembly(typeof(AuthorScenarioBase))?.Location
                       ?? throw new ArgumentNullException("Path");

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path)!)
                .ConfigureAppConfiguration(c => c.AddJsonFile("appsettings.json"))
                .UseStartup<TestStartup>();

            return new TestServer(hostBuilder);
        }

        protected static class Get
        {
            public static string GetAuthors => BaseUrl;
            public static string GetAuthor(Guid id) => $"{BaseUrl}/{id}";
            public static string GetAuthorTopBooks => $"{BaseUrl}/top-expensive";
        }

        protected static class Post
        {
            public static string CreateAuthor => BaseUrl;
        }

        protected static class Put
        {
            public static string UpdateAuthor(Guid id) => $"{BaseUrl}/{id}";
        }

        protected static class Delete
        {
            public static string DeleteAuthor(Guid id) => $"{BaseUrl}/{id}";
        }
    }
}