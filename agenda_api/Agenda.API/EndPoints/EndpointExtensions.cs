using Agenda.API.EndPoints;

namespace Agenda.API
{
    public static class EndpointExtensions
    {
        public static WebApplication MapEndpoints(this WebApplication app)
        {
            app
            .MapAgendaEndpoints()
            .MapContactEndpoints();
            return app;
        }
    }
}