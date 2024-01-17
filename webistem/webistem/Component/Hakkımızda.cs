using Microsoft.AspNetCore.Mvc;
using webistem.Data;

namespace webistem.Component
{
	public class Hakkımızda:ViewComponent
	{
		private readonly ApplicationDbContext _context;

		public Hakkımızda(ApplicationDbContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			var result = _context.Abouts.ToList();
			return View(result);
		}
	}
}
