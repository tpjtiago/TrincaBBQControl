using FluentValidation;
using TrincaBBQControl.Domain.Entities;

namespace TrincaBBQControl.Domain.Validators
{
    public class ParticipantValidator : AbstractValidator<Participant>
    {
        public ParticipantValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome do participante é obrigatório.")
                .MaximumLength(50).WithMessage("O nome do participante deve ter no máximo 50 caracteres.");

            RuleFor(p => p.ContributionAmount)
                .GreaterThan(0).WithMessage("O valor de contribuição deve ser maior que zero.");

            RuleFor(p => p.SuggestedContribution)
                .GreaterThanOrEqualTo(0).WithMessage("O valor da contribuição sugerida não pode ser negativo.");

            RuleFor(p => p.BarbecueId)
                .GreaterThan(0).WithMessage("O ID do churrasco é obrigatório.");
        }
    }
}
