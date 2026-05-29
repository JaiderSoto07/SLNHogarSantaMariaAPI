using HogarSantaMariaAPI.Entidades;

namespace HogarSantaMariaAPI.Data
{
	public static class DataStore
	{
		public static List<Residente> Residentes { get; set; } = new List<Residente>();
		public static List<TurnoLavanderia> TurnosLavanderia { get; set; } = new List<TurnoLavanderia>();
		public static List<Sancion> Sanciones { get; set; } = new List<Sancion>();
		public static List<SolicitudMantenimiento> SolicitudesMantenimiento { get; set; } = new List<SolicitudMantenimiento>();
		public static void InicializarDatos()
		{
			if (Residentes.Count == 0)
			{
				Residentes.Add(new Residente(1, "Ana López", "ana@hogar.com", "Residente"));
				Residentes.Add(new Residente(2, "Carlos Pérez", "carlos@hogar.com", "Residente"));
				Residentes.Add(new Residente(3, "María Gómez", "maria@hogar.com", "Administrador"));
			}

			if (TurnosLavanderia.Count == 0)
			{
				TurnosLavanderia.Add(new TurnoLavanderia(1, DateTime.Today.AddHours(8), DateTime.Today.AddHours(10)));
				TurnosLavanderia.Add(new TurnoLavanderia(2, DateTime.Today.AddHours(10), DateTime.Today.AddHours(12)));
				TurnosLavanderia.Add(new TurnoLavanderia(3, DateTime.Today.AddHours(14), DateTime.Today.AddHours(16)));
			}
		}
	}
}