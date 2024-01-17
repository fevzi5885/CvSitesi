using System.ComponentModel.DataAnnotations;

namespace webistem.Models
{
	public class Skılls
	{
		[Key]
		public int SkıllsId { get; set; }
		public string? Baslık {  get; set; }
		public string? KısaAcıklama { get; set; }
		public string? İsAkısı {  get; set; }
	}
}
