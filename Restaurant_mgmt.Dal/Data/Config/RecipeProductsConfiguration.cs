using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant_mgmt.Core.Entities;

namespace Restaurant_mgmt.Dal.Data.Config;

public class RecipeProductsConfiguration: IEntityTypeConfiguration<RecipeProduct>
{
    public void Configure(EntityTypeBuilder<RecipeProduct> builder)
    {
        builder
            .HasKey(rp => new { rp.RecipeId, rp.ProductId });

        builder
            .HasOne(rp => rp.Recipe)
            .WithMany(r => r.RecipeProducts)
            .HasForeignKey(rp => rp.RecipeId);

        builder
            .HasOne(rp => rp.Product)
            .WithMany(p => p.RecipeProducts)
            .HasForeignKey(rp => rp.ProductId);
    }
}