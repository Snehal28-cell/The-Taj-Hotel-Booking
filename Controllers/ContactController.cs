using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.Data;
using HotelBooking.Models;

namespace HotelBooking.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ContactMessage message)
        {
            if (!ModelState.IsValid)
            {
                return View(message);
            }

            message.CreatedAt = DateTime.Now;
            message.Status = "Pending";

            _context.ContactMessages.Add(message);
            _context.SaveChanges();

            TempData["Success"] = "Message sent successfully!";
            return RedirectToAction("Index");
        }
    }
}
