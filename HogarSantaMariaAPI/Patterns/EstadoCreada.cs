using HogarSantaMariaAPI.Entidades;

namespace HogarSantaMariaAPI.Patterns
{
	public class EstadoCreada : IEstadoSolicitud
	{
		private readonly SolicitudMantenimiento _solicitud;

		public EstadoCreada(SolicitudMantenimiento solicitud) => _solicitud = solicitud;

		public void Asignar()
		{
			Console.WriteLine($"Solicitud {_solicitud.Id}: Asignada a técnico.");
			_solicitud.CambiarEstado(new EstadoAsignada(_solicitud));
		}

		public void IniciarReparacion() => Console.WriteLine("No se puede iniciar reparación: la solicitud no está asignada.");
		public void Completar() => Console.WriteLine("No se puede completar: la solicitud no está en reparación.");
		public void Cancelar()
		{
			Console.WriteLine($"Solicitud {_solicitud.Id}: Cancelada.");
			_solicitud.CambiarEstado(new EstadoCancelada(_solicitud));
		}
	}
}