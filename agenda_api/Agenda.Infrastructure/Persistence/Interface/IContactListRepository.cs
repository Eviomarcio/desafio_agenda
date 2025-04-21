using Agenda.Domain.Entities;

namespace Agenda.Infrastructure.Persistence.Interface
{
    public interface IContactListRepository : IRepositoryGeneric<ContactList>
    {
        Task<ContactList> GetContactListByName(string name);
        Task<ContactList> GetContactListWithContacts(int id);
    }
}