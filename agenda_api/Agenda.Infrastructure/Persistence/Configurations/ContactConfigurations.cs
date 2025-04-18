using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Persistence.Configurations
{
    public class ContactConfigurations : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder
            .HasKey(c => c.Id);

            builder.ToTable("contatos");

            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.Name).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Phone).HasColumnName("numero").HasMaxLength(12).IsRequired();
            builder.Property(c => c.Email).HasColumnName("email").HasMaxLength(60);
            builder.Property(c => c.IdAgenda).HasColumnName("id_agenda").IsRequired();
        }
    }
}