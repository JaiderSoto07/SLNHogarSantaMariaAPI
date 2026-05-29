using HogarSantaMariaAPI.Entidades;

namespace HogarSantaMariaAPI.Patterns
{
	public class EstadoAsignada : IEstadoSolicitud
	{
		private readonly SolicitudMantenimiento _solicitud;

		public EstadoAsignada(SolicitudMantenimiento solicitud) => _solicitud = solicitud;

		public void Asignar() => Console.WriteLine("La solicitud ya está asignada.");
		public void IniciarReparacion()
		{
			Console.WriteLine($"Solicitud {_solicitud.Id}: Reparación iniciada.");
			_solicitud.CambiarEstado(new EstadoEnReparacion(_solicitud));
		}
		public void Completar() => Console.WriteLine("No se puede completar: la reparación no ha iniciado.");
		public void Cancelar()
		{
			Console.WriteLine($"Solicitud {_solicitud.Id}: Cancelada (estaba asignada).");
			_solicitud.CambiarEstado(new EstadoCancelada(_solicitud));
		}
	}
}