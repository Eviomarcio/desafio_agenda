using Agenda.Infrastructure.Persistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Persistence.Repository
{
    public class ContactListRepository : RepositoryGeneric<Domain.Entities.ContactList>, IContactListRepository
    {
        private ContactListDbContext _context;

        public ContactListRepository(ContactListDbContext context): base(context)
        {
            _context = context;
        }

        public Task<Domain.Entities.ContactList> GetContactListByName(string name)
        {
           return _context.ContactList.Where(a => a.Name == name).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Domain.Entities.ContactList> GetContactListWithContacts(int id)
        {
            return await _context.ContactList
            .Include(a => a.ListContact)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}