using HogarSantaMariaAPI.Entidades;

namespace HogarSantaMariaAPI.Patterns
{
	public class EstadoEnReparacion : IEstadoSolicitud
	{
		private readonly SolicitudMantenimiento _solicitud;

		public EstadoEnReparacion(SolicitudMantenimiento solicitud) => _solicitud = solicitud;

		public void Asignar() => Console.WriteLine("Ya está en reparación, no se puede reasignar.");
		public void IniciarReparacion() => Console.WriteLine("Ya está en reparación.");
		public void Completar()
		{
			Console.WriteLine($"Solicitud {_solicitud.Id}: Reparación completada.");
			_solicitud.CambiarEstado(new EstadoFinalizada(_solicitud));
		}
		public void Cancelar()
		{
			Console.WriteLine($"Solicitud {_solicitud.Id}: Cancelada durante reparación.");
			_solicitud.CambiarEstado(new EstadoCancelada(_solicitud));
		}
	}
}