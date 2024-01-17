using System.ComponentModel.DataAnnotations;

namespace webistem.Models
{
	public class Interests
	{
		[Key]
		public int InterestId { get; set; }
		public string? Baslık { get; set; }
		public string? Acıklama { get; set; }
	}
}
