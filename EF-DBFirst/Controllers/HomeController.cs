using EF_DBFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EF_DBFirst.Controllers
{
    public class HomeController : Controller
    {
        
        QlsinhVienContext _context = new QlsinhVienContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // GET: SinhVien/Index
        public IActionResult Index()
        {
            var sinhViens = _context.SinhViens.ToList();
            return View(sinhViens);
        }

        // GET: SinhVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SinhVien/Create
        [HttpPost]
  
        public IActionResult Create(SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.SinhViens.Add(sinhVien);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(sinhVien);
        }

        // GET: SinhVien/Edit/5
        public IActionResult Edit(string id)
        {
            var sinhVien = _context.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhVien/Edit/5
        [HttpPost]

        public IActionResult Edit(SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Update(sinhVien);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(sinhVien);
        }

        // POST: SinhVien/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string id)
        {
            var sinhVien = _context.SinhViens.Find(id);
            if (sinhVien == null)
            {
                TempData["ErrorMessage"] = "Sinh viên không tồn tại!";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.SinhViens.Remove(sinhVien);
                _context.SaveChanges();
                TempData["SuccessMessage"] = " ";
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Có lỗi xảy ra khi xóa sinh viên!";
            }

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
