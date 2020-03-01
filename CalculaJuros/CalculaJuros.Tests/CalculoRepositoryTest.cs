using CalculaJuros.Data.Context;
using CalculaJuros.Data.Interface;
using CalculaJuros.Data.Repository;
using NUnit.Framework;

namespace CalculaJuros.Tests
{
    public class CalculoRepositoryTest
    {
        private ICalculoRepository _calculoRepository;

        private const decimal VALOR_CALCULADO = 105.10100501m;

        [SetUp]
        public void Setup()
        {
            _calculoRepository = new CalculoRepository(new DataContext());
        }

        [Test]
        public void Deve_retornar_valor_calculado()
        {
            var response = _calculoRepository.CalculaJuroComposto(TestHelper.BuildParametrosFake());
            Assert.IsNotNull(response);
            Assert.AreEqual(response, VALOR_CALCULADO);
        }
    }
}