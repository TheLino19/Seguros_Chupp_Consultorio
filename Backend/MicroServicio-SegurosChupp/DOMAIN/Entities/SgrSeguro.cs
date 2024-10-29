using System;
using System.Collections.Generic;

namespace DOMAIN.Entities;

public partial class SgrSeguro
{
    public int IdSeguro { get; set; }

    public string CodigoSeguro { get; set; } = null!;

    public decimal SumaAsegurada { get; set; }

    public decimal Prima { get; set; }

    public int RangoEdadMin { get; set; }

    public int RangoEdadMax { get; set; }

    public string? EsFamiliar { get; set; } = null!;

    public int LimiteAsegurados { get; set; }

    public int IdTipoSeguro { get; set; }

    public int IdEstado { get; set; }

    public virtual ICollection<AsgAsegurado> AsgAsegurados { get; set; } = new List<AsgAsegurado>();

    public virtual ConfEstado IdEstadoNavigation { get; set; } = null!;

    public virtual SgrTiposSeguro IdTipoSeguroNavigation { get; set; } = null!;
}
