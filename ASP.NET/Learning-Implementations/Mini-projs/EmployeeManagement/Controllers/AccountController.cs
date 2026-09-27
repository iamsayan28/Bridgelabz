using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserRepository _userRepository;

        public AccountController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            // If already logged in, skip straight to the employee list
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isValid = _userRepository.ValidateUser(model.Username, model.Password);

            if (!isValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View(model);
            }

            // Store the logged-in username in Session (ASP.NET Core Session, string-based)
            HttpContext.Session.SetString("Username", model.Username);

            return RedirectToAction("Index", "Employee");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
