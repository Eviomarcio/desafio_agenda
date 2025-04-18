// using Agenda.Infrastructure.Persistence;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
// using Microsoft.Extensions.Configuration;


// namespace Agenda.Infrastructure.Factories
// {
//     public class AgendaDbContextFactory : IDesignTimeDbContextFactory<AgendaDbContext>
//     {
//         public AgendaDbContext CreateDbContext(string[] args)
//         {
//             var configuration = new ConfigurationBuilder()
//                 .SetBasePath(Directory.GetCurrentDirectory())
//                 .AddJsonFile("../Agenda.API/appsettings.json")
//                 .Build();

//             var optionsBuilder = new DbContextOptionsBuilder<AgendaDbContext>();
//             var connectionString = configuration.GetConnectionString("DataBase");

//             optionsBuilder.UseNpgsql(connectionString);

//             return new AgendaDbContext(optionsBuilder.Options);
//         }
//     }
// }
