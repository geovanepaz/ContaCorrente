using Core.Validations.ViewModels.ContaCorrente;
using Core.ViewModels.ContaCorrente;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace Tests.Validations
{
    public class DepositoValidatorTeste
    {
        private DepositoValidator _validator;
        private DepositoRequest _deposito;

        [SetUp]
        public void Setup()
        {
            _validator = new DepositoValidator();
            _deposito = new DepositoRequest();
        }

        [Test]
        public void ValorDeposito_IqualZero_RetornaErro()
        {
            _deposito.ValorDeposito = 0;

            //Deve ter erro de validacao para 
            _validator.ShouldHaveValidationErrorFor(x => x.ValorDeposito, _deposito);
        }

        [Test]
        public void ValorDeposito_MaiorQueZero_NaoRetornaErro()
        {
            _deposito.ValorDeposito = 50;

            //não retorna erro de validacao para 
            _validator.ShouldNotHaveValidationErrorFor(x => x.ValorDeposito, _deposito);
        }

        [Test]
        public void IdConta_MaiorQueZero_NaoRetornaErro()
        {
            _deposito.IdConta = 1;

            //não retorna erro de validacao para 
            _validator.ShouldNotHaveValidationErrorFor(x => x.IdConta, _deposito);
        }

        [Test]
        public void IdConta_IgualZero_RetornaErro()
        {
            _deposito.IdConta = 0;

            // retorna erro de validacao para 
            _validator.ShouldHaveValidationErrorFor(x => x.IdConta, _deposito);
        }
    }
}