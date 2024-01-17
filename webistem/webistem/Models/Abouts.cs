using System.ComponentModel.DataAnnotations;

namespace webistem.Models
{
	public class Abouts
	{
		[Key]
		public int AboutId { get; set; }
		public string? Baslık { get; set; }
		public string? KısaAcıklama { get; set; }
		public string? Acıklama { get; set; }

	}
}
