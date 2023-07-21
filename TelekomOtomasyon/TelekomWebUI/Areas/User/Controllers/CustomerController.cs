using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;
using TelekomCore.Service;
using TelekomModel.Entities;

namespace TelekomWebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class CustomerController : Controller
    {
        private readonly ICoreService<Customer> _cdb;
        private readonly ICoreService<Package> _pdb;
        private readonly ICoreService<AllTable> _adb;

        public CustomerController(ICoreService<Customer> cdb , ICoreService<Package> pdb, ICoreService<AllTable> adb)
        {
                _cdb= cdb;
                _pdb= pdb;
                _adb= adb;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PackageVote(int id)
        {
            return View(_pdb.GetByID(id)); 
        }
        [HttpPost]
        public IActionResult PackageVote(Package p , string Cname , string Csurname)
        {
            var id = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("ID")).Value);
            var paket = _adb.GetRecord(x => x.PackageID == p.ID && x.CustomerID == id);
            if (paket == null)
            {
                var record = new AllTable()
                {
                    CustomerID = id,
                    PackageID = p.ID,
                    CustomerName = Cname,
                    CustomerSurname = Csurname
                };
               
                return _adb.Add(record)  ? RedirectToAction("Index", "Customer", new { Areas = "User" }) : View();
            }
            return View();
        }

        public IActionResult Delete()
        {
            var id = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("ID")).Value);

            var result = _adb.GetRecord(x => x.CustomerID == id);

            return _adb.Delete(result.ID) ? RedirectToAction("Index", "Customer", new { Areas = "User" }) : View();
        }
        public IActionResult List()
        {
            return View(_pdb.GetAll());
        }

        public IActionResult AlltableListele()
        {
            return View(_adb.GetAll());
        }
    }
}
