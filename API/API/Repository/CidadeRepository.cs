using API.Context;
using API.Models;
using API.Pagination;
using API.Repository;

namespace API.Repository
{
    public class CidadeRepository: Repository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(AppDbContext contexto) : base(contexto)
        {

        }

        public async Task<PagedList<Cidade>> GetCidades(CidadesParameters cidadesParameters)
        {
            //return Get()
            //    .OrderBy(on => on.Nome)
            //    .Skip((cidadesParameters.PageNumber - 1) * cidadesParameters.PageSize)
            //    .Take(cidadesParameters.PageSize)
            //    .ToList();

            return await PagedList<Cidade>.ToPagedList(Get().OrderBy(on => on.Nome),
               cidadesParameters.PageNumber, cidadesParameters.PageSize);

        }


        public IEnumerable<Cidade> GetCidadePorEstado()
        {
            //return Get().Where
            throw new NotImplementedException();
        }
    }
}
