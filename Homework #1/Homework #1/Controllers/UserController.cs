using Homework__1.Database;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Homework__1.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string cardNumber)
        {
            var user = InMemoryDatabase.Users.FirstOrDefault(u => u.CardNumber == cardNumber);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToAction("Index", "Movies");
            }
            ViewBag.ErrorMessage = "Invalid Card Number.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login");
        }
    }
}
