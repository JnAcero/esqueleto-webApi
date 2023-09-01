using Aplicacion.Repositories;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork :IUnitOfWork,IDisposable
    {
          private readonly ApiDbContext _context;
        public UnitOfWork( ApiDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}