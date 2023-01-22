using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Entities;

namespace WebApi.Infra.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("ProductName");

            builder.Property(x => x.CodeErp)
                .HasColumnName("CodeERP");

            builder.Property(x => x.Price)
                .HasColumnName("Price");

            builder.HasMany(x => x.Purchases)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);
                
        }
    }
}
