using Microsoft.AspNetCore.Mvc;
using webistem.Data;

namespace webistem.Component
{
    public class Yetenekler:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public Yetenekler(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result = _context.Skills.ToList();
            return View(result);
        }
    }
}
