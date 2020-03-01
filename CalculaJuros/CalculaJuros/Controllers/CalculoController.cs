using CalculaJuros.Api.Controllers.Base;
using CalculaJuros.Business.Interface;
using CalculaJuros.CrossCutting.DTO.Calculo;
using CalculaJuros.CrossCutting.Helper;
using CalculaJuros.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CalculaJuros.Controllers
{
    [Route("api/v1/calculaJuros")]
    public class CalculoController : BaseController<Calculo, CalculoDTO>
    {
        public CalculoController(ICalculoService calculoService) : base(calculoService)
        {
        }

        [HttpGet("{valor}/{meses}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult GetCalculo([FromRoute] decimal valor, [FromRoute] int meses)
        {
            var response = ((ICalculoService)_service).GetCalculo(valor, meses);

            return Ok(MapperHelper.Map<Calculo, CalculoDTO>(response));
        }
    }
}