using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TelekomCore.Service;
using TelekomModel.Entities;
using TelekomWebUI.Models.ViewModels;

namespace TelekomWebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICoreService<Customer> _CustomerDb;
        public AccountController(ICoreService<Customer> db)
        {
            _CustomerDb = db;   
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            var kayit = _CustomerDb.GetRecord(x => x.Name == lvm.Name && x.Surname == lvm.Surname && x.Tc==lvm.SerialNumber);
            if (kayit != null)
            {
                
                    var claims = new List<Claim>()
                    {
                        new Claim("ID", kayit.ID.ToString()),
                        new Claim(ClaimTypes.Name, lvm.Name),
                        new Claim(ClaimTypes.Surname, lvm.Surname),
                        new Claim(ClaimTypes.SerialNumber, lvm.SerialNumber)
                    };

              
                var user = new ClaimsIdentity(claims, "Login");

                
                ClaimsPrincipal principal = new ClaimsPrincipal(user);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Customer", new { area = "User" });
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
