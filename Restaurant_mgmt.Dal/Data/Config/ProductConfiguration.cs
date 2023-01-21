﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant_mgmt.Core.Entities;
using Restaurant_mgmt.Core.Enums;

namespace Restaurant_mgmt.Dal.Data.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
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

        // builder.Property(x => x.Status)
        //     .IsRequired()
        //     .HasConversion<ProductStatusEnum>()
        //     .HasDefaultValue(ProductStatusEnum.InStock);
    }
}