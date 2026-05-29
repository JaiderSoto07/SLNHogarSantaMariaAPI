using HogarSantaMariaAPI.Entidades;

namespace HogarSantaMariaAPI.Patterns
{
	public class GestorSanciones
	{
		private ISancionStrategy _estrategia;

		public void SetEstrategia(ISancionStrategy estrategia)
		{
			_estrategia = estrategia;
		}

		public string EjecutarSanción(Residente residente, string falta, int reincidencias)
		{
			if (_estrategia == null)
				throw new Exception("No se ha definido una estrategia de sanción.");
			return _estrategia.AplicarSanción(residente, falta, reincidencias);
		}
	}
}