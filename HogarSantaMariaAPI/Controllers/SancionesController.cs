using Microsoft.AspNetCore.Mvc;
using HogarSantaMariaAPI.Services;

namespace HogarSantaMariaAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SancionesController : ControllerBase
	{
		private readonly ISancionService _sancionService;

		public SancionesController(ISancionService sancionService)
		{
			_sancionService = sancionService;
		}

		[HttpPost("registrar")]
		public IActionResult RegistrarFalta(int residenteId, string descripcion, string gravedad)
		{
			if (string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(gravedad))
				return BadRequest("Descripción y gravedad son requeridas.");

			var resultado = _sancionService.RegistrarFalta(residenteId, descripcion, gravedad);
			return Ok(resultado);
		}

		[HttpGet("residente/{residenteId}")]
		public IActionResult GetSancionesPorResidente(int residenteId)
		{
			var sanciones = _sancionService.ObtenerSancionesPorResidente(residenteId);
			return Ok(sanciones);
		}

		[HttpGet]
		public IActionResult GetTodas()
		{
			return Ok(_sancionService.ObtenerTodas());
		}
	}
}