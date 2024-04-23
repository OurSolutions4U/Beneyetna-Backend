using Beneyetna.DataContracts.Context;
using Beneyetna.DataContracts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace Beneyetna.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly BeneyetnaContext _context;


        public BaseRepository(BeneyetnaContext dbContext)
        {
            _context = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().CountAsync(expression);
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            entity.CreationDate= DateTime.Now;
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            var attachedEntity = _context.Set<T>().Local.FirstOrDefault(entry => entry.Id.Equals(entity.Id));
            if (attachedEntity != null)
            {
                _context.Entry(attachedEntity).State = EntityState.Detached;
            }
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstAsync(expression);
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {

            return _context.Set<T>().Where(expression);
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }
    }
}
