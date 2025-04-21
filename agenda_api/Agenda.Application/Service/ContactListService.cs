using System.ComponentModel.DataAnnotations;
using Agenda.Application.Interface;
using Agenda.Domain.Entities;
using Agenda.Infrastructure.Persistence.Interface;

namespace Agenda.Application.Service
{
    public class ContactListService : IContactListService
    {
        private readonly IContactListRepository _contactListRepository;

        public ContactListService(IContactListRepository ContactListRepository)
        {
            _contactListRepository = ContactListRepository;
        }

        public async Task<ContactList> Create(string nameContactList)
        {
            var existing = await _contactListRepository.GetContactListByName(nameContactList);
            if (existing is not null)
            {
                throw new ValidationException("Está ContactList já existe.");
            }
            var ContactList = new ContactList(nameContactList, new List<Contact>());
            return await _contactListRepository.Add(ContactList);
        }

        public async Task<bool> Delete(int idContactList)
        {
            try
            {
                var contactList = await _contactListRepository.GetEntityById(idContactList);
                await _contactListRepository.Delete(contactList);

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<ContactList> GetById(int idContactList)
        {
            return await _contactListRepository.GetContactListWithContacts(idContactList);
        }

        public async Task<ContactList> GetContactListByName(string nameContactList)
        {
            return await _contactListRepository.GetContactListByName(nameContactList);
        }

        public async Task<List<ContactList>> GetAll()
        {
            return await _contactListRepository.ListAll();
        }

        public async Task<ContactList> Update(ContactList contactList)
        {
            return await _contactListRepository.Update(contactList);
        }
    }
}