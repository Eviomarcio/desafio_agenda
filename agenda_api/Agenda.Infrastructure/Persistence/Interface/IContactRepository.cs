using Agenda.Domain.Entities;

namespace Agenda.Infrastructure.Persistence.Interface
{
    public interface IContactRepository : IRepositoryGeneric<Contact>
    {
        Task<Contact> GetContactByName(string name);
        Task<Contact> GetContactByPhone(string phone);
        Task<List<Contact>> GetListContactByIdAgenda(int idAgenda);
    }
}