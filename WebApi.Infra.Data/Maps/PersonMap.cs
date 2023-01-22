using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;
using WebApi.Domain.Entities;

namespace WebApi.Infra.Data.Maps
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("PersonName");

            builder.Property(x => x.Document)
                .HasColumnName("Document");

            builder.Property(x => x.Phone)
                .HasColumnName("Phone");

            builder.HasMany(x => x.Purchases)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId);
                
        }
    }
}
