using System.ComponentModel.DataAnnotations;
using Agenda.Application.Interface;
using Agenda.Domain.Entities;
using Agenda.Infrastructure.Persistence.Interface;

namespace Agenda.Application.Service
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaService(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public async Task<Domain.Entities.Agenda> Create(string nameAgenda)
        {
            var existing = await _agendaRepository.GetAgendaByName(nameAgenda);
            if (existing is not null)
            {
                throw new ValidationException("Está agenda já existe.");
            }
            var agenda = new Domain.Entities.Agenda(nameAgenda, new List<Contact>());
            return await _agendaRepository.Add(agenda);
        }

        public async Task<bool> Delete(int idAgenda)
        {
            try
            {
                var agenda = await _agendaRepository.GetEntityById(idAgenda);
                await _agendaRepository.Delete(agenda);

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<Domain.Entities.Agenda> GetById(int idAgenda)
        {
            return await _agendaRepository.GetAgendaWithContacts(idAgenda);
        }

        public async Task<Domain.Entities.Agenda> GetAgendaByName(string nameAgenda)
        {
            return await _agendaRepository.GetAgendaByName(nameAgenda);
        }

        public async Task<List<Domain.Entities.Agenda>> GetAll()
        {
            return await _agendaRepository.ListAll();
        }

        public async Task<Domain.Entities.Agenda> Update(Domain.Entities.Agenda agenda)
        {
            return await _agendaRepository.Update(agenda);
        }
    }
}