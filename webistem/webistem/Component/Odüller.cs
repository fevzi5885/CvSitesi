using Microsoft.AspNetCore.Mvc;
using webistem.Data;

namespace webistem.Component
{
    public class Odüller:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public Odüller(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result = _context.Awards.ToList();
            return View(result);
        }
    }
}
