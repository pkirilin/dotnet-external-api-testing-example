using ExternalApiTestingExample.Tests.GetTodos;
using ExternalApiTestingExample.WebApi.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace ExternalApiTestingExample.Tests;

internal class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.AddTodosClient()
                .ConfigurePrimaryHttpMessageHandler(() => new FakeTodosClientHandler());
        });
    }
}