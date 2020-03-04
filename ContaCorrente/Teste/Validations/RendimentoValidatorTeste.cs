using Core.Validations.ViewModels.ContaCorrente;
using Core.ViewModels.ContaCorrente;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace Tests.Validations
{
    public class RendimentoValidatorTeste
    {
        private RendimentoValidator _validator;
        private RendimentoRequest _rendimento;


        [SetUp]
        public void Setup()
        {
            _validator = new RendimentoValidator();
            _rendimento = new RendimentoRequest();
        }

        [Test]
        public void IdConta_IqualZero_RetornaErro()
        {
            _rendimento.IdConta = 0;

            //Deve ter erro de validacao para 
            _validator.ShouldHaveValidationErrorFor(x => x.IdConta, _rendimento);
        }

        [Test]
        public void IdConta_MaiorZero_NaoRetornaErro()
        {
            _rendimento.IdConta = 3;

            //Deve ter erro de validacao para 
            _validator.ShouldNotHaveValidationErrorFor(x => x.IdConta, _rendimento);
        }

        [Test]
        public void PercentualRendimento_MaiorZero_NaoRetornaErro()
        {
            _rendimento.PercentualRendimento = 10;

            //Deve ter erro de validacao para 
            _validator.ShouldNotHaveValidationErrorFor(x => x.PercentualRendimento, _rendimento);
        }

        [Test]
        public void PercentualRendimento_IgualZero_RetornaErro()
        {
            _rendimento.PercentualRendimento = 0;

            //Deve ter erro de validacao para 
            _validator.ShouldHaveValidationErrorFor(x => x.PercentualRendimento, _rendimento);
        }
    }
}