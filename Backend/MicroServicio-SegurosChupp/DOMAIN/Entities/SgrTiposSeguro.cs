using System;
using System.Collections.Generic;

namespace DOMAIN.Entities;

public partial class SgrTiposSeguro
{
    public int IdTipoSeguro { get; set; }

    public string DescSeguro { get; set; } = null!;

    public int IdEstado { get; set; }

    public virtual ConfEstado IdEstadoNavigation { get; set; } = null!;

    public virtual ICollection<SgrSeguro> SgrSeguros { get; set; } = new List<SgrSeguro>();
}
