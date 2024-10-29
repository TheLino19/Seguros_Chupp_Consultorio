using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLICATION.Dtos.Response
{
    public class SeguroResponseDto
    {
        public int IdSeguro { get; set; }

        public string CodigoSeguro { get; set; } = null!;

        public decimal SumaAsegurada { get; set; }

        public decimal Prima { get; set; }

        public int RangoEdadMin { get; set; }

        public int RangoEdadMax { get; set; }

        public string EsFamiliar { get; set; } = null!;

        public int LimiteAsegurados { get; set; }

        public string IdTipoSeguro { get; set; }

        public Boolean idEstado { get; set; }

    }
}
