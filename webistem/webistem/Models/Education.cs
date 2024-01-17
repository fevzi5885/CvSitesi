using System.ComponentModel.DataAnnotations;

namespace webistem.Models
{
	public class Education
	{
		[Key]
		public int? EducationId { get; set; }
		public string? UniversiteAdı { get; set; }
		public string? BolumunAdi { get; set; }
		public string? Ortalama {  get; set; }
		public DateTime? EgtimTarihi { get; set; }

	}
}
