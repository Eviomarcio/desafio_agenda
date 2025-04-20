using Agenda.Infrastructure.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Persistence.Repository
{
    public class AgendaRepository : RepositoryGeneric<Domain.Entities.Agenda>, IAgendaRepository
    {
        private AgendaDbContext _context;

        public AgendaRepository(AgendaDbContext context): base(context)
        {
            _context = context;
        }

        public Task<Domain.Entities.Agenda> GetAgendaByName(string name)
        {
           return _context.Agenda.Where(a => a.Name == name).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Domain.Entities.Agenda> GetAgendaWithContacts(int id)
        {
            return await _context.Agenda
            .Include(a => a.ListContact)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}