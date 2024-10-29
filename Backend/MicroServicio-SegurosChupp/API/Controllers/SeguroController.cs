using APPLICATION.Dtos.Request;
using APPLICATION.Services.Clientes;
using APPLICATION.Services.Seguros;
using INFRASTRUCTURE.Commons.Bases.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguroController : Controller
    {
        private readonly ISeguroServices _seguroServices;
        public SeguroController(ISeguroServices seguroService)
        {
            _seguroServices = seguroService;
        }

        [HttpPost("ListSeguros")]
        public async Task<IActionResult> ListSeguros([FromBody] BaseFiltersRequest filter)
        {
            var response = await _seguroServices.ListarSeguro(filter);
            return Ok(response);
        }

        [HttpPost("RegistarSeguro")]
        public async Task<IActionResult> RegistarSeguro([FromBody] SeguroRequestDto request)
        {
            var response = await _seguroServices.RegisterSeguro(request);
            return Ok(response);
        }

        [HttpPost("EliminarSeguro")]
        public async Task<IActionResult> EliminarSeguro([FromBody] SeguroRequestDelete request)
        {
            var response = await _seguroServices.EliminarSeguro(request.codigo);
            return Ok(response);
        }

        [HttpPost("ModificarSeguro")]
        public async Task<IActionResult> ModificarSeguro([FromBody] SeguroRequestDto request)
        {
            var response = await _seguroServices.ModificarSeguro(request);
            return Ok(response);
        }

        [HttpPost("ListSegurosCard")]
        public async Task<IActionResult> ListSegurosCard([FromBody] BaseFiltersRequest filter)
        {
            var response = await _seguroServices.ListarSeguroCard(filter);
            return Ok(response);
        }


    }
}
