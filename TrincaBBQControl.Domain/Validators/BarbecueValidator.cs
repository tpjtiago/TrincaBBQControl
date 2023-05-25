using FluentValidation;
using TrincaBBQControl.Domain.Entities;

namespace TrincaBBQControl.Domain.Validators
{
    public class BarbecueValidator : AbstractValidator<Barbecue>
    {
        public BarbecueValidator()
        {
            RuleFor(barbecue => barbecue.Date).NotEmpty().WithMessage("A data do churrasco é obrigatória.");
            RuleFor(barbecue => barbecue.Description).NotEmpty().WithMessage("A descrição do churrasco é obrigatória.");
            RuleFor(barbecue => barbecue.AdditionalNotes).MaximumLength(100).WithMessage("As observações adicionais do churrasco devem ter no máximo 100 caracteres.");
        }
    }
}
