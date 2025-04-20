using Agenda.Application.DTOs.InputModel;

namespace Agenda.API.EndPoints
{
    public static class AgendaEndpoints
    {
        public static WebApplication MapAgendaEndpoints(this WebApplication app)
        {
            app.MapPost("api/v1/createAgenda", async (
                ContactInputModel inputModelAgenda) =>
            {
                try
                {

                }
                catch (System.Exception)
                {
                    throw;
                }
            });

            app.MapGet("api/v1/getAgendaById", async (
                int id) =>
            {
                try
                {

                }
                catch (System.Exception)
                {

                    throw;
                }
            });

            app.MapGet("api/v1/deleteAgenda", async (
                int id) =>
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