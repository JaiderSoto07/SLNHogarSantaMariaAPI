using HogarSantaMariaAPI.Entidades;

namespace HogarSantaMariaAPI.Services
{
	public interface ISolicitudMantenimientoService
	{
		SolicitudMantenimiento CrearSolicitud(int residenteId, string descripcion);
		SolicitudMantenimiento ObtenerPorId(int id);
		List<SolicitudMantenimiento> ObtenerTodas();
		bool AsignarSolicitud(int id);
		bool IniciarReparacion(int id);
		bool CompletarSolicitud(int id);
		bool CancelarSolicitud(int id);
	}
}