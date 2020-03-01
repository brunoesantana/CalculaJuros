using CalculaJuros.Business.Base;
using CalculaJuros.Business.Interface;
using CalculaJuros.CrossCutting.DTO.Calculo;
using CalculaJuros.CrossCutting.Exceptions;
using CalculaJuros.CrossCutting.Helper;
using CalculaJuros.Data.Interface;
using CalculaJuros.Domain;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CalculaJuros.Business
{
    public class CalculoService : BaseService<Calculo>, ICalculoService
    {
        private const string URL_CLIENT = "http://localhost:53950/api/v1/taxaJuros";

        private readonly ApiHelper<TaxaDTO> _apiHelper;

        public CalculoService(ICalculoRepository repository) : base(repository)
        {
            _apiHelper = new ApiHelper<TaxaDTO>();
        }

        public Calculo GetCalculo(decimal valor, int meses)
        {
            ValidaParametrosCalculo(valor, meses);

            var taxaJuros = GetTaxaJuros();
            var parametrosCalculo = BuildParametros(valor, meses, taxaJuros);

            return ((ICalculoRepository)Repository).GetCalculo(parametrosCalculo);
        }

        public void ValidaParametrosCalculo(decimal valor, int meses)
        {
            if (valor <= 0)
                throw new EntityValidationException("O parâmetro valor deve ser maior que zero");

            if (meses <= 0)
                throw new EntityValidationException("O parâmetro meses deve ser maior que zero");
        }

        public double GetTaxaJuros()
        {
            var response = _apiHelper.SendRequest(URL_CLIENT, Method.GET);
            var taxaDTO = ProcessaRetorno(response);

            return taxaDTO.Value;
        }

        public TaxaDTO ProcessaRetorno(IRestResponse<List<TaxaDTO>> response)
        {
            if (string.IsNullOrWhiteSpace(response.Content) || response.StatusCode != HttpStatusCode.OK || response.Data == null || !response.Data.Any())
                throw new ClientServiceException("Problemas ao tentar recuperar a taxa de juros");

            return response.Data.FirstOrDefault();
        }

        private ParametrosCalculoDTO BuildParametros(decimal valor, int meses, double taxaJuros)
        {
            return new ParametrosCalculoDTO
            {
                TaxaJuros = taxaJuros,
                Meses = meses,
                Valor = valor
            };
        }
    }
}