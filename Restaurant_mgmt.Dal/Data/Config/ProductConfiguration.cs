using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant_mgmt.Core.Entities;

namespace Restaurant_mgmt.Dal.Data.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .ValueGeneratedOnAdd();
        
        builder
            .Property(e => e.QuantityUnit)
            .HasColumnType("quantity_unit_enum");
    }
}