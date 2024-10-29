using DOMAIN.Entities;
using INFRASTRUCTURE.Commons.Bases.Request;
using INFRASTRUCTURE.Commons.Bases.Response;
using INFRASTRUCTURE.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Persistence.Repository.Seguros
{
    public class SeguroRepository : ISegurosRepository
    {
        public readonly Schupp2024Context _context;
        public SeguroRepository(Schupp2024Context context) { 
            _context = context;
        }

        public async Task<bool> EliminarSeguro(string codigo)
        {
            var seguros = await _context.SgrSeguros.FirstOrDefaultAsync(c => c.CodigoSeguro == codigo);

            if (seguros != null)
            {
                seguros.IdEstado = 2;
                await _context.SaveChangesAsync();
                return true;
            }

            return false; // Retorna false si el cliente no se encontró
        }

        public async Task<BaseEntityResponse<SgrSeguro>> ListarSeguros(BaseFiltersRequest filter)
        {
            var response = new BaseEntityResponse<SgrSeguro>();
            var seguros = (from c in _context.SgrSeguros
                            where c.IdEstado == filter.StateFilter
                            select c).AsNoTracking().AsQueryable();

            if (filter.codigo is not null)
            {
                seguros = seguros.Where(x => x.CodigoSeguro.Contains(filter.codigo));
            }
            if (filter.StateFilter is not null)
            {
                seguros = seguros.Where(x => x.IdEstado == filter.StateFilter);
            }
            response.TotalRecords = await seguros.CountAsync();
            response.items = await seguros.ToListAsync();
            return response;
        }

        public async Task<bool> ModificarSeguro(SgrSeguro request)
        {
            var response = await _context.SgrSeguros.FirstOrDefaultAsync(c => c.CodigoSeguro == request.CodigoSeguro);
            if (response == null)
                return false;

            response.Prima = request.Prima;
            response.SumaAsegurada = request.SumaAsegurada;
            response.LimiteAsegurados = request.LimiteAsegurados;
            response.RangoEdadMax = request.RangoEdadMax;
            response.RangoEdadMin = request.RangoEdadMin;
            _context.Update(response);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> RegisterSeguro(SgrSeguro request)
        {
            var recordAffect = 0;
            var seguroExistente = await _context.SgrSeguros
            .FirstOrDefaultAsync(c => c.CodigoSeguro == request.CodigoSeguro);

            if (seguroExistente == null)
            {
                await _context.AddAsync(request);
                recordAffect = await _context.SaveChangesAsync();
            }
                
            return recordAffect > 0;
        }
    }
}
