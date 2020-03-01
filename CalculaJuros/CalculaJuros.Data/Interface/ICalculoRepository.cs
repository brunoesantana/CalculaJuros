using CalculaJuros.CrossCutting.DTO.Calculo;
using CalculaJuros.Data.Interface.Base;
using CalculaJuros.Domain;

namespace CalculaJuros.Data.Interface
{
    public interface ICalculoRepository : IRepositoryBase<Calculo>
    {
        Calculo GetCalculo(ParametrosCalculoDTO parametrosCalculo);
        decimal CalculaJuroComposto(ParametrosCalculoDTO parametrosCalculoDTO);
    }
}