using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant_mgmt.Core.Entities;

namespace Restaurant_mgmt.Dal.Data.Config;

public class HistoryChangeConfiguration : IEntityTypeConfiguration<HistoryChange>
{
    public void Configure(EntityTypeBuilder<HistoryChange> builder)
    {
        builder
            .Property(e => e.Action)
            .HasColumnType("action_enum");
    }
}