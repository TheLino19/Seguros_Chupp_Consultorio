using DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFRASTRUCTURE.Persistence.Context.Settings;

public class AsgClienteConfiguration : IEntityTypeConfiguration<AsgCliente>
{
    public void Configure(EntityTypeBuilder<AsgCliente> builder)
    {
        builder.HasKey(e => e.IdCliente).HasName("ASG_clientes_PK");

        builder.ToTable("ASG_clientes");

        builder.HasIndex(e => e.Cedula, "ASG_clientes_UNIQUE").IsUnique();

        builder.Property(e => e.IdCliente).HasColumnName("id_cliente");
        builder.Property(e => e.Cedula)
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasColumnName("cedula");
        builder.Property(e => e.FechaCreacion)
            .HasColumnType("datetime")
            .HasColumnName("fecha_creacion");
        builder.Property(e => e.FechaEliminacion)
            .HasColumnType("datetime")
            .HasColumnName("fecha_eliminacion");
        builder.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
        builder.Property(e => e.IdEstado).HasColumnName("id_estado");
        builder.Property(e => e.Nombres)
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasColumnName("nombres");
        builder.Property(e => e.Telefono)
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasColumnName("telefono");

        builder.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.AsgClientes)
            .HasForeignKey(d => d.IdEstado)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ASG_clientes_CONF_estados_FK");
    }
}