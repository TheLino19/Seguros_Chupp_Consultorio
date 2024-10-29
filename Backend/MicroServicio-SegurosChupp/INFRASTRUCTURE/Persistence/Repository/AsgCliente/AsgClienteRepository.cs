using INFRASTRUCTURE.Commons.Bases.Request;
using INFRASTRUCTURE.Commons.Bases.Response;
using INFRASTRUCTURE.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace INFRASTRUCTURE.Persistence.Repository.AsgCliente;

public class AsgClienteRepository : IAsgClienteRepository
{
    public readonly Schupp2024Context _context;

    public AsgClienteRepository(Schupp2024Context context)
    {
        _context = context;
    }

    public async Task<bool> DeleteCliente(string cedula)
    {
        var asgCliente = await _context.AsgClientes.FirstOrDefaultAsync(c => c.Cedula == cedula);

        if (asgCliente != null)
        {
            asgCliente.IdEstado = 2;
            await _context.SaveChangesAsync();
            return true;
        }

        return false; // Retorna false si el cliente no se encontró
    }

    public async Task<bool> EditCliente(DOMAIN.Entities.AsgCliente asgCliente)
    {
        var response = await _context.AsgClientes.FirstOrDefaultAsync(c => c.Cedula == asgCliente.Cedula);
        if (asgCliente == null)
            return false;

        response.Nombres = asgCliente.Nombres;
        response.FechaNacimiento = asgCliente.FechaNacimiento;
        response.Telefono = asgCliente.Telefono;
        _context.Update(response);
        var recordsAffected = await _context.SaveChangesAsync();
        return recordsAffected > 0;
    }

    public async Task<BaseEntityResponse<DOMAIN.Entities.AsgCliente>> ListarClientes(BaseFiltersRequest filter)
    {
        var response = new BaseEntityResponse<DOMAIN.Entities.AsgCliente>();
        var clientes = (from c in _context.AsgClientes
                        where c.IdEstado.ToString().Contains(filter.StateFilter.ToString())
                        select c).AsNoTracking().AsQueryable();

        if (filter.cedula is not null)
        {
            clientes = clientes.Where(x => x.Cedula.ToString().Contains(filter.cedula));
        }
        if (filter.StateFilter is not null)
        {
            clientes = clientes.Where(x => x.IdEstado == filter.StateFilter);
        }
        response.TotalRecords = await clientes.CountAsync();
        response.items = await clientes.ToListAsync();
        return response;
    }

    public async Task<bool> RegisterCliente(DOMAIN.Entities.AsgCliente requestDto)
    {
        var recordAffect = 0;
        var clienteExistente = await _context.AsgClientes
        .FirstOrDefaultAsync(c => c.Cedula == requestDto.Cedula);

        if(clienteExistente == null)
        {
            requestDto.IdEstado = 1;
            requestDto.FechaCreacion = DateTime.Now;
            await _context.AddAsync(requestDto);
            recordAffect = await _context.SaveChangesAsync();
        }
        
        return recordAffect > 0;
    }



    public async Task<BaseEntityResponse<DOMAIN.Entities.SgrSeguro>> SegurosCliente(string request)
    {
        var response = new BaseEntityResponse<DOMAIN.Entities.SgrSeguro>();
        var seguros = await _context.AsgClientes
            .Where(c => c.Cedula == request)
            .Join(
                _context.AsgAsegurados,
                cliente => cliente.IdCliente,
                asegurado => asegurado.IdCliente,
                (cliente, asegurado) => asegurado
            )
            .Join(
                _context.SgrSeguros,
                asegurado => asegurado.IdSeguro,
                seguro => seguro.IdSeguro,
                (asegurado, seguro) => seguro 
            )
            .AsNoTracking()
            .ToListAsync();

        if (!seguros.Any())
        {

            response.TotalRecords = 0;
            response.items = null;
            return response;
        }

        response.TotalRecords = seguros.Count;
        response.items = seguros;
        return response;
    }
}        