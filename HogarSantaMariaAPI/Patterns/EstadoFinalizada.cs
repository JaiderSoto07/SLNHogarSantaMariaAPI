using HogarSantaMariaAPI.Entidades;

namespace HogarSantaMariaAPI.Patterns
{
	public class EstadoFinalizada : IEstadoSolicitud
	{
		private readonly SolicitudMantenimiento _solicitud;

		public EstadoFinalizada(SolicitudMantenimiento solicitud) => _solicitud = solicitud;

		public void Asignar() => Console.WriteLine("Solicitud finalizada, no se puede asignar.");
		public void IniciarReparacion() => Console.WriteLine("Solicitud finalizada, no se puede iniciar reparación.");
		public void Completar() => Console.WriteLine("Ya está completada.");
		public void Cancelar() => Console.WriteLine("No se puede cancelar una solicitud finalizada.");
	}
}