using Agenda.Domain.Entities;
using Agenda.Infrastructure.Persistence.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Persistence.Persistence.Repository
{
    public class ContactRepository : RepositoryGeneric<Contact>, IContactRepository
    {
        private AgendaDbContext _context;

        public ContactRepository(AgendaDbContext context): base(context)
        {
            _context = context;
        }
        public async Task<Contact> GetContactByName(string name)
        {
             return await _context.Contact.Where(c => c.Phone == name).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Contact> GetContactByPhone(string phone)
        {
             return await _context.Contact.Where(c => c.Phone == phone).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<Contact>> GetListContactByIdAgenda(int idAgenda)
        {
            return await _context.Contact.Where(c => c.IdAgenda == idAgenda).AsNoTracking().ToListAsync();
        }
    }
}