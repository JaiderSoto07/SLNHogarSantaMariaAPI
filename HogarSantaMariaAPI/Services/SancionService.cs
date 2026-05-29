using HogarSantaMariaAPI.Data;
using HogarSantaMariaAPI.Entidades;
using HogarSantaMariaAPI.Patterns;

namespace HogarSantaMariaAPI.Services
{
	public class SancionService : ISancionService
	{
		private readonly IResidenteService _residenteService;
		private readonly GestorSanciones _gestor;

		public SancionService(IResidenteService residenteService)
		{
			_residenteService = residenteService;
			_gestor = new GestorSanciones();
		}

		public string RegistrarFalta(int residenteId, string descripcionFalta, string gravedad)
		{
			var residente = _residenteService.ObtenerPorId(residenteId);
			if (residente == null) return "Residente no encontrado.";

			// Contar las sanciones previas para determinar reincidencia
			int reincidencias = DataStore.Sanciones.Count(s => s.ResidenteId == residenteId);

			// Seleccionar estrategia según gravedad y reincidencia
			ISancionStrategy estrategia;
			if (reincidencias >= 3 && gravedad != "Leve")
				estrategia = new SancionReincidenteStrategy();
			else if (gravedad == "Grave" || gravedad == "MuyGrave")
				estrategia = new SancionGraveStrategy();
			else
				estrategia = new SancionLeveStrategy();

			_gestor.SetEstrategia(estrategia);
			string resultado = _gestor.EjecutarSanción(residente, descripcionFalta, reincidencias);

			// Guardar la sanción en el historial
			var nuevaSancion = new Sancion
			{
				Id = DataStore.Sanciones.Any() ? DataStore.Sanciones.Max(s => s.Id) + 1 : 1,
				ResidenteId = residenteId,
				Falta = descripcionFalta,
				DescripcionSanción = resultado,
				Fecha = DateTime.Now,
				Tipo = estrategia.GetType().Name.Replace("Strategy", "")
			};
			DataStore.Sanciones.Add(nuevaSancion);

			return resultado;
		}

		public List<Sancion> ObtenerSancionesPorResidente(int residenteId)
		{
			return DataStore.Sanciones.Where(s => s.ResidenteId == residenteId).ToList();
		}

		public List<Sancion> ObtenerTodas()
		{
			return DataStore.Sanciones;
		}
	}
}