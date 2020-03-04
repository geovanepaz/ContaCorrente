using Core.Validations.ViewModels.ContaCorrente;
using Core.ViewModels.ContaCorrente;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace Tests.Validations
{
    public class PagamentoValidatorTeste
    {
        private PagamentoValidator _validator;
        private PagamentoRequest _pagamento;


        [SetUp]
        public void Setup()
        {
            _validator = new PagamentoValidator();
            _pagamento = new PagamentoRequest { DadosPagamento = new DadosPagamento() };
        }

        [Test]
        public void ValorPagamento_IqualZero_RetornaErro()
        {
            _pagamento.ValorPagamento = 0;

            //Deve ter erro de validacao para 
            _validator.ShouldHaveValidationErrorFor(x => x.ValorPagamento, _pagamento);
        }

        [Test]
        public void ValorPagamento_MaiorQueZero_NaoRetornaErro()
        {
            _pagamento.ValorPagamento = 50;

            //não retorna erro de validacao para 
            _validator.ShouldNotHaveValidationErrorFor(x => x.ValorPagamento, _pagamento);
        }

        [Test]
        public void IdContaCedente_MaiorQueZero_NaoRetornaErro()
        {
            _pagamento.IdContaCedente = 1;

            //não retorna erro de validacao para 
            _validator.ShouldNotHaveValidationErrorFor(x => x.IdContaCedente, _pagamento);
        }

        [Test]
        public void IdContaCedente_IgualZero_RetornaErro()
        {
            _pagamento.IdContaCedente = 0;

            // retorna erro de validacao para 
            _validator.ShouldHaveValidationErrorFor(x => x.IdContaCedente, _pagamento);
        }

        [Test]
        public void CodigoBarras_IgualNull_RetornaErro()
        {
            _pagamento.DadosPagamento.CodigoBarras = null;

            // retorna erro de validacao para 
            _validator.ShouldHaveValidationErrorFor(x => x.DadosPagamento.CodigoBarras, _pagamento);
        }

        [Test]
        public void CodigoBarras_DifenrenteDeNoveCaracteres_RetornaErro()
        {
            _pagamento.DadosPagamento.CodigoBarras = "33333333";

            // retorna erro de validacao para 
            _validator.ShouldHaveValidationErrorFor(x => x.DadosPagamento.CodigoBarras, _pagamento);
        }

        [Test]
        public void CodigoBarras_ComNoveNoveCaracteres_NaoRetornaErro()
        {
            _pagamento.DadosPagamento.CodigoBarras = "123456789";

            // retorna erro de validacao para 
            _validator.ShouldNotHaveValidationErrorFor(x => x.DadosPagamento.CodigoBarras, _pagamento);
        }

        [Test]
        public void NomeBeneficiario_igualNull_RetornaErro()
        {
            _pagamento.DadosPagamento.NomeBeneficiario = null;

            // retorna erro de validacao para 
            _validator.ShouldHaveValidationErrorFor(x => x.DadosPagamento.NomeBeneficiario, _pagamento);
        }

        [Test]
        public void NomeBeneficiario_ComCincoCaracteres_NaoRetornaErro()
        {
            _pagamento.DadosPagamento.NomeBeneficiario = "teste";

            // retorna erro de validacao para 
            _validator.ShouldNotHaveValidationErrorFor(x => x.DadosPagamento.NomeBeneficiario, _pagamento);
        }

        [Test]
        public void ValorConta_IgualZero_RetornaErro()
        {
            _pagamento.DadosPagamento.ValorConta = 0;

            // retorna erro de validacao para 
            _validator.ShouldHaveValidationErrorFor(x => x.DadosPagamento.ValorConta, _pagamento);
        }

        [Test]
        public void ValorConta_MaiorZero_NaoRetornaErro()
        {
            _pagamento.DadosPagamento.ValorConta = 50;

            // retorna erro de validacao para 
            _validator.ShouldNotHaveValidationErrorFor(x => x.DadosPagamento.ValorConta, _pagamento);
        }
    }
}