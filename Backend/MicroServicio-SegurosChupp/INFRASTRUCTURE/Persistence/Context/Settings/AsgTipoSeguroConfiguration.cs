using DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFRASTRUCTURE.Persistence.Context.Settings;

public class AsgTipoSeguroConfiguration : IEntityTypeConfiguration<SgrTiposSeguro>
{
    public void Configure(EntityTypeBuilder<SgrTiposSeguro> builder)
    {
        builder.HasKey(e => e.IdTipoSeguro).HasName("SGR_tipos_seguro_PK");

        builder.ToTable("SGR_tipos_seguro");

        builder.Property(e => e.IdTipoSeguro).HasColumnName("id_tipo_seguro");
        builder.Property(e => e.DescSeguro)
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasColumnName("desc_seguro");
        builder.Property(e => e.IdEstado).HasColumnName("id_estado");

        builder.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.SgrTiposSeguros)
            .HasForeignKey(d => d.IdEstado)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("SGR_tipos_seguro_CONF_estados_FK");
    }
}