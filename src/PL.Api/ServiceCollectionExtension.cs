using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PL.Api.Queries;

namespace PL.Api;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPLControllers(this IServiceCollection services)
    {
        services.AddGraphQLServer()
            .AddQueryType<RequestQueryProvider>()
            .AddProjections()
            .AddFiltering()
            .AddSorting();
        return services;
    }

    public static WebApplication UsePLGqlControllers(this WebApplication app)
    {
        app.MapGraphQL("/graphql");
        return app;
    }
}