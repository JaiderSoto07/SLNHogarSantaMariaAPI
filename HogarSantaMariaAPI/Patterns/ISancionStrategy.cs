using HogarSantaMariaAPI.Entidades;

namespace HogarSantaMariaAPI.Patterns
{
	public interface ISancionStrategy
	{
		string AplicarSanción(Residente residente, string falta, int numeroReincidencias);
	}
}