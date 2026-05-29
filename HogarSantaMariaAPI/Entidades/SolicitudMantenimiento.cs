using HogarSantaMariaAPI.Patterns;

namespace HogarSantaMariaAPI.Entidades
{
	public class SolicitudMantenimiento
	{
		public int Id { get; set; }
		public int ResidenteId { get; set; }
		public string Descripcion { get; set; }
		public DateTime FechaCreacion { get; set; }

		private IEstadoSolicitud _estadoActual;

		// Propiedad pública para ver el estado en el JSON
		public string Estado => _estadoActual.GetType().Name.Replace("Estado", "");

		public SolicitudMantenimiento(int id, int residenteId, string descripcion)
		{
			Id = id;
			ResidenteId = residenteId;
			Descripcion = descripcion;
			FechaCreacion = DateTime.Now;
			_estadoActual = new EstadoCreada(this);  
		}

		public void Asignar() => _estadoActual.Asignar();
		public void IniciarReparacion() => _estadoActual.IniciarReparacion();
		public void Completar() => _estadoActual.Completar();
		public void Cancelar() => _estadoActual.Cancelar();

		internal void CambiarEstado(IEstadoSolicitud nuevoEstado)
		{
			_estadoActual = nuevoEstado;
			Console.WriteLine($"Solicitud {Id}: Cambió a estado {_estadoActual.GetType().Name.Replace("Estado", "")}");
		}
	}
}