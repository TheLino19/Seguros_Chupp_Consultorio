using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLICATION.Dtos.Request
{
    public class SeguroRequestDto
    {
        public string? CodigoSeguro { get; set; } = null!;

        public decimal? SumaAsegurada { get; set; }

        public decimal? Prima { get; set; }

        public int? RangoEdadMin { get; set; }

        public int? RangoEdadMax { get; set; }

        public int? LimiteAsegurados { get; set; }

        public int? IdTipoSeguro { get; set; }

        public int? IdEstado { get; set; }
    }
}
