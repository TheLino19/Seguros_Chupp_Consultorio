using APPLICATION.Commons.Bases;
using APPLICATION.Dtos.Request;
using APPLICATION.Dtos.Response;
using APPLICATION.Validators;
using AutoMapper;
using DOMAIN.Entities;
using INFRASTRUCTURE.Commons.Bases.Request;
using INFRASTRUCTURE.Commons.Bases.Response;
using INFRASTRUCTURE.Persistence.UnitOfWork;

namespace APPLICATION.Services.Clientes;

public class ClienteServices : IClienteServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ClienteValidator _clienteValidator;

    public ClienteServices(IUnitOfWork unitOfWor , IMapper mapper , ClienteValidator clienteValidator )
    {
        _unitOfWork = unitOfWor;
        _mapper = mapper;
        _clienteValidator = clienteValidator;
        
    }

    public async Task<BaseResponse<bool>> EliminarCliente(string cedula)
    {
        var response = new BaseResponse<bool>();

        try
        {
            if (!string.IsNullOrEmpty(cedula))
            {
                response.IsSuccess = await _unitOfWork.Clientes.DeleteCliente(cedula);
                response.Message = response.IsSuccess ? "Cliente eliminado exitosamente." : "No se encontró el cliente.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "La cédula no puede estar vacía.";
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = "Ocurrió un error al intentar eliminar el cliente.";
        }

        return response;
    }

    public async Task<BaseResponse<List<ClienteResponseDto>>> ListarClientes(BaseFiltersRequest filter)
    {
        var response = new BaseResponse<List<ClienteResponseDto>>();
    
        try 
        {
            // Validate filter if needed
            if (filter == null)
            {
                response.Message = "Filtro inválido";
                return response;
            }

            var clientes = await _unitOfWork.Clientes.ListarClientes(filter);

            response.IsSuccess = clientes != null;
            response.Data = _mapper.Map<List<ClienteResponseDto>>(clientes.items);
            response.Message = response.IsSuccess ? "Consulta exitosa" : "No se encontraron registros";

            return response;
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = "Error al listar los clientes";
           
            return response;
        }
    }

    public async Task<BaseResponse<bool>> ModificarCliente(ClienteRequestDto request)
    {
        var response = new BaseResponse<bool>();
        var validationResult = await _clienteValidator.ValidateAsync(request);
        try
        {
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Llenar todos los campos correctamente";
                response.Errors = validationResult.Errors;
                return response;
            }

            var cliente = _mapper.Map<AsgCliente>(request);
            var result = await _unitOfWork.Clientes.EditCliente(cliente);
            if (result)
            {
                response.IsSuccess = true;
                response.Message = "se modifico correctamente";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "ocurrio un error al modificar";
            }

        }
        catch (Exception e)
        {
            response.IsSuccess = false;
            response.Message = "ocurrio un error con el servidor";
        }
        return response;
    }

    public async Task<BaseResponse<bool>> RegisterCliente(ClienteRequestDto request)
    {
        var response = new BaseResponse<bool>();
        var validationResult = await _clienteValidator.ValidateAsync(request);
        try
        {
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Llenar todos los campos correctamente";
                response.Errors = validationResult.Errors;
                return response;
            }

            var cliente = _mapper.Map<AsgCliente>(request);
            response.Data = await _unitOfWork.Clientes.RegisterCliente(cliente);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "se guardo correctamente";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Este cliente ya existe";
            }
            
        }
        catch (Exception e)
        {
            response.IsSuccess = false;
            response.Message = "ocurrio un error con el servidor";
        }
        return response;
    }

    public async Task<BaseResponse<List<SeguroAsociadoDTO>>> SegurosCliente(AsociadosRequestDto request)
    {
        var response = new BaseResponse<List<SeguroAsociadoDTO>>();
        try
        {
            // Validate filter if needed
            if (request == null)
            {
                response.Message = "Filtro inválido";
                return response;
            }

            var clientes = await _unitOfWork.Clientes.SegurosCliente(request.Cedula);

            response.IsSuccess = clientes != null ;
            response.Data = _mapper.Map<List<SeguroAsociadoDTO>>(clientes.items);
            response.Message = response.IsSuccess ? "Consulta exitosa" : "No se encontraron registros";

            return response;
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = "Error al listar los seguros asociados";

            return response;
        }
    }
}