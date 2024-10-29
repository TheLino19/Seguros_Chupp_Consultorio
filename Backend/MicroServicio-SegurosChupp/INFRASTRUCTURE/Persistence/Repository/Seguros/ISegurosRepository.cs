using DOMAIN.Entities;
using INFRASTRUCTURE.Commons.Bases.Request;
using INFRASTRUCTURE.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Persistence.Repository.Seguros
{
    public interface ISegurosRepository
    {
        Task<BaseEntityResponse<SgrSeguro>> ListarSeguros(BaseFiltersRequest baseFiltersRequest);
        Task<bool> RegisterSeguro(SgrSeguro request);
        Task<bool> EliminarSeguro(string codigo);
        Task<bool> ModificarSeguro(SgrSeguro request);
        

    }
}
