using ArqMediatr.Core.IoC;
using ArqMediatr.Core.Pokemon.Command;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ArqMediatr.Core.Pokemon.Handlers;

public class CreatePokemonHandler : IRequestHandler<CreatePokemonCommand, bool>, IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/pokemon", async (IMediator mediator, [FromBody] CreatePokemonCommand request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result);
            })
            .WithName("CreatePokemon")
            .WithOpenApi();
    }
    
    public async Task<bool> Handle(CreatePokemonCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(request.Number == 3);
    }
}