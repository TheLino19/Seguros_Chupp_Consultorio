using DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFRASTRUCTURE.Persistence.Context.Settings;

public class ConfEstadoConfiguration : IEntityTypeConfiguration<ConfEstado>
{
    public void Configure(EntityTypeBuilder<ConfEstado> builder)
    {
        builder.HasKey(e => e.IdEstado).HasName("CONF_estado_PK");

        builder.ToTable("CONF_estados");

        builder.Property(e => e.IdEstado).HasColumnName("id_estado");
        builder.Property(e => e.DescEstado)
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasColumnName("desc_estado");
    }
}