using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Beneyetna.DAL
{
    public class GenericRepository<T> where T : class
    {

        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public DbSet<T> DbSet => _context.Set<T>();

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void DeleteById(int id)
        {
            T? entityToDelete = DbSet.Find(id);
            if (entityToDelete != null)
            {
                Delete(entityToDelete);
            }
        }

        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

    }
}
