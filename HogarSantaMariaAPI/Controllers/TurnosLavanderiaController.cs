using Microsoft.AspNetCore.Mvc;
using HogarSantaMariaAPI.Services;

namespace HogarSantaMariaAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TurnosLavanderiaController : ControllerBase
	{
		private readonly ITurnoLavanderiaService _turnoService;

		public TurnosLavanderiaController(ITurnoLavanderiaService turnoService)
		{
			_turnoService = turnoService;
		}

		[HttpGet]
		public IActionResult Get() => Ok(_turnoService.ObtenerTodos());

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var turno = _turnoService.ObtenerPorId(id);
			if (turno == null) return NotFound();
			return Ok(turno);
		}

		[HttpPost("{id}/asignar/{residenteId}")]
		public IActionResult Asignar(int id, int residenteId)
		{
			if (!_turnoService.AsignarTurno(id, residenteId))
				return BadRequest("No se pudo asignar. El turno puede estar ocupado o los IDs son inválidos.");
			return Ok($"Turno {id} asignado al residente {residenteId}");
		}

		[HttpPost("{id}/liberar")]
		public IActionResult Liberar(int id)
		{
			if (!_turnoService.LiberarTurno(id))
				return NotFound("Turno no encontrado");
			return Ok($"Turno {id} liberado. Se notificó a los residentes suscritos.");
		}

		[HttpPost("{id}/suscribir/{residenteId}")]
		public IActionResult Suscribir(int id, int residenteId)
		{
			if (!_turnoService.SuscribirResidente(id, residenteId))
				return BadRequest("No se pudo suscribir. Verifique que el turno y el residente existan.");
			return Ok($"Residente {residenteId} suscrito al turno {id}");
		}

		[HttpPost("{id}/desuscribir/{residenteId}")]
		public IActionResult Desuscribir(int id, int residenteId)
		{
			if (!_turnoService.DesuscribirResidente(id, residenteId))
				return BadRequest("No se pudo desuscribir.");
			return Ok($"Residente {residenteId} desuscrito del turno {id}");
		}
	}
}