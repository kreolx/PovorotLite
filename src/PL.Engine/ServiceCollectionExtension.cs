using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PL.Contracts.Interfaces;
using PL.Engine.Managers;
using PL.Engine.Storage.DbContexts;

namespace PL.Engine;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddEngine(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilderAction )
    {
        services.AddDbContextPool<ApplicationDbContext>(optionsBuilderAction);
        services.AddTransient<IRequestCommandManager, RequestCommandManager>();
        services.AddTransient<IRequestQueryManager, RequestQueryManager>();
        return services;
    }
}