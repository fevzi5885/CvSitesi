using System.ComponentModel.DataAnnotations;

namespace webistem.Models
{
	public class Awards
	{
		[Key]
		public int AwardsId { get; set; }
		public string? Baslık { get; set; }
		public string? Acıklama { get; set; }
	}
}
