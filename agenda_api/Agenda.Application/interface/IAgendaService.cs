namespace Agenda.Application.Interface
{
    public interface IAgendaService
    {
        Task<Domain.Entities.Agenda> Create(string nameAgenda);
        Task<List<Domain.Entities.Agenda>> GetAll();
        Task<Domain.Entities.Agenda> GetById(int idAgenda);
        Task<Domain.Entities.Agenda> GetAgendaByName(string nameAgenda);
        Task<Domain.Entities.Agenda> Update(Domain.Entities.Agenda agenda);
        Task<bool> Delete(int idAgenda);
    }
}