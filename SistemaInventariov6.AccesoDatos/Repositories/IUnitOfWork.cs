using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventariov6.AccesoDatos.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        IBodegaRepository BodegaRepository { get; }

        Task Save();
    }
}
