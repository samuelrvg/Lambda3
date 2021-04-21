using FluentValidation;
using Lambda3.Games.Core.Model;
using System.Collections.Generic;

namespace Lambda3.Games.Core.Validators
{
    public class GameValidator : AbstractValidator<IList<Game>>
    {
        private const int _minimoPermitidoDeJogos = 8;
        public GameValidator()
        {
            RuleFor(g => g)
                .Must(g => (g.Count == _minimoPermitidoDeJogos)).WithMessage($@"A lista deve conter {_minimoPermitidoDeJogos} items")
                .Must(g => !(g.Count % 2 == 1)).WithMessage("A lista não pode conter games impares");

        }
    }
}
