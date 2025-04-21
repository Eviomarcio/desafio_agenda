using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Persistence.Configurations
{
    public class AgendaConfigurations : IEntityTypeConfiguration<Agenda.Domain.Entities.ContactList>
    {
        public void Configure(EntityTypeBuilder<Agenda.Domain.Entities.ContactList> builder)
        {
            builder
            .HasKey(a => a.Id);

            builder.ToTable("agenda");

            builder.Property(a => a.Id).HasColumnName("id");
            builder.Property(a => a.Name).HasColumnName("nome").HasMaxLength(100).IsRequired();
        }
    }
}