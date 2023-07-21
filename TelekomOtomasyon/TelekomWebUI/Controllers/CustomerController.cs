using Microsoft.AspNetCore.Mvc;
using TelekomCore.Service;
using TelekomModel.Entities;

namespace TelekomWebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICoreService<Customer> _db;
        public CustomerController(ICoreService<Customer> db)
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
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer c)
        {
            if (c.Name != null && c.Surname != null && c.Tc != null)
            {
                return _db.Add(c) ? View("Listele", _db.GetAll()) : View();
            }

            ViewBag.CustomerError = "Sütunlar boş geçilemez";
            return View();
        }
        public IActionResult Guncelle(int id)
        {
            return View(_db.GetByID(id));
        }

        [HttpPost]
        public IActionResult Guncelle(Customer c)
        {
            if (c.Name != null && c.Surname != null && c.Tc != null)
            {
                return _db.Update(c) ? View("Listele", _db.GetAll()) : View();
            }

            ViewBag.CustomerUpdateError = "Sütunlar boş geçilemez";
            return View();
        }
        public IActionResult Sil(int id)
        {
            return _db.Delete(id) ? View("Listele", _db.GetAll()) : View();
        }
    }
}
