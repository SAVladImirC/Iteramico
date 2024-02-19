using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace General.Repository
{
    public class GeneralRepository<T, C>(C context) : IGeneralRepository<T> where T : class where C : DbContext
    {
        protected readonly C _context = context;

        public void BatchDelete(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async Task BatchInsert(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task BatchUpdate(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> FindAll(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T?> FindSingle(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public async Task<T> Insert(T entity)
        {
            var e = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return e.Entity;
        }

        public async Task<T> Update(T entity)
        {
            var e = _context.Update<T>(entity);
            await _context.SaveChangesAsync();
            return e.Entity;
        }
    }
}