using HogarSantaMariaAPI.Data;
using HogarSantaMariaAPI.Entidades;

namespace HogarSantaMariaAPI.Services
{
	public class ResidenteService : IResidenteService
	{
		public List<Residente> ObtenerTodos() => DataStore.Residentes;
		public Residente ObtenerPorId(int id) => DataStore.Residentes.FirstOrDefault(r => r.Id == id);
		public void Agregar(Residente residente)
		{
			int nuevoId = DataStore.Residentes.Any() ? DataStore.Residentes.Max(r => r.Id) + 1 : 1;
			residente.Id = nuevoId;
			DataStore.Residentes.Add(residente);
		}
	}
}