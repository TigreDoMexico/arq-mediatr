using ArqMediatr.Core.IoC;
using ArqMediatr.Core.Pokemon.Model;
using ArqMediatr.Core.Pokemon.Queries;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ArqMediatr.Core.Pokemon.Handlers;

public class GetPokemonHandler
    : IRequestHandler<GetPokemonByNumber, PokemonEntity>, IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/pokemon/{number}", async (IMediator mediator, [FromRoute] int number) =>
            {
                var result = await mediator.Send(new GetPokemonByNumber() { Number = number});
                return Results.Ok(result);
            })
            .WithName("GetPokemon")
            .WithOpenApi();
    }
    
    public async Task<PokemonEntity> Handle(GetPokemonByNumber request, CancellationToken cancellationToken)
    {
        PokemonEntity p = new() { Id = request.Number, Name = "Pikachu" };
        return await Task.FromResult(p);
    }
}