using Agenda.Infrastructure.Persistence.Interface;

namespace Agenda.Infrastructure.Persistence.Interface
{
    public interface IAgendaRepository : IRepositoryGeneric<Agenda.Domain.Entities.Agenda>
    {
        Task<Domain.Entities.Agenda> GetAgendaByName(string name);
        Task<Domain.Entities.Agenda> GetAgendaWithContacts(int id);
    }
}