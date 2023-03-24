using API.Models;
using API.Pagination;
using API.Repository;

namespace API.Repository
{
    public interface ICidadeRepository: IRepository<Cidade>
    {
        Task<PagedList<Cidade>> GetCidades(CidadesParameters cidadesParameters);

        //IEnumerable<Cidade> GetCidadePorEstado();
    }
}
