using MediatR;

namespace ArqMediatr.Core.Pokemon.Command;

public class CreatePokemonCommand : IRequest<bool>
{
    public int Number { get; set; }
    public string Name { get; set; } = "";
}