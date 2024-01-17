using Microsoft.AspNetCore.Mvc;
using webistem.Data;

namespace webistem.Component
{
    public class IlgiAlanları:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public IlgiAlanları(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result = _context.Interests.ToList();
            return View(result);
        }
    }
}
