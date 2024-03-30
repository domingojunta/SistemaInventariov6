using SistemaInventariov6.Modelos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventariov6.AccesoDatos.Repositories
{
    public interface IBodegaRepository : IRepository<Bodega>
    {
        void Update(Bodega bodega);
    }
}
