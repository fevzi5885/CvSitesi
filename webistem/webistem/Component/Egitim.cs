using Microsoft.AspNetCore.Mvc;
using webistem.Data;

namespace webistem.Component
{
    public class Egitim:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public Egitim(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result = _context.Educations.ToList();
            return View(result);
        }
    }
}
