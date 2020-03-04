using Core.ViewModels.ContaCorrente;
using FluentValidation;

namespace Core.Validations.ViewModels.ContaCorrente
{
    public class DepositoValidator : AbstractValidator<DepositoRequest>
    {
        public DepositoValidator()
        {
            RuleFor(o => o.IdConta)
                .GreaterThan(0).WithMessage("{PropertyName} deve ser maior que zero.");

            RuleFor(o => o.ValorDeposito)
                .GreaterThan(0).WithMessage("{PropertyName} deve ser maior que zero.");

        }
    }
}