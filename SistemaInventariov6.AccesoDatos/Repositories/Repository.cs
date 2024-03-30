using Microsoft.EntityFrameworkCore;
using SistemaInventariov6.AccesoDatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventariov6.AccesoDatos.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
            this.dbSet = _db.Set<T>();
        }

        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity); //Insert into table
        }

        public async Task<T> Get(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>> filtro = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            string incluirPropiedades = null, 
            bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp); // ejemplo "Categoria,Marca"
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        
        public async Task<T> GetFirst(
            Expression<Func<T, bool>> filtro = null, 
            string incluirPropiedades = null, 
            bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            
            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp); // ejemplo "Categoria,Marca"
                }
            }

            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
           dbSet.RemoveRange(entities);
        }
    }
}
