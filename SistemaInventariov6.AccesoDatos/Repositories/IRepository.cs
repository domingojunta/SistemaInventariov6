using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventariov6.AccesoDatos.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
       Task<IEnumerable<T>> GetAll(
           Expression<Func<T,bool>> filtro = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string incluirPropiedades = null,
           bool isTracking = true);

        Task<T> GetFirst(
            Expression<Func<T, bool>> filtro = null,
            string incluirPropiedades = null,
            bool isTracking = true);

        Task Add(T entity);
        void Remove(T entity); // no puede ser asíncrono
        void RemoveRange(IEnumerable<T> entities); // no puede ser asíncrono


    }
}
