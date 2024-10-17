using DACNPM.Models;
using Microsoft.AspNetCore.Mvc;

namespace DACNPM.Controllers
{
	public class NhanVienController : Controller
	{
		private readonly DoAnCongNghePhanMemContext _context;

		public NhanVienController(DoAnCongNghePhanMemContext context)
		{
			_context = context;
		}
		public IActionResult Index(string TenNhanVien, string ChucVu)
		{
			var nhanViens = _context.TbNhanViens.AsQueryable();

			
			if (!string.IsNullOrEmpty(TenNhanVien))
			{
				nhanViens = nhanViens.Where(nv => nv.TenNhanVien.Contains(TenNhanVien));
				ViewData["TenNhanVien"] = TenNhanVien; 
			}

			if (!string.IsNullOrEmpty(ChucVu))
			{
				nhanViens = nhanViens.Where(nv => nv.ChucVu == ChucVu);
				ViewData["ChucVu"] = ChucVu;
			}

			return View(nhanViens.ToList());
		}
		public IActionResult Create()
		{
			var mn = _context.TbNhanViens.OrderBy(m => m.IdNhanVien).ToList();
			ViewBag.mn = mn;
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(TbNhanVien mn)
		{
			if (ModelState.IsValid)
			{
				_context.TbNhanViens.Add(mn);
				_context.SaveChanges();

				return RedirectToAction("Index");
			}

			return View(mn);
		}
		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var mn = _context.TbNhanViens.Find(id);
			if (mn == null)
			{
				return NotFound();
			}
			return View(mn);
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var nv = _context.TbNhanViens.Find(id);
			if (nv == null)
			{
				return NotFound();
			}
			// Tìm tất cả các bản ghi 
			var tk = _context.TbNhanViens.Where(p => p.IdNhanVien == id).ToList();
			if (tk.Any())
			{
				_context.TbNhanViens.RemoveRange(tk);
			}

			_context.TbNhanViens.Remove(nv);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var po = _context.TbNhanViens.Find(id);
			if (po == null)
			{
				return NotFound();
			}

			var polist = _context.TbNhanViens.OrderBy(m => m.IdNhanVien).ToList();
			ViewBag.poList = polist;
			return View(po);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(TbNhanVien po)
		{
			if (ModelState.IsValid)
			{
				// Kiểm tra xem thực thể có tồn tại hay không trước khi cập nhật
				var existing = _context.TbNhanViens.Find(po.IdNhanVien);
				if (existing != null)
				{
					_context.Entry(existing).CurrentValues.SetValues(po);
					_context.SaveChanges();
					return RedirectToAction("Index");
				}
				else
				{
					return NotFound(); // Xử lý nếu thực thể không tồn tại
				}
			}
			return View(po);
		}
	}
}
