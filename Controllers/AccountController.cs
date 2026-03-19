using Microsoft.AspNetCore.Mvc;
using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace HotelBooking.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // REGISTER GET
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // REGISTER POST
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (user.Username == null || user.Email == null || user.Password == null)
            {
                ViewBag.Error = "All fields are required";
                return View(user);
            }

            var existingUser = _context.Users.FirstOrDefault(x => x.Email == user.Email);

            if (existingUser != null)
            {
                ViewBag.Error = "Email already exists!";
                return View(user);
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            TempData["Success"] = "Registration successful!";
            return RedirectToAction("Login");
        }

        // LOGIN GET
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // LOGIN POST
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);

            if (user == null)
            {
                ViewBag.Error = "Invalid Email or Password";
                return View();
            }

            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("Username", user.Username);

            return RedirectToAction("Index", "Rooms");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
