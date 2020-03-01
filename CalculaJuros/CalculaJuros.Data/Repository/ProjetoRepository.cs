using CalculaJuros.CrossCutting.Helper;
using CalculaJuros.Data.Base;
using CalculaJuros.Data.Context;
using CalculaJuros.Data.Interface;
using CalculaJuros.Domain;
using System.Collections.Generic;

namespace CalculaJuros.Data.Repository
{
    public class ProjetoRepository : BaseRepository<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(DataContext context) : base(context)
        {
        }

        public override List<Projeto> GetAll()
        {
            return MockHelper.GetProjeto();
        }
    }
}