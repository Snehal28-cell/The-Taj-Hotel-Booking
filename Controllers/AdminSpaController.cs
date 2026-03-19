using Microsoft.AspNetCore.Mvc;
using HotelBooking.Data;
using HotelBooking.Models;
using System.Linq;

public class AdminSpaController : Controller
{
    private readonly AppDbContext _context;

    public AdminSpaController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var spa = _context.SpaBookings.ToList();
        return View(spa);
    }

    [HttpPost]
    public IActionResult ChangeStatus(int id, string status)
    {
        var booking = _context.SpaBookings.Find(id);

        if (booking != null)
        {
            booking.Status = status;
            _context.SaveChanges();
        }

        return Ok();
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var booking = _context.SpaBookings.Find(id);

        if (booking != null)
        {
            _context.SpaBookings.Remove(booking);
            _context.SaveChanges();
        }

        return Ok();
    }
}