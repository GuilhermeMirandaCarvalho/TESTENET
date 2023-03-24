using API.Repository;

namespace API.Repository
{
    public interface IUnitOfWork
    {
        ICidadeRepository CidadeRepository { get; }        

        Task Commit();
    }
}

