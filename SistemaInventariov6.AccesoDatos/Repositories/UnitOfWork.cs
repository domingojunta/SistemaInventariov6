using SistemaInventariov6.AccesoDatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventariov6.AccesoDatos.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IBodegaRepository BodegaRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            BodegaRepository = new BodegaRepository(dbContext);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
