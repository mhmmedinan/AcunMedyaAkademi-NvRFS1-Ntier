using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EntityFramework.Configurations;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("UserOperationClaims");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();

        builder.Property(m => m.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(m => m.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

        builder.HasOne(b => b.User);
        builder.HasOne(b => b.OperationClaim);
    }
}
