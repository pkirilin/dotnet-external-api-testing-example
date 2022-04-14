using ExternalApiTestingExample.WebApi.Integrations;

namespace ExternalApiTestingExample.WebApi.Extensions;

public static class DependencyInjectionExtensions
{
    public static IHttpClientBuilder AddTodosClient(this IServiceCollection services)
    {
        return services.AddHttpClient<ITodosClient, TodosClient>(client =>
        {
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
        });
    }
}