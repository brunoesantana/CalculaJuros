using CalculaJuros.CrossCutting.DTO.Calculo;
using CalculaJuros.Domain;
using System;

namespace CalculaJuros.Tests
{
    public static class TestHelper
    {
        private const decimal VALOR_CALCULADO = 105.10M;
        private const int MESES = 5;
        private const double TAXA = 1D / 100;
        private const decimal VALOR = 100M;

        public static Calculo GetCalculo()
        {
            return new Calculo
            {
                Id = GetId(),
                Value = VALOR_CALCULADO
            };
        }

        public static ParametrosCalculoDTO BuildParametrosFake()
        {
            return new ParametrosCalculoDTO
            {
                Meses = MESES,
                TaxaJuros = TAXA,
                Valor = VALOR
            };
        }

        public static TaxaDTO GetResponse()
        {
            return new TaxaDTO { Id = GetId(), Value = TAXA };
        }

        private static Guid GetId()
        {
            return Guid.NewGuid();
        }
    }
}