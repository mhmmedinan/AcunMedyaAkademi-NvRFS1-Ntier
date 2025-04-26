using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EntityFramework.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.ModelId).HasColumnName("ModelId").IsRequired();

        builder.Property(c => c.ModelYear).HasColumnName("ModelYear").IsRequired();
        builder.Property(c => c.Plate).HasColumnName("Plate").IsRequired().HasMaxLength(15);
        builder.Property(c => c.State).HasColumnName("State").IsRequired();
        builder.Property(c => c.DailyPrice).HasColumnName("DailyPrice").IsRequired();

        builder.HasOne(c => c.Model);
    }
}

