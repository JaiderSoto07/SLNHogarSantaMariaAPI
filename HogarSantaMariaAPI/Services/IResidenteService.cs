using HogarSantaMariaAPI.Entidades;

namespace HogarSantaMariaAPI.Services
{
	public interface IResidenteService
	{
		List<Residente> ObtenerTodos();
		Residente ObtenerPorId(int id);
		void Agregar(Residente residente);
	}
}