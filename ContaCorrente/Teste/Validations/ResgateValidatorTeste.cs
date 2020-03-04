using Core.Validations.ViewModels.ContaCorrente;
using Core.ViewModels.ContaCorrente;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace Tests.Validations
{
    public class ResgateValidatorTeste
    {
        private ResgateValidator _validator;
        private ResgateRequest _resgate;


        [SetUp]
        public void Setup()
        {
            _validator = new ResgateValidator();
            _resgate = new ResgateRequest();
        }

        [Test]
        public void IdConta_IqualZero_RetornaErro()
        {
            _resgate.IdConta = 0;

            //Deve ter erro de validacao para 
            _validator.ShouldHaveValidationErrorFor(x => x.IdConta, _resgate);
        }

        [Test]
        public void IdConta_MaiorZero_NaoRetornaErro()
        {
            _resgate.IdConta = 3;

            //Deve ter erro de validacao para 
            _validator.ShouldNotHaveValidationErrorFor(x => x.IdConta, _resgate);
        }
    }
}