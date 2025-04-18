using Agenda.Application.DTOs.InputModel;

namespace Agenda.API.EndPoints
{
    public static class ContactEndpoints
    {
        public static WebApplication MapContactEndpoints(this WebApplication app)
        {

            app.MapPost("api/v1/createContact", async (ContactInputModel inputModelContact) =>
            {
                try
                {

                }
                catch (System.Exception)
                {
                    throw;
                }
            });

            app.MapGet("api/v1/getContact", async () =>
            {
                try
                {

                }
                catch (System.Exception)
                {

                    throw;
                }
            });

            app.MapPut("api/v1/updateContact", async (ContactInputModel inputModelContact) =>
            {
                try
                {

                }
                catch (System.Exception)
                {

                    throw;
                }
            });

            app.MapDelete("api/v1/delteContact", async () =>
            {
                try
                {

                }
                catch (System.Exception)
                {

                    throw;
                }
            });

            return app;
        }
    }

}