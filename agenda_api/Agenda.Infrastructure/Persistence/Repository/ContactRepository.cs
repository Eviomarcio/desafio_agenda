using Agenda.Domain.Entities;
using Agenda.Infrastructure.Persistence.Persistence.Interface;

namespace Agenda.Infrastructure.Persistence.Persistence.Repository
{
    public class ContactRepository : IContactRepository
    {
        private AgendaDbContext _context;

        public ContactRepository(AgendaDbContext context)
        {
            _context = context;
        }

        public Task<Contact> Add(Contact objector)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Contact objector)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetContactByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contact>> ListAll()
        {
            throw new NotImplementedException();
        }

        public Task<Contact> Update(Contact objector)
        {
            throw new NotImplementedException();
        }
    }
}