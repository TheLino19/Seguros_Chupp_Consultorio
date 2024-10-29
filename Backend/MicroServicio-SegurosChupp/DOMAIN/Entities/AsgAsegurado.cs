using System;
using System.Collections.Generic;

namespace DOMAIN.Entities;

public partial class AsgAsegurado
{
    public int IdAsegurado { get; set; }

    public int IdCliente { get; set; }

    public int IdSeguro { get; set; }

    public int IdTipoCliente { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int IdEstado { get; set; }

    public virtual AsgCliente IdClienteNavigation { get; set; } = null!;

    public virtual ConfEstado IdEstadoNavigation { get; set; } = null!;

    public virtual SgrSeguro IdSeguroNavigation { get; set; } = null!;

    public virtual AsgTiposCliente IdTipoClienteNavigation { get; set; } = null!;
}
