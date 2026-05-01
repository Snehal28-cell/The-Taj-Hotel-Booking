using Microsoft.AspNetCore.Mvc;
using HotelBooking.Models;

namespace HotelBooking.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AdminLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // validation errors
            }

            // Dummy login check (replace with DB logic)
            if (model.Username == "admin" && model.Password == "12345")
            {
                if (model.RememberMe)
                {
                    Response.Cookies.Append("AdminUser", model.Username,
                        new CookieOptions { Expires = DateTime.Now.AddDays(7) });
                }
                else
                {
                    HttpContext.Session.SetString("AdminUser", model.Username);
                }

                return RedirectToAction("Dashboard");
            }

            ViewBag.ServerError = "Invalid username or password";
            return View(model);
        }

        public IActionResult Dashboard()
        {
            var model = new AdminDashboardViewModel
            {
                TotalBookings = 120,
                SpaBookings = 45,
                RestaurantOrders = 67,
                Contacts = 12,
                TodayCheckins = 5,
                RecentBookings = new List<RecentBooking>
            {
                new RecentBooking { RoomType = "Deluxe", CheckIn = "2026-03-02" },
                new RecentBooking { RoomType = "Suite", CheckIn = "2026-03-03" }
            }


            };
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}


