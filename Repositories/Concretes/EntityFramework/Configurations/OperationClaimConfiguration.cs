using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EntityFramework.Configurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();

        builder.Property(m => m.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);

        builder.HasMany(b => b.UserOperationClaims);
    }
}

