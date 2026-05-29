namespace HogarSantaMariaAPI.Entidades
{
	public class Sancion
	{
		public int Id { get; set; }
		public int ResidenteId { get; set; }
		public string Falta { get; set; }
		public string DescripcionSanción { get; set; }
		public DateTime Fecha { get; set; }
		public string Tipo { get; set; } // Leve, Grave, Reincidente
	}
}