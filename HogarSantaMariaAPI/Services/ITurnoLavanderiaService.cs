using HogarSantaMariaAPI.Entidades;

namespace HogarSantaMariaAPI.Services
{
	public interface ITurnoLavanderiaService
	{
		List<TurnoLavanderia> ObtenerTodos();
		TurnoLavanderia ObtenerPorId(int id);
		bool AsignarTurno(int turnoId, int residenteId);
		bool LiberarTurno(int turnoId);
		bool SuscribirResidente(int turnoId, int residenteId);
		bool DesuscribirResidente(int turnoId, int residenteId);
	}
}