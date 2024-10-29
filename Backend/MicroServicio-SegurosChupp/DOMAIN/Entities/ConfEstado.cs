using System;
using System.Collections.Generic;

namespace DOMAIN.Entities;

public partial class ConfEstado
{
    public int IdEstado { get; set; }

    public string DescEstado { get; set; } = null!;

    public virtual ICollection<AsgAsegurado> AsgAsegurados { get; set; } = new List<AsgAsegurado>();

    public virtual ICollection<AsgCliente> AsgClientes { get; set; } = new List<AsgCliente>();

    public virtual ICollection<AsgTiposCliente> AsgTiposClientes { get; set; } = new List<AsgTiposCliente>();

    public virtual ICollection<SgrSeguro> SgrSeguros { get; set; } = new List<SgrSeguro>();

    public virtual ICollection<SgrTiposSeguro> SgrTiposSeguros { get; set; } = new List<SgrTiposSeguro>();
}
