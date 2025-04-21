using System.Reflection;
using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Persistence
{
    public class ContactListDbContext : DbContext
    {
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactList> ContactList { get; set; }

        public ContactListDbContext(DbContextOptions<ContactListDbContext> options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}