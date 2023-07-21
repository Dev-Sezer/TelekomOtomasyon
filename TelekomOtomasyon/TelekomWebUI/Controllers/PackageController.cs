using Microsoft.AspNetCore.Mvc;
using TelekomCore.Service;
using TelekomModel.Entities;

namespace TelekomWebUI.Controllers
{
    public class PackageController : Controller
    {
        private readonly ICoreService<Package> _db;
        public PackageController(ICoreService<Package> db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listele()
        {
            return View(_db.GetAll());
        }
        public IActionResult AddPackage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPackage(Package p)
        {
            if (p.PackageName != null && p.Contents != null)
            {
                return _db.Add(p) ? View("Listele", _db.GetAll()) : View();
            }

            ViewBag.PackageError = "Sütunlar boş geçilemez";
            return View();
        }
        public IActionResult Guncelle(int id)
        {
            return View(_db.GetByID(id));
        }

        [HttpPost]
        public IActionResult Guncelle(Package p)
        {
            if (p.PackageName != null && p.Contents != null)
            {
                return _db.Update(p) ? View("Listele", _db.GetAll()) : View();
            }

            ViewBag.PackageUpdateError = "Sütunlar boş geçilemez";
            return View();
        }
        public IActionResult Sil(int id)
        {
            return _db.Delete(id) ? View("Listele", _db.GetAll()) : View();
        }
    }
}
