using CalculaJuros.Business.Base;
using CalculaJuros.Business.Interface;
using CalculaJuros.Data.Interface;
using CalculaJuros.Domain;

namespace CalculaJuros.Business
{
    public class ProjetoService : BaseService<Projeto>, IProjetoService
    {
        public ProjetoService(IProjetoRepository repository) : base(repository)
        {
        }
    }
}