using CalculaJuros.Business.Interface;
using CalculaJuros.CrossCutting.DTO.Calculo;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;

namespace CalculaJuros.Tests
{
    public class CalculaJurosUnitTest
    {
        private ICalculoService _mockService;
        private IRestResponse<List<TaxaDTO>> _mockResponse;

        private const double UM_POR_CENTO = 1D / 100;
        private const decimal CEM_REAIS = 100M;
        private const int CINCO_MESES = 5;
        private const decimal VALOR_CALCULADO = 105.10M;

        [SetUp]
        public void Setup()
        {
            _mockResponse = new RestResponse<List<TaxaDTO>>();

            _mockService = Substitute.For<ICalculoService>();
            _mockService.GetTaxaJuros().Returns(UM_POR_CENTO);
            _mockService.GetCalculo(CEM_REAIS, CINCO_MESES).Returns(TestHelper.GetCalculo());
            _mockService.ProcessaRetorno(_mockResponse).Returns(TestHelper.GetResponse());
        }

        [Test]
        public void Deve_calcular_valores_corretamente()
        {
            var response = _mockService.GetCalculo(CEM_REAIS, CINCO_MESES);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Value, VALOR_CALCULADO);
        }

        [Test]
        public void Deve_processar_retorno_corretamente()
        {
            var response = _mockService.ProcessaRetorno(_mockResponse);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Value, UM_POR_CENTO);
        }
    }
}