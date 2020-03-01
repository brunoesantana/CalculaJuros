using System.Collections.Generic;
using CalculaJuros.Business.Interface.Base;
using CalculaJuros.Data.Interface.Base;

namespace CalculaJuros.Business.Base
{
    public class BaseService<T> : IServiceBase<T> where T : class
    {
        protected readonly IRepositoryBase<T> Repository;

        public BaseService(IRepositoryBase<T> repository)
        {
            Repository = repository;
        }

        public virtual List<T> GetAll()
        {
            return Repository.GetAll();
        }
    }
}