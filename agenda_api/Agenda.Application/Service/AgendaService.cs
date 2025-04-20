using Agenda.Application.Interface;

namespace Agenda.Application.Service
{
    public class AgendaService : IAgendaService
    {
        public Task<Domain.Entities.Agenda> Create(string nameAgenda)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Agenda> GelById(int idAgenda)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Agenda> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Agenda> Update(Domain.Entities.Agenda agenda)
        {
            throw new NotImplementedException();
        }
    }
}