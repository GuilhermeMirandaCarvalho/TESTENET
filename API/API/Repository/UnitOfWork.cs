using API.Context;

namespace API.Repository
{
    public class UnitOfWork: IUnitOfWork
    {   
        private CidadeRepository _cidadeRepo;
        public AppDbContext _context;

        public UnitOfWork(AppDbContext contexto)
        {
            _context= contexto;
        }

        public ICidadeRepository CidadeRepository
        {
            get 
            { 
                return _cidadeRepo = _cidadeRepo ?? new CidadeRepository(_context); 
            }
        }

        public async Task Commit()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
