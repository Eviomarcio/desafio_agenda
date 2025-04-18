using System.Reflection;
using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Persistence
{
    public class AgendaDbContext : DbContext
    {
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Agenda.Domain.Entities.Agenda> Agenda { get; set; }

        public AgendaDbContext(DbContextOptions<AgendaDbContext> options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}