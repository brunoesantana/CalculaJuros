using CalculaJuros.CrossCutting.DTO.Calculo;
using CalculaJuros.CrossCutting.Helper;
using CalculaJuros.Data.Base;
using CalculaJuros.Data.Context;
using CalculaJuros.Data.Interface;
using CalculaJuros.Domain;
using System;

namespace CalculaJuros.Data.Repository
{
    public class CalculoRepository : BaseRepository<Calculo>, ICalculoRepository
    {
        private const int VALOR_UM = 1;

        public CalculoRepository(DataContext context) : base(context)
        {
        }

        public Calculo GetCalculo(ParametrosCalculoDTO parametrosCalculoDTO)
        {
            var calculo = MockHelper.GetCalculo();
            calculo.Value = CalculaJuroComposto(parametrosCalculoDTO);

            return calculo;
        }

        public decimal CalculaJuroComposto(ParametrosCalculoDTO parametrosCalculoDTO)
        {
            var valor = parametrosCalculoDTO.Valor;
            var tempo = parametrosCalculoDTO.Meses;
            var taxa = parametrosCalculoDTO.TaxaJuros;
            var valorCalculadoPotencia = Math.Pow((VALOR_UM + taxa), tempo);

            return valor * (decimal)valorCalculadoPotencia;
        }
    }
}