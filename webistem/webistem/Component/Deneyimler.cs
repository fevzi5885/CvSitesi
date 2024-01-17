using Microsoft.AspNetCore.Mvc;
using webistem.Data;

namespace webistem.Component
{
    public class Deneyimler:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public Deneyimler(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result = _context.Experiences.ToList();
            return View(result);
        }
    }
}
