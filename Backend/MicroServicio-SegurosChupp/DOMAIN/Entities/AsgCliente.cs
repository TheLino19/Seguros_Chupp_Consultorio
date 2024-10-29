using System;
using System.Collections.Generic;

namespace DOMAIN.Entities;

public partial class AsgCliente
{
    public int IdCliente { get; set; }

    public string Cedula { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public int IdEstado { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public virtual ICollection<AsgAsegurado> AsgAsegurados { get; set; } = new List<AsgAsegurado>();

    public virtual ConfEstado IdEstadoNavigation { get; set; } = null!;
}
