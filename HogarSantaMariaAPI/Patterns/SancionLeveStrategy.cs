using HogarSantaMariaAPI.Entidades;

namespace HogarSantaMariaAPI.Patterns
{
	public class SancionLeveStrategy : ISancionStrategy
	{
		public string AplicarSanción(Residente residente, string falta, int numeroReincidencias)
		{
			return $"Sanción LEVE para {residente.Nombre} por: {falta}. Advertencia escrita + 2 horas de tarea comunitaria.";
		}
	}

	public class SancionGraveStrategy : ISancionStrategy
	{
		public string AplicarSanción(Residente residente, string falta, int numeroReincidencias)
		{
			int diasSuspension = 3 + (numeroReincidencias * 2);
			return $"Sanción GRAVE para {residente.Nombre} por: {falta}. Suspensión de servicios por {diasSuspension} días.";
		}
	}

	public class SancionReincidenteStrategy : ISancionStrategy
	{
		public string AplicarSanción(Residente residente, string falta, int numeroReincidencias)
		{
			return $"Sanción para REINCIDENTE {residente.Nombre}: Expulsión temporal por 15 días y pérdida de beneficios.";
		}
	}


}