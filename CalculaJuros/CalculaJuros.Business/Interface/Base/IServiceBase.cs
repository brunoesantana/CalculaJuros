using System.Collections.Generic;

namespace CalculaJuros.Business.Interface.Base
{
    public interface IServiceBase<T> where T : class
    {
        List<T> GetAll();
    }
}