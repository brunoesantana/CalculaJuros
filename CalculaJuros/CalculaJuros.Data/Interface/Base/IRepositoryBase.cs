using System.Collections.Generic;

namespace CalculaJuros.Data.Interface.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        List<T> GetAll();
    }
}