
using Agenda.Infrastructure.Persistence.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Persistence.Persistence.Repository
{
    public class RepositoryGeneric<T> : IRepositotyGeneric<T> where T : class
    {
        private readonly AgendaDbContext _context;

        public RepositoryGeneric(AgendaDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T objector)
        {
            await _context.Set<T>().AddAsync(objector);
            await _context.SaveChangesAsync();
            return objector;
        }

        public async Task Delete(T objector)
        {
            _context.Set<T>().Remove(objector);
            await _context.SaveChangesAsync();
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