using DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFRASTRUCTURE.Persistence.Context.Settings;

public class AsgTiposClienteConfiguration : IEntityTypeConfiguration<AsgTiposCliente>
{
    public void Configure(EntityTypeBuilder<AsgTiposCliente> builder)
    {
        builder.HasKey(e => e.IdTipoCliente).HasName("ASG_tipos_cliente_PK");

        builder.ToTable("ASG_tipos_cliente");

        builder.Property(e => e.IdTipoCliente).HasColumnName("id_tipo_cliente");
        builder.Property(e => e.DescTipoCliente)
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasColumnName("desc_tipo_cliente");
        builder.Property(e => e.IdEstado).HasColumnName("id_estado");

        builder.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.AsgTiposClientes)
            .HasForeignKey(d => d.IdEstado)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ASG_tipos_cliente_CONF_estados_FK");
    }
}