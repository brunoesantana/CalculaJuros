using System.Collections.Generic;
using System.Linq;
using CalculaJuros.Data.Context;
using CalculaJuros.Data.Interface.Base;
using CalculaJuros.Domain.Base;

namespace CalculaJuros.Data.Base
{
    public class BaseRepository<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public virtual List<T> GetAll()
        {
            return _context.Set<T>().Where(w => w.Active).ToList();
        }
    }
}