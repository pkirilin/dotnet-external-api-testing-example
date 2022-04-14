using System;
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
                .ConfigurePrimaryHttpMessageHandler(() => new FakeHttpMessageHandler());
        });
    }

    public WebApplicationFactory<Program> UseFakeTodosClient(
        Func<FakeHttpMessageHandler, FakeHttpMessageHandler> configureHandler)
    {
        var handler = configureHandler.Invoke(new FakeHttpMessageHandler());
        
        return WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddTodosClient().ConfigurePrimaryHttpMessageHandler(() => handler);
            });
        });
    }
}