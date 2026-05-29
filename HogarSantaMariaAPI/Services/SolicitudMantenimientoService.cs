using HogarSantaMariaAPI.Data;
using HogarSantaMariaAPI.Entidades;

namespace HogarSantaMariaAPI.Services
{
	public class SolicitudMantenimientoService : ISolicitudMantenimientoService
	{
		private readonly IResidenteService _residenteService;

		public SolicitudMantenimientoService(IResidenteService residenteService)
		{
			_residenteService = residenteService;
		}

		public SolicitudMantenimiento CrearSolicitud(int residenteId, string descripcion)
		{
			var residente = _residenteService.ObtenerPorId(residenteId);
			if (residente == null) return null;

			int nuevoId = DataStore.SolicitudesMantenimiento.Any()
				? DataStore.SolicitudesMantenimiento.Max(s => s.Id) + 1 : 1;
			var solicitud = new SolicitudMantenimiento(nuevoId, residenteId, descripcion);
			DataStore.SolicitudesMantenimiento.Add(solicitud);
			return solicitud;
		}

		public SolicitudMantenimiento ObtenerPorId(int id) => DataStore.SolicitudesMantenimiento.FirstOrDefault(s => s.Id == id);

		public List<SolicitudMantenimiento> ObtenerTodas() => DataStore.SolicitudesMantenimiento;

		public bool AsignarSolicitud(int id)
		{
			var solicitud = ObtenerPorId(id);
			if (solicitud == null) return false;
			solicitud.Asignar();
			return true;
		}

		public bool IniciarReparacion(int id)
		{
			var solicitud = ObtenerPorId(id);
			if (solicitud == null) return false;
			solicitud.IniciarReparacion();
			return true;
		}

		public bool CompletarSolicitud(int id)
		{
			var solicitud = ObtenerPorId(id);
			if (solicitud == null) return false;
			solicitud.Completar();
			return true;
		}

		public bool CancelarSolicitud(int id)
		{
			var solicitud = ObtenerPorId(id);
			if (solicitud == null) return false;
			solicitud.Cancelar();
			return true;
		}
	}
}