using APPLICATION.Commons.Bases;
using APPLICATION.Dtos.Request;
using APPLICATION.Dtos.Response;
using APPLICATION.Services.Clientes;
using APPLICATION.Services.Excel;
using INFRASTRUCTURE.Commons.Bases.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteServices _clienteServices;
        private readonly IExcelService _excelService;
        public ClienteController(IClienteServices clienteServices, IExcelService excelService)
        {
            _clienteServices = clienteServices;
            _excelService = excelService;
        }

        [HttpPost("ListarClientes")]
        public async Task<IActionResult> ListClientes([FromBody] BaseFiltersRequest filter)
        {
                    var response = await _clienteServices.ListarClientes(filter);
            return Ok(response);
        }

        [HttpPost("RegisterCliente")]
        public async Task<IActionResult> RegisterCliente([FromBody] ClienteRequestDto request)
        {
            var response = await _clienteServices.RegisterCliente(request);
            return Ok(response);
        }

        [HttpPost("EliminarCliente")]
        public async Task<IActionResult> EliminarCliente([FromBody] ClienteEliminarDto request)
        {
            var response = await _clienteServices.EliminarCliente(request.cedula);
            return Ok(response);
        }

        [HttpPost("ModificarCliente")]
        public async Task<IActionResult> ModificarCliente([FromBody] ClienteRequestDto request)
        {
            var response = await _clienteServices.ModificarCliente(request);
            return Ok(response);
        }
        
        [HttpPost("obtenerExcel")]
        public BaseResponse<List<ClienteRequestExcel>> obtenerExcel([FromBody] ExcelRequest data)
        {
            string ruta = data.Ruta;
            return _excelService.EscribirArchivoExcel(ruta);
        }

        [HttpPost("ListarSegurosAsociados")]
        public async Task<IActionResult> ListarSegurosAsociados([FromBody] AsociadosRequestDto filter)
        {
            var response = await _clienteServices.SegurosCliente(filter);
            return Ok(response);
        }
    }
}
