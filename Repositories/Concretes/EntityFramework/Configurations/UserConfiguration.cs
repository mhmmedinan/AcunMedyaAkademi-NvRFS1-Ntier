using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EntityFramework.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(50);
        builder.Property(m => m.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(30);
        builder.Property(m => m.Email).HasColumnName("Email").IsRequired().HasMaxLength(50);
        builder.Property(m => m.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(m => m.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();


        builder.HasMany(b => b.UserOperationClaims);
    }
}

