using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CalculaJuros.Business.Interface.Base;
using CalculaJuros.CrossCutting.Exceptions;
using CalculaJuros.CrossCutting.Helper;

namespace CalculaJuros.Api.Controllers.Base
{
    public class BaseController<T, TDto> : ControllerBase where T : class where TDto : class
    {
        protected readonly IServiceBase<T> _service;

        public BaseController(IServiceBase<T> baseService)
        {
            _service = baseService;
        }

        protected ActionResult GetAll()
        {
            var response = _service.GetAll();
            return response.Any() 
                ? Ok(MapperHelper.Map<List<T>, List<TDto>>(response)) 
                : throw new NotFoundException();
        }
    }
}