using Mapster;
using Shop2.Entities;
using Shop2.Models;

namespace Shop2.Mapster;

public static class MapsterConfigs
{
    public static IServiceCollection AddMapsterConfigs(this IServiceCollection services)
    {
        services.AddMapster();
        ProductConfigs.AddConfigs();
        TimeSpanConfigs.AddConfigs();
        UserConfigs.AddConfigs();
        return services;
    }
}