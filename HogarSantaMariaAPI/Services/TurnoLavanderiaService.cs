using HogarSantaMariaAPI.Data;
using HogarSantaMariaAPI.Entidades;

namespace HogarSantaMariaAPI.Services
{
	public class TurnoLavanderiaService : ITurnoLavanderiaService
	{
		private readonly IResidenteService _residenteService;

		public TurnoLavanderiaService(IResidenteService residenteService)
		{
			_residenteService = residenteService;
		}

		public List<TurnoLavanderia> ObtenerTodos() => DataStore.TurnosLavanderia;

		public TurnoLavanderia ObtenerPorId(int id) => DataStore.TurnosLavanderia.FirstOrDefault(t => t.Id == id);

		public bool AsignarTurno(int turnoId, int residenteId)
		{
			var turno = ObtenerPorId(turnoId);
			var residente = _residenteService.ObtenerPorId(residenteId);
			if (turno == null || residente == null) return false;
			return turno.AsignarTurno(residenteId);
		}

		public bool LiberarTurno(int turnoId)
		{
			var turno = ObtenerPorId(turnoId);
			if (turno == null) return false;
			turno.LiberarTurno();
			return true;
		}

		public bool SuscribirResidente(int turnoId, int residenteId)
		{
			var turno = ObtenerPorId(turnoId);
			var residente = _residenteService.ObtenerPorId(residenteId);
			if (turno == null || residente == null) return false;
			turno.Suscribir(residente);
			return true;
		}

		public bool DesuscribirResidente(int turnoId, int residenteId)
		{
			var turno = ObtenerPorId(turnoId);
			var residente = _residenteService.ObtenerPorId(residenteId);
			if (turno == null || residente == null) return false;
			turno.Desuscribir(residente);
			return true;
		}
	}
}