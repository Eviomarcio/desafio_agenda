using Agenda.Domain.Entities;

namespace Agenda.Application.Interface
{
    public interface IContactService
    {
        Task<Contact> Create(Contact contact);
        Task<List<Contact>> GetAll(int IdAgenda);
        Task<Contact> GetById(int idContact);
        Task<Contact> GetByPhone(string phone);
        Task<Contact> GetByName(string name);
        Task<Contact> Update(Contact contact);
        Task<bool> Delete(int idContact);
    }
}