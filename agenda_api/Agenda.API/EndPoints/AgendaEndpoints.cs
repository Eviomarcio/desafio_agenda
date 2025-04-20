using System.ComponentModel.DataAnnotations;
using Agenda.API.Util.Responses;
using Agenda.Application.DTOs.InputModel;
using Agenda.Application.DTOs.ViewModel;
using Agenda.Application.Interface;
using Agenda.Domain.Entities;

namespace Agenda.API.EndPoints
{
    public static class AgendaEndpoints
    {
        public static WebApplication MapAgendaEndpoints(this WebApplication app)
        {
            app.MapPost("api/v1/createAgenda", async (
                AgendaInputModel inputModelAgenda,
                IAgendaService _agendaService) =>
            {
                try
                {
                    var isExistsAgenda = _agendaService.GetAgendaByName(inputModelAgenda.Name);


                    if (isExistsAgenda is null)
                    {
                        return Results.BadRequest(new ResponseView("Contact does not exist", false, null));
                    }

                    var agenda = await _agendaService.Create(inputModelAgenda.Name);
                    var agendaViewModel = new AgendaViewModel(agenda.Name, new List<ContactViewModel>());

                    return Results.Ok(new ResponseView("Agenda registered successfully", true, agendaViewModel));
                }
                catch (ValidationException ve)
                {
                    return Results.BadRequest(new ResponseView(ve.Message, false, null));
                }
                catch (Exception ex)
                {
                    ResponseError details = new();
                    details.ResponseDetailsError(500, "server error", ex.Message);

                    return Results.Problem(details.DetailsError);
                }
            });

            app.MapGet("api/v1/getAgendaById", async (
                int id,
                IAgendaService _agendaService) =>
            {
                try
                {
                    var isExistsAgenda = await _agendaService.GetById(id);

                    if (isExistsAgenda is null)
                    {
                        return Results.BadRequest(new ResponseView("Agenda does not exist", false, null));
                    }


                    var listContact = new List<ContactViewModel>(isExistsAgenda.ListContact.Count);

                    foreach (var item in isExistsAgenda.ListContact)
                    {
                        listContact.Add(new ContactViewModel(item.Name, item.Email, item.Phone));
                    }

                    var agendaViewModel = new AgendaViewModel(isExistsAgenda.Name, listContact);

                    return Results.Ok(new ResponseView("Agenda registered successfully", true, agendaViewModel));
                }
                catch (ValidationException ve)
                {
                    return Results.BadRequest(new ResponseView(ve.Message, false, null));
                }
                catch (Exception ex)
                {
                    ResponseError details = new();
                    details.ResponseDetailsError(500, "server error", ex.Message);

                    return Results.Problem(details.DetailsError);
                }
            });

            app.MapDelete("api/v1/deleteAgenda", async (
                int id,
                IAgendaService _agendaService) =>
            {
                try
                {
                    var agendaDeleted = await _agendaService.Delete(id);

                    if (agendaDeleted is false)
                    {
                        return Results.BadRequest(new ResponseView("Error deleting agenda", false, null));
                    }

                    return Results.Ok(new ResponseView("Agenda deleted successfully", true, null));
                }
                catch (ValidationException ve)
                {
                    return Results.BadRequest(new ResponseView(ve.Message, false, null));
                }
                catch (Exception ex)
                {
                    ResponseError details = new();
                    details.ResponseDetailsError(500, "server error", ex.Message);

                    return Results.Problem(details.DetailsError);
                }
            });

            return app;
        }
    }
}