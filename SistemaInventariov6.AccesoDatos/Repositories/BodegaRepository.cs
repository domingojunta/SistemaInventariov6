using SistemaInventariov6.AccesoDatos.Data;
using SistemaInventariov6.Modelos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventariov6.AccesoDatos.Repositories
{
    public class BodegaRepository : Repository<Bodega>, IBodegaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BodegaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Bodega bodega)
        {
            var entity = _dbContext.Bodegas.FirstOrDefault(b => b.Id == bodega.Id);
            if (entity != null)
            {
                if (bodega.Nombre != null)
                {
                    entity.Nombre = bodega.Nombre;
                }
                if (bodega.Descripcion != null)
                {
                    entity.Descripcion = bodega.Descripcion;
                }
                if (bodega.Estado != null)
                {
                    entity.Estado = bodega.Estado;
                }

                _dbContext.SaveChanges();
            }
        }
    }
}
