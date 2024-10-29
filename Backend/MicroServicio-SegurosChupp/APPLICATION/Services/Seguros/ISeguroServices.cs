using APPLICATION.Commons.Bases;
using APPLICATION.Dtos.Request;
using APPLICATION.Dtos.Response;
using INFRASTRUCTURE.Commons.Bases.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLICATION.Services.Seguros
{
    public interface ISeguroServices
    {
        Task<BaseResponse<List<SeguroResponseDto>>> ListarSeguro(BaseFiltersRequest filter);
        Task<BaseResponse<bool>> RegisterSeguro(SeguroRequestDto request);
        Task<BaseResponse<bool>> ModificarSeguro(SeguroRequestDto request);
        Task<BaseResponse<bool>> EliminarSeguro(string codigo);
        public Task<BaseResponse<List<SeguroResponseDto>>> ListarSeguroCard(BaseFiltersRequest filter);
    }
}
