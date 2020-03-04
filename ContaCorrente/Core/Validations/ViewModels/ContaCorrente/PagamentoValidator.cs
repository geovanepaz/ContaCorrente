using Core.ViewModels.ContaCorrente;
using FluentValidation;

namespace Core.Validations.ViewModels.ContaCorrente
{
    public class PagamentoValidator : AbstractValidator<PagamentoRequest>
    {
        public PagamentoValidator()
        {
            RuleFor(o => o.IdContaCedente)
                .GreaterThan(0).WithMessage("{PropertyName} deve ser maior que zero.");


            RuleFor(o => o.ValorPagamento)
            .GreaterThan(0.0M).WithMessage("{PropertyName} deve ser maior que zero.");

            RuleFor(o => o.DadosPagamento.CodigoBarras)
            .NotEmpty().WithMessage("CodigoDeBarras é requerida")
            .MaximumLength(9).WithMessage("CodigoDeBarras deve conter no maximo 9 caracteres.")
            .MinimumLength(9).WithMessage("CodigoDeBarras deve conter no minimo 9 caracteres.");

           RuleFor(o => o.DadosPagamento.NomeBeneficiario)
            .NotEmpty().WithMessage("NomeBeneficiario é requerida")
            .MaximumLength(20).WithMessage("NomeBeneficiario deve conter no maximo 20 caracteres.")
            .MinimumLength(3).WithMessage("NomeBeneficiario deve conter no minimo 3 caracteres.");

          RuleFor(o => o.DadosPagamento.ValorConta)
            .GreaterThan(0.0M).WithMessage("ValorBoleto deve ser maior que zero.");  
        }
    }
}