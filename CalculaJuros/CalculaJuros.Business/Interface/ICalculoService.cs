using CalculaJuros.Business.Interface.Base;
using CalculaJuros.CrossCutting.DTO.Calculo;
using CalculaJuros.Domain;
using RestSharp;
using System.Collections.Generic;

namespace CalculaJuros.Business.Interface
{
    public interface ICalculoService : IServiceBase<Calculo>
    {
        Calculo GetCalculo(decimal valor, int meses);

        double GetTaxaJuros();

        TaxaDTO ProcessaRetorno(IRestResponse<List<TaxaDTO>> response);

        void ValidaParametrosCalculo(decimal valor, int meses);
    }
}