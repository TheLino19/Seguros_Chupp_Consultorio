using DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFRASTRUCTURE.Persistence.Context.Settings;

public class SgrSegurosConfiguration : IEntityTypeConfiguration<SgrSeguro>
{
    public void Configure(EntityTypeBuilder<SgrSeguro> builder)
    {
        builder.HasKey(e => e.IdSeguro).HasName("SGR_seguros_PK");

        builder.ToTable("SGR_seguros");

        builder.Property(e => e.IdSeguro).HasColumnName("id_seguro");
        builder.Property(e => e.CodigoSeguro)
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasColumnName("codigo_seguro");
        builder.Property(e => e.EsFamiliar)
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasColumnName("es_familiar");
        builder.Property(e => e.IdEstado).HasColumnName("id_estado");
        builder.Property(e => e.IdTipoSeguro).HasColumnName("id_tipo_seguro");
        builder.Property(e => e.LimiteAsegurados).HasColumnName("limite_asegurados");
        builder.Property(e => e.Prima)
            .HasColumnType("decimal(38, 0)")
            .HasColumnName("prima");
        builder.Property(e => e.RangoEdadMax).HasColumnName("rango_edad_max");
        builder.Property(e => e.RangoEdadMin).HasColumnName("rango_edad_min");
        builder.Property(e => e.SumaAsegurada)
            .HasColumnType("decimal(38, 0)")
            .HasColumnName("suma_asegurada");

        builder.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.SgrSeguros)
            .HasForeignKey(d => d.IdEstado)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("SGR_seguros_CONF_estados_FK");

        builder.HasOne(d => d.IdTipoSeguroNavigation).WithMany(p => p.SgrSeguros)
            .HasForeignKey(d => d.IdTipoSeguro)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("SGR_seguros_SGR_tipos_seguro_FK");
    }
}