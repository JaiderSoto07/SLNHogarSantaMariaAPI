using HogarSantaMariaAPI.Entidades;

namespace HogarSantaMariaAPI.Services
{
	public interface ISancionService
	{
		string RegistrarFalta(int residenteId, string descripcionFalta, string gravedad);
		List<Sancion> ObtenerSancionesPorResidente(int residenteId);
		List<Sancion> ObtenerTodas();
	}
}