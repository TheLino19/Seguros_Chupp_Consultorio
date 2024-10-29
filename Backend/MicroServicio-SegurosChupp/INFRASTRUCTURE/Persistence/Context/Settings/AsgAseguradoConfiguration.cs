using DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFRASTRUCTURE.Persistence.Context.Settings;

public class AsgAseguradoConfiguration : IEntityTypeConfiguration<AsgAsegurado>
{
    public void Configure(EntityTypeBuilder<AsgAsegurado> builder)
    {
        builder.HasKey(e => e.IdAsegurado).HasName("ASG_asegurados_PK");

        builder.ToTable("ASG_asegurados");

        builder.Property(e => e.IdAsegurado).HasColumnName("id_asegurado");
        builder.Property(e => e.FechaAsignacion)
            .HasColumnType("datetime")
            .HasColumnName("fecha_asignacion");
        builder.Property(e => e.FechaEliminacion)
            .HasColumnType("datetime")
            .HasColumnName("fecha_eliminacion");
        builder.Property(e => e.FechaModificacion)
            .HasColumnType("datetime")
            .HasColumnName("fecha_modificacion");
        builder.Property(e => e.IdCliente).HasColumnName("id_cliente");
        builder.Property(e => e.IdEstado).HasColumnName("id_estado");
        builder.Property(e => e.IdSeguro).HasColumnName("id_seguro");
        builder.Property(e => e.IdTipoCliente).HasColumnName("id_tipo_cliente");

        builder.HasOne(d => d.IdClienteNavigation).WithMany(p => p.AsgAsegurados)
            .HasForeignKey(d => d.IdCliente)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ASG_asegurados_ASG_clientes_FK");

        builder.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.AsgAsegurados)
            .HasForeignKey(d => d.IdEstado)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ASG_asegurados_CONF_estados_FK");

        builder.HasOne(d => d.IdSeguroNavigation).WithMany(p => p.AsgAsegurados)
            .HasForeignKey(d => d.IdSeguro)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ASG_asegurados_SGR_seguros_FK");

        builder.HasOne(d => d.IdTipoClienteNavigation).WithMany(p => p.AsgAsegurados)
            .HasForeignKey(d => d.IdTipoCliente)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ASG_asegurados_ASG_tipos_cliente_FK");
    }
} 