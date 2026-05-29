namespace HogarSantaMariaAPI.Patterns
{
	public interface IEstadoSolicitud
	{
		void Asignar();
		void IniciarReparacion();
		void Completar();
		void Cancelar();
	}
}