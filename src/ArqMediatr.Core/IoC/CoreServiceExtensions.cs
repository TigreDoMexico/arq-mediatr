using System.Reflection;
using ArqMediatr.Core.Pokemon.Handlers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace ArqMediatr.Core.IoC;

public static class CoreServiceExtensions
{
    public static IServiceCollection AddMediatr(this IServiceCollection service)
    {
        service.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(CoreStartup).Assembly));
        return service;
    }
    
    public static IEndpointRouteBuilder ConfigureEndpoints(this IEndpointRouteBuilder endpoints)
    {
        CreatePokemonHandler.MapEndpoint(endpoints);
        GetPokemonHandler.MapEndpoint(endpoints);
        
        return endpoints;
    }
}