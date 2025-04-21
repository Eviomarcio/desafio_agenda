using System.ComponentModel.DataAnnotations;
using Agenda.API.Util.Responses;
using Agenda.Application.DTOs.InputModel;
using Agenda.Application.DTOs.ViewModel;
using Agenda.Application.Interface;
using Agenda.Domain.Entities;

namespace Agenda.API.EndPoints
{
    public static class ContactEndpoints
    {
        public static WebApplication MapContactEndpoints(this WebApplication app)
        {

            app.MapPost("api/v1/createContact", async (
                ContactInputModel inputModelContact,
                IContactService _contactService,
                IContactListService _ContactListService) =>
            {
                try
                {
                    var ContactList = inputModelContact.IdContactList == 0
                        ? _ContactListService.GetById(inputModelContact.IdContactList)
                        : _ContactListService.Create("Contatos");

                    var contact = new Contact(
                        inputModelContact.Name,
                        inputModelContact.Email,
                        inputModelContact.Phone,
                        ContactList.Id);


                    await _contactService.Create(contact);

                    var contactView = new ContactViewModel(contact.Name, contact.Email, contact.Phone);
                    return Results.Ok(new ResponseView("Contact registered successfully", true, contactView));
                }
                catch (ValidationException ve)
                {
                    return Results.BadRequest(new ResponseView(ve.Message, false, inputModelContact));
                }
                catch (Exception ex)
                {
                    ResponseError details = new();
                    details.ResponseDetailsError(500, "server error", ex.Message);

                    return Results.Problem(details.DetailsError);
                }
            });

            app.MapGet("api/v1/getContactPhone", async (
                string phone,
                IContactService _contactService) =>
            {
                try
                {
                    var contact = await _contactService.GetByPhone(phone);

                    if (contact is null)
                    {
                        return Results.BadRequest(new ResponseView("Contact does not exist", false, null));
                    }

                    var contactView = new ContactViewModel(contact.Name, contact.Email, contact.Phone);

                    return Results.Ok(new ResponseView("Contact", true, contactView));
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

            app.MapGet("api/v1/getContactName", async (
                string name,
                IContactService _contactService) =>
            {
                try
                {
                    var contact = await _contactService.GetByName(name);

                    if (contact is null)
                    {
                        return Results.BadRequest(new ResponseView("Contact does not exist", false, null));
                    }

                    var contactView = new ContactViewModel(contact.Name, contact.Email, contact.Phone);

                    return Results.Ok(new ResponseView("Contact registered successfully", true, contactView));
                }
                catch (System.Exception)
                {

                    throw;
                }
            });

            app.MapGet("api/v1/getContactById", async (
                int id,
                IContactService _contactService) =>
            {
                try
                {
                    var contact = await _contactService.GetById(id);

                    if (contact is null)
                    {
                        return Results.BadRequest(new ResponseView("Contact does not exist", false, null));
                    }

                    var contactView = new ContactViewModel(contact.Name, contact.Email, contact.Phone);

                    return Results.Ok(new ResponseView("Contact registered successfully", true, contactView));
                }
                catch (System.Exception)
                {

                    throw;
                }
            });

            app.MapGet("api/v1/getAllContact", async (
                int idContactList,
                IContactService _contactService) =>
            {
                try
                {
                    var contacts = await _contactService.GetAll(idContactList);

                    if (contacts is null)
                    {
                        return Results.BadRequest(new ResponseView("Contact does not exist", false, null));
                    }

                    var listContact = new List<ContactViewModel>(contacts.Count);

                    foreach (var item in contacts)
                    {
                        listContact.Add(new ContactViewModel(item.Name, item.Email, item.Phone));
                    }

                    return Results.Ok(new ResponseView("Contacts", true, listContact));
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

            app.MapPut("api/v1/updateContact", async (
                ContactUpdateInputViewModel inputModelContactUpdate,
                IContactService _contactService,
                IContactListService _ContactListService) =>
            {
                try
                {

                    var contactTemp = await _contactService.GetById(inputModelContactUpdate.Id);

                    if (contactTemp is null)
                    {
                        return Results.BadRequest(new ResponseView("Contact does not exist", false, null));
                    }

                    var contact = new Contact(
                        inputModelContactUpdate.Id,
                        inputModelContactUpdate.Name,
                        inputModelContactUpdate.Email,
                        inputModelContactUpdate.Phone,
                        inputModelContactUpdate.IdContactList);

                    var contactView = new ContactViewModel(contact.Name, contact.Email, contact.Phone);

                    await _contactService.Create(contact);

                    return Results.Ok(new ResponseView("Contact updated successfully", true, contactView));

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

            app.MapDelete("api/v1/deleteContact", async (
                int idContact,
                IContactService _contactService) =>
            {
                try
                {
                    var isExistsContact = await _contactService.Delete(idContact);

                    if (isExistsContact is false)
                    {
                        return Results.BadRequest(new ResponseView("Error deleting contact", false, null));
                    }
                    
                    return Results.Ok(new ResponseView("Contact deleted successfully", true, null));
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