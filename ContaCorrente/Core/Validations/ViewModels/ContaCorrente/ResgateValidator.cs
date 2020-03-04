using Core.ViewModels.ContaCorrente;
using FluentValidation;

namespace Core.Validations.ViewModels.ContaCorrente
{
    public class ResgateValidator : AbstractValidator<ResgateRequest>
    {
        public ResgateValidator()
        {
            RuleFor(o => o.IdConta)
                .NotEmpty().WithMessage("{PropertyName} é requerida");
        }
    }
}