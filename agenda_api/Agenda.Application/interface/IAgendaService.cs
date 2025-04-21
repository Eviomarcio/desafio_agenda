namespace Agenda.Application.Interface
{
    public interface IContactListService
    {
        Task<Domain.Entities.ContactList> Create(string nameContactList);
        Task<List<Domain.Entities.ContactList>> GetAll();
        Task<Domain.Entities.ContactList> GetById(int idContactList);
        Task<Domain.Entities.ContactList> GetContactListByName(string nameContactList);
        Task<Domain.Entities.ContactList> Update(Domain.Entities.ContactList ContactList);
        Task<bool> Delete(int idContactList);
    }
}