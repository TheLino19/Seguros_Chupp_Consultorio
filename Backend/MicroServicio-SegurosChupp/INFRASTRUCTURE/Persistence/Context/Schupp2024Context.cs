using System;
using System.Collections.Generic;
using System.Reflection;
using DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Persistence.Context;

public partial class Schupp2024Context : DbContext
{
    public Schupp2024Context()
    {
    }

    public Schupp2024Context(DbContextOptions<Schupp2024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AsgAsegurado> AsgAsegurados { get; set; }

    public virtual DbSet<AsgCliente> AsgClientes { get; set; }

    public virtual DbSet<AsgTiposCliente> AsgTiposClientes { get; set; }

    public virtual DbSet<ConfEstado> ConfEstados { get; set; }

    public virtual DbSet<SgrSeguro> SgrSeguros { get; set; }

    public virtual DbSet<SgrTiposSeguro> SgrTiposSeguros { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation","Modern_Spanish_CI_AS");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
