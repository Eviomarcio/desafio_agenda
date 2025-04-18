using Agenda.Domain.Entities;

namespace Agenda.Application.Interface
{
    public interface IContactService
    {
        Task<Contact> Create();
        Task<Contact> GetAll();
        Task<Contact> GelById();
        Task<Contact> Update();
        Task<bool> Delete();
    }
}