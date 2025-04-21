using Agenda.Domain.Entities;
using Agenda.Infrastructure.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Persistence.Repository
{
    public class ContactRepository : RepositoryGeneric<Contact>, IContactRepository
    {
        private ContactListDbContext _context;

        public ContactRepository(ContactListDbContext context): base(context)
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

        public async Task<List<Contact>> GetListContactByIdContactList(int idContactList)
        {
            return await _context.Contact.Where(c => c.IdContactList == idContactList).AsNoTracking().ToListAsync();
        }
    }
}