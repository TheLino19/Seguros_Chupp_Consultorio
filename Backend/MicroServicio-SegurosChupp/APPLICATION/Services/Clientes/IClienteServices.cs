using APPLICATION.Commons.Bases;
using APPLICATION.Dtos.Request;
using APPLICATION.Dtos.Response;
using INFRASTRUCTURE.Commons.Bases.Request;
using INFRASTRUCTURE.Commons.Bases.Response;

namespace APPLICATION.Services.Clientes;

public interface IClienteServices
{
    Task<BaseResponse<List<ClienteResponseDto>>> ListarClientes(BaseFiltersRequest filter);
    Task<BaseResponse<bool>>  RegisterCliente(ClienteRequestDto request);
    Task<BaseResponse<bool>> ModificarCliente(ClienteRequestDto request);
    Task<BaseResponse<bool>> EliminarCliente(string cedula);
    Task<BaseResponse<List<SeguroAsociadoDTO>>> SegurosCliente(AsociadosRequestDto request);
}