using ArqMediatr.Core.IoC;
using ArqMediatr.Core.Pokemon.Command;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Serilog;

namespace ArqMediatr.Core.Pokemon.Handlers;

public class CreatePokemonHandler : IRequestHandler<CreatePokemonCommand, bool>, IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/pokemon", async (IMediator mediator, IValidator<CreatePokemonCommand> validator, [FromBody] CreatePokemonCommand request) =>
            {
                var validateResult = await validator.ValidateAsync(request);

                if (!validateResult.IsValid)
                    return Results.BadRequest(validateResult.ToString("˜"));
                
                var result = await mediator.Send(request);
                return Results.Ok(result);
            })
            .WithName("CreatePokemon")
            .WithOpenApi();
    }
    
    public async Task<bool> Handle(CreatePokemonCommand request, CancellationToken cancellationToken)
    {
        Log.Information("Creating new Pokemon");
        return await Task.FromResult(request.Number == 3);
    }
}