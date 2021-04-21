using FluentValidation;
using Lambda3.Games.Core.Models;
using System.Collections.Generic;

namespace Lambda3.Games.Core.Validators
{
    public class GameValidator : AbstractValidator<IList<Game>>
    {
        private const int MinimoPermitidoDeJogos = 8;
        public GameValidator()
        {
            RuleFor(g => g)
                .Must(g => (g.Count == MinimoPermitidoDeJogos)).WithMessage($"A lista deve conter {MinimoPermitidoDeJogos} items")
                .Must(g => g.Count % 2 != 1).WithMessage("A lista não pode conter games impares");

        }
    }
}
