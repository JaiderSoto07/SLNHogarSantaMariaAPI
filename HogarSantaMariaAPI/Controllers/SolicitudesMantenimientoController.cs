using Microsoft.AspNetCore.Mvc;
using HogarSantaMariaAPI.Services;

namespace HogarSantaMariaAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SolicitudesMantenimientoController : ControllerBase
	{
		private readonly ISolicitudMantenimientoService _solicitudService;

		public SolicitudesMantenimientoController(ISolicitudMantenimientoService solicitudService)
		{
			_solicitudService = solicitudService;
		}

		[HttpPost("crear")]
		public IActionResult Crear(int residenteId, string descripcion)
		{
			var solicitud = _solicitudService.CrearSolicitud(residenteId, descripcion);
			if (solicitud == null) return BadRequest("Residente no encontrado");
			return Ok($"Solicitud creada con ID {solicitud.Id}");
		}

		[HttpGet]
		public IActionResult Get() => Ok(_solicitudService.ObtenerTodas());

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var solicitud = _solicitudService.ObtenerPorId(id);
			if (solicitud == null) return NotFound();
			return Ok(solicitud);
		}

		[HttpPut("{id}/asignar")]
		public IActionResult Asignar(int id)
		{
			if (!_solicitudService.AsignarSolicitud(id)) return NotFound();
			return Ok("Solicitud asignada ");
		}

		[HttpPut("{id}/iniciar")]
		public IActionResult IniciarReparacion(int id)
		{
			if (!_solicitudService.IniciarReparacion(id)) return NotFound();
			return Ok("Reparación iniciada ");
		}

		[HttpPut("{id}/completar")]
		public IActionResult Completar(int id)
		{
			if (!_solicitudService.CompletarSolicitud(id)) return NotFound();
			return Ok("Solicitud completada");
		}

		[HttpPut("{id}/cancelar")]
		public IActionResult Cancelar(int id)
		{
			if (!_solicitudService.CancelarSolicitud(id)) return NotFound();
			return Ok("Solicitud cancelada ");
		}
	}
}