using System.ComponentModel.DataAnnotations;
using Agenda.Application.Interface;
using Agenda.Domain.Entities;
using Agenda.Infrastructure.Persistence.Interface;

namespace Agenda.Application.Service
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Contact> Create(Contact contact)
        {
            var existing = await _contactRepository.GetContactByPhone(contact.Phone);
            if (existing is not null)
            {
                throw new ValidationException("This contact already exists.");
            }

            return await _contactRepository.Add(contact);
        }

        public Task<List<Contact>> GetAll(int IdContactList)
        {
            return _contactRepository.GetListContactByIdContactList(IdContactList);
        }
        public Task<Contact> GetById(int idContact)
        {
            return _contactRepository.GetEntityById(idContact);
        }

        public Task<Contact> GetByPhone(string phone)
        {
            return _contactRepository.GetContactByPhone(phone);
        }

        public Task<Contact> Update(Contact contact)
        {
            return _contactRepository.Update(contact);
        }

        public async Task<bool> Delete(int idContact)
        {
            try
            {
                var contact = await _contactRepository.GetEntityById(idContact);
                _contactRepository.Delete(contact);

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public Task<Contact> GetByName(string name)
        {
            return _contactRepository.GetContactByName(name);
        }
    }
}