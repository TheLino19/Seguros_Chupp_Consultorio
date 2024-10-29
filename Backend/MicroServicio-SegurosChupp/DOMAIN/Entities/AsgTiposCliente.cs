using System;
using System.Collections.Generic;

namespace DOMAIN.Entities;

public partial class AsgTiposCliente
{
    public int IdTipoCliente { get; set; }

    public string DescTipoCliente { get; set; } = null!;

    public int IdEstado { get; set; }

    public virtual ICollection<AsgAsegurado> AsgAsegurados { get; set; } = new List<AsgAsegurado>();

    public virtual ConfEstado IdEstadoNavigation { get; set; } = null!;
}
