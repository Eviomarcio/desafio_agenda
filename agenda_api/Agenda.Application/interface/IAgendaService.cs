using Agenda.Domain.Entities;

namespace Agenda.Application.Interface
{
    public interface IContactListService
    {
        Task<ContactList> Create(string nameContactList);
        Task<List<ContactList>> GetAll();
        Task<ContactList> GetById(int idContactList);
        Task<ContactList> GetContactListByName(string nameContactList);
        Task<ContactList> Update(ContactList ContactList);
        Task<bool> Delete(int idContactList);
    }
}