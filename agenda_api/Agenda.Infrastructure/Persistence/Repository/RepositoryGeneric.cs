
using System.Linq.Expressions;
using Agenda.Infrastructure.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Persistence.Repository
{
    public abstract class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        private readonly ContactListDbContext _context;

        public RepositoryGeneric(ContactListDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T objector)
        {
            await _context.Set<T>().AddAsync(objector);
            await _context.SaveChangesAsync();
            return objector;
        }

        public async Task<bool> Delete(T objector)
        {
            var result = _context.Set<T>().Remove(objector);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public virtual async Task<List<T>> Get(Expression<Func<T, bool>> where)
        {
            return await _context.Set<T>().Where(where).AsNoTracking().ToListAsync();
        }

        public async Task<T> GetEntityById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> ListAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T objector)
        {
            _context.Set<T>().Update(objector).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return objector;
        }
    }
}