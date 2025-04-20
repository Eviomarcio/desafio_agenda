using Agenda.Application.Interface;
using Agenda.Application.Service;
using Agenda.Infrastructure.Persistence;
using Agenda.Infrastructure.Persistence.Interface;
using Agenda.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Agenda.API.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddArchitetures() { }

        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AgendaDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")));

            var configuration = builder.Configuration;
            builder.Services.AddSingleton(configuration);
            builder.Services.AddHttpClient();

            //Repositories
            builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();

            //Services
            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IAgendaService, AgendaService>();

            return builder;
        }
    }
}