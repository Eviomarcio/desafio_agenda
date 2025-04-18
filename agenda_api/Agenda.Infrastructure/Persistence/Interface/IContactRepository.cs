using Agenda.Domain.Entities;

namespace Agenda.Infrastructure.Persistence.Persistence.Interface
{
    public interface IContactRepository : IRepositotyGeneric<Contact>
    {
        Task<Contact> GetContactByName(string name);
    }
}