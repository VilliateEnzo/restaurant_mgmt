using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant_mgmt.Core.Entities;

namespace Restaurant_mgmt.Dal.Data.Config;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(x => x.Ubication)
            .HasMaxLength(200)
            .IsRequired(false);

        builder.Property(x => x.CreatedAt)
            .ValueGeneratedOnAdd();
    }
}