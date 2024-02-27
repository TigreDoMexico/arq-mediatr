using System.Reflection;
using ArqMediatr.Core.Pokemon.Command;
using ArqMediatr.Core.Pokemon.Handlers;
using FluentValidation;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace ArqMediatr.Core.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddMediatr(this IServiceCollection service)
    {
        service.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        return service;
    }
    
    public static IEndpointRouteBuilder ConfigureEndpoints(this IEndpointRouteBuilder endpoints)
    {
        CreatePokemonHandler.MapEndpoint(endpoints);
        GetPokemonHandler.MapEndpoint(endpoints);
        
        return endpoints;
    }
    
    public static IServiceCollection AddCoreDependencies(this IServiceCollection service)
    {
        service.AddScoped<IValidator<CreatePokemonCommand>, CreatePokemonValidation>();
        return service;
    }
}