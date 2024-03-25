using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using WebApplication3.Models;

namespace WebApplication3.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model) {
            var encryptedPassword = EncryptPassword(model.Password);
            if (encryptedPassword == Database.Users[0].Password) { // TODO: добавить проверки логина тоже
                return RedirectToAction("Index");
            } else {
                return View(model);
            }
        }

        private string EncryptPassword(string password) {
            var inpuBytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = MD5.HashData(inpuBytes); // TODO: поменять md5 на sha512
            StringBuilder sb = new();
            for (var i = 0; i < hashBytes.Length; ++i) {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
