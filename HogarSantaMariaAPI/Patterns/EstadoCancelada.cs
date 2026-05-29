using HogarSantaMariaAPI.Entidades;

namespace HogarSantaMariaAPI.Patterns
{
	public class EstadoCancelada : IEstadoSolicitud
	{
		private readonly SolicitudMantenimiento _solicitud;

		public EstadoCancelada(SolicitudMantenimiento solicitud) => _solicitud = solicitud;

		public void Asignar() => Console.WriteLine("Solicitud cancelada, no se puede asignar.");
		public void IniciarReparacion() => Console.WriteLine("Solicitud cancelada, no se puede iniciar reparación.");
		public void Completar() => Console.WriteLine("Solicitud cancelada, no se puede completar.");
		public void Cancelar() => Console.WriteLine("Ya está cancelada.");
	}
}