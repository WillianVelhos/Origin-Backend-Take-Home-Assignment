using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace RiskProfile.Web.Test
{
    public class TestClientProvider
    {
        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            server.BaseAddress = new Uri("https://localhost:44325");

            Client = server.CreateClient();
            Client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public static TestClientProvider New => new TestClientProvider();
    }
}
