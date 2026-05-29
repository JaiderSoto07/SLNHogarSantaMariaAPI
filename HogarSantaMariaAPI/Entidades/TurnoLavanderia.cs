using HogarSantaMariaAPI.Patterns;

namespace HogarSantaMariaAPI.Entidades
{
	public class TurnoLavanderia
	{
		public int Id { get; set; }
		public DateTime HoraInicio { get; set; }
		public DateTime HoraFin { get; set; }
		public bool EstaOcupado { get; set; }
		public int? ResidenteId { get; set; }

		private List<IObserver> _observadores = new List<IObserver>();

		public TurnoLavanderia(int id, DateTime inicio, DateTime fin)
		{
			Id = id;
			HoraInicio = inicio;
			HoraFin = fin;
			EstaOcupado = false;
			ResidenteId = null;
		}

		public void Suscribir(IObserver observador)
		{
			if (!_observadores.Contains(observador))
				_observadores.Add(observador);
		}

		public void Desuscribir(IObserver observador)
		{
			_observadores.Remove(observador);
		}

		private void NotificarObservadores(string mensaje)
		{
			foreach (var obs in _observadores)
				obs.Notificar(mensaje);
		}

		public bool AsignarTurno(int residenteId)
		{
			if (EstaOcupado) return false;
			EstaOcupado = true;
			ResidenteId = residenteId;
			return true;
		}

		public void LiberarTurno()
		{
			if (!EstaOcupado) return;
			EstaOcupado = false;
			ResidenteId = null;
			NotificarObservadores($"Turno de {HoraInicio:HH:mm} a {HoraFin:HH:mm} disponible.");
		}
	}
}