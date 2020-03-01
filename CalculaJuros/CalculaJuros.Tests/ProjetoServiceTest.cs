using CalculaJuros.Business;
using CalculaJuros.Business.Interface;
using CalculaJuros.Data.Context;
using CalculaJuros.Data.Interface;
using CalculaJuros.Data.Repository;
using NUnit.Framework;
using System.Linq;

namespace CalculaJuros.Tests
{
    public class ProjetoServiceTest
    {
        private const int VALOR_DOIS = 2;

        private IProjetoService _projetoService;
        private IProjetoRepository _projetoRepository;

        [SetUp]
        public void Setup()
        {
            _projetoRepository = new ProjetoRepository(new DataContext());
            _projetoService = new ProjetoService(_projetoRepository);
        }

        [Test]
        public void Deve_retornar_quantidade_de_registros_corretamente()
        {
            var response = _projetoService.GetAll();

            Assert.IsTrue(response.Any());
            Assert.AreEqual(response.Count, VALOR_DOIS);
        }
    }
}