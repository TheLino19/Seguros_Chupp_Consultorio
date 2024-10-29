
using DOMAIN.Entities;
using INFRASTRUCTURE.Commons.Bases.Request;
using INFRASTRUCTURE.Commons.Bases.Response;
using INFRASTRUCTURE.Persistence.Repository.GenericRepository;

namespace INFRASTRUCTURE.Persistence.Repository;

public interface IAsgClienteRepository //: IGenericRepository<DOMAIN.Entities.AsgCliente>
{
    Task<BaseEntityResponse<DOMAIN.Entities.AsgCliente>> ListarClientes(BaseFiltersRequest baseFiltersRequest);

    Task<bool> RegisterCliente(DOMAIN.Entities.AsgCliente requestDto);
    Task<bool> DeleteCliente(string cedula);
    Task<bool> EditCliente(DOMAIN.Entities.AsgCliente asgCliente);
    Task<BaseEntityResponse<DOMAIN.Entities.SgrSeguro>> SegurosCliente(string request);


}