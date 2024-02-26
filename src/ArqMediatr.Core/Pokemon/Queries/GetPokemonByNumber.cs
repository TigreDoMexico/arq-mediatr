using ArqMediatr.Core.Pokemon.Model;
using MediatR;

namespace ArqMediatr.Core.Pokemon.Queries;

public class GetPokemonByNumber : IRequest<PokemonEntity>
{
    public int Number { get; set; }
}