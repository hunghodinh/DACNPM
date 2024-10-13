using DACNPM.Models;
using Microsoft.AspNetCore.Mvc;

namespace DACNPM.Controllers
{
	public class PhongController : Controller
	{
        private readonly DoAnCongNghePhanMemContext _context;

        public PhongController(DoAnCongNghePhanMemContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<TbPhong> rooms = _context.TbPhongs.ToList();
            return View(rooms);
        }
        public IActionResult Create()
        {
            var mn = _context.TbPhongs.OrderBy(m => m.IdPhong).ToList();
            ViewBag.mn = mn;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TbPhong mn)
        {
            if (ModelState.IsValid)
            {
                _context.TbPhongs.Add(mn);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(mn);
        }
    }
}
