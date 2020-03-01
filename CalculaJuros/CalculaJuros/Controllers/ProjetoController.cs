using CalculaJuros.Api.Controllers.Base;
using CalculaJuros.Business.Interface;
using CalculaJuros.CrossCutting.DTO.Projeto;
using CalculaJuros.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CalculaJuros.Controllers
{
    [Route("api/v1/showmethecode")]
    public class ProjetoController : BaseController<Projeto, ProjetoDTO>
    {
        public ProjetoController(IProjetoService projetoService) : base(projetoService)
        {
        }

        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult GetAll()
        {
            return base.GetAll();
        }
    }
}