using CalculaJuros.Business;
using CalculaJuros.Business.Interface;
using CalculaJuros.CrossCutting.Exceptions;
using CalculaJuros.Data.Context;
using CalculaJuros.Data.Interface;
using CalculaJuros.Data.Repository;
using NUnit.Framework;

namespace CalculaJuros.Tests
{
    public class CalculoServiceTest
    {
        private ICalculoService _calculoService;
        private ICalculoRepository _calculoRepository;

        private const decimal CEM_REAIS = 100M;
        private const int CINCO_MESES = 5;
        private const int VALOR_ZERO = 0;

        private const string MENSAGEM_ERRO = "Problemas ao tentar recuperar a taxa de juros";
        private const string MENSAGEM_ERRO_PARAMETRO_VALOR = "O parâmetro valor deve ser maior que zero";
        private const string MENSAGEM_ERRO_PARAMETRO_MESES = "O parâmetro meses deve ser maior que zero";

        [SetUp]
        public void Setup()
        {
            _calculoRepository = new CalculoRepository(new DataContext());
            _calculoService = new CalculoService(_calculoRepository);
        }

        [Test]
        public void Deve_lancar_excessao_se_nao_encontrar_registro()
        {
            var ex = Assert.Throws<ClientServiceException>(() => _calculoService.GetCalculo(CEM_REAIS, CINCO_MESES));
            Assert.AreEqual(ex.Message, MENSAGEM_ERRO);
        }

        [Test]
        public void Deve_lancar_excessao_se_parametro_valor_for_invalido()
        {
            var ex = Assert.Throws<EntityValidationException>(() => _calculoService.ValidaParametrosCalculo(VALOR_ZERO, CINCO_MESES));
            Assert.AreEqual(ex.Message, MENSAGEM_ERRO_PARAMETRO_VALOR);
        }

        [Test]
        public void Deve_lancar_excessao_se_parametro_meses_for_invalido()
        {
            var ex = Assert.Throws<EntityValidationException>(() => _calculoService.ValidaParametrosCalculo(CEM_REAIS, VALOR_ZERO));
            Assert.AreEqual(ex.Message, MENSAGEM_ERRO_PARAMETRO_MESES);
        }
    }
}