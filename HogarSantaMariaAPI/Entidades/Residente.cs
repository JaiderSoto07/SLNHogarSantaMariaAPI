using HogarSantaMariaAPI.Patterns;

namespace HogarSantaMariaAPI.Entidades
{
	public class Residente : IObserver
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Email { get; set; }
		public string Rol { get; set; }  // Administrador, Residente, Personal, Encargado
		public int? HabitacionId { get; set; }

		public Residente(int id, string nombre, string email, string rol)
		{
			Id = id;
			Nombre = nombre;
			Email = email;
			Rol = rol;
			HabitacionId = null;
		}

		public void Notificar(string mensaje)
		{
			Console.WriteLine($"[NOTIFICACIÓN para {Nombre}]: {mensaje}");
		}
	}
}