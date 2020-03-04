using Core.ViewModels.ContaCorrente;
using FluentValidation;

namespace Core.Validations.ViewModels.ContaCorrente
{
    public class RendimentoValidator : AbstractValidator<RendimentoRequest>
    {
        public RendimentoValidator()
        {
            RuleFor(o => o.IdConta)
                .GreaterThan(0).WithMessage("{PropertyName} deve ser maior que zero.");
                
            RuleFor(o => o.PercentualRendimento)
                .GreaterThan(0).WithMessage("{PropertyName} deve ser maior que zero.");

        }
    }
}