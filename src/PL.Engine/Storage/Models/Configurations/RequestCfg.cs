using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PL.Engine.Storage.Models.Configurations;

public class RequestCfg : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CarModel)
            .HasMaxLength(125)
            .IsRequired();
        builder.Property(x => x.Description)
            .HasMaxLength(256)
            .IsRequired();
        builder.Property(x => x.Phone)
            .HasMaxLength(12)
            .IsRequired();
        builder.Property(x => x.RequestedAt)
            .IsRequired();
        builder.Property(x => x.CreatedAt)
            .IsRequired();
    }
}