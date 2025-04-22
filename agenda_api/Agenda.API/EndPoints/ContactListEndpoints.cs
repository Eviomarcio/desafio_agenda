using System.ComponentModel.DataAnnotations;
using Agenda.API.Util.Responses;
using Agenda.Application.DTOs.InputModel;
using Agenda.Application.DTOs.ViewModel;
using Agenda.Application.Interface;
using Agenda.Domain.Entities;
using System.Linq;

namespace Agenda.API.EndPoints
{
    public static class ContactListEndpoints
    {
        public static WebApplication MapContactListEndpoints(this WebApplication app)
        {
            app.MapPost("api/v1/createContactList", async (
                ContactListInputModel inputModelContactList,
                IContactListService _ContactListService) =>
            {
                try
                {
                    var isExistsContactList = await _ContactListService.GetContactListByName(inputModelContactList.Name);


                    if (isExistsContactList is not null)
                    {
                        return Results.BadRequest(new ResponseView("The contact list already exists", false, null));
                    }

                    var ContactList = await _ContactListService.Create(inputModelContactList.Name);
                    var ContactListViewModel = new ContactListViewModel(ContactList.Name, new List<ContactViewModel>());

                    return Results.Ok(new ResponseView("Contact list registered successfully", true, ContactListViewModel));
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

            app.MapGet("api/v1/getContactListById", async (
                int id,
                IContactListService _ContactListService) =>
            {
                try
                {
                    var isExistsContactList = await _ContactListService.GetById(id);

                    if (isExistsContactList is null)
                    {
                        return Results.BadRequest(new ResponseView("Contact list does not exist", false, null));
                    }


                    var listContact = new List<ContactViewModel>(isExistsContactList.ListContact.Count);

                    foreach (var item in isExistsContactList.ListContact)
                    {
                        listContact.Add(new ContactViewModel(item.Name, item.Email, item.Phone));
                    }

                    var ContactListViewModel = new ContactListViewModel(isExistsContactList.Id, isExistsContactList.Name, listContact);

                    return Results.Ok(new ResponseView("Contact list registered successfully", true, ContactListViewModel));
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
            app.MapGet("api/v1/contactList", async (
               IContactListService _ContactListService) =>
           {
               try
               {
                   var isExistsContactList = await _ContactListService.GetAll();

                   if (isExistsContactList is null)
                   {
                       return Results.BadRequest(new ResponseView("Contact list does not exist", false, null));
                   }

                   var listContact = isExistsContactList.SelectMany(listContact =>
                            listContact.ListContact.Select(c => new ContactViewModel(c.Name, c.Email, c.Phone)))
                            .ToList();

                   var list = isExistsContactList.Select(item => new ContactListViewModel(item.Id, item.Name, listContact)).ToList();

                   return Results.Ok(new ResponseView("Successfully", true, list));
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

            app.MapDelete("api/v1/deleteContactList", async (
                int id,
                IContactListService _ContactListService) =>
            {
                try
                {
                    var ContactListDeleted = await _ContactListService.Delete(id);

                    if (ContactListDeleted is false)
                    {
                        return Results.BadRequest(new ResponseView("Error deleting ContactList", false, null));
                    }

                    return Results.Ok(new ResponseView("Contact list deleted successfully", true, null));
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