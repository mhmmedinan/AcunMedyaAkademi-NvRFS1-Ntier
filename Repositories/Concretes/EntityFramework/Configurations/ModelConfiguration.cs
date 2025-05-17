using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EntityFramework.Configurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.BrandId).HasColumnName("BrandId").IsRequired();

        builder.Property(m => m.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);

        builder.HasOne(m => m.Brand);

        builder.HasMany(b => b.Cars);
    }
}
