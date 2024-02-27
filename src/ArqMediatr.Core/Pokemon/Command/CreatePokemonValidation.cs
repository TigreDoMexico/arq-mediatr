using FluentValidation;

namespace ArqMediatr.Core.Pokemon.Command;

public class CreatePokemonValidation : AbstractValidator<CreatePokemonCommand>
{
    public CreatePokemonValidation()
    {
        RuleFor(pokemon => pokemon.Number)
            .NotEqual(0);
        RuleFor(pokemon => pokemon.Name)
            .NotEmpty();
    }
}