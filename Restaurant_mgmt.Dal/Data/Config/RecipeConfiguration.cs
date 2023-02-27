using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant_mgmt.Core.Entities;
using Restaurant_mgmt.Core.Enums;

namespace Restaurant_mgmt.Dal.Data.Config;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(120)
            .IsRequired();
        
        builder.Property(x => x.Description)
            .HasMaxLength(200)
            .IsRequired(false);

        builder.Property(x => x.CreatedAt)
            .ValueGeneratedOnAdd();

        // builder.Property(x => x.Type)
        //     .IsRequired()
        //     .HasConversion<ProductType>()
        //     .HasDefaultValue(ProductType.Drink);

        builder.Property(x => x.Price)
            .HasColumnType("Decimal(18,2)");

        builder
            .Property(e => e.TypeEnum)
            .IsRequired()
            .HasColumnType("recipe_type_enum");
        
        builder
            .Property(e => e.Status)
            .IsRequired()
            .HasColumnType("recipe_status_enum");
        
        // builder.Property(x => x.Status)
        //     .IsRequired()
        //     .HasConversion<ProductStatusEnum>()
        //     .HasDefaultValue(ProductStatusEnum.InStock);
    }
}