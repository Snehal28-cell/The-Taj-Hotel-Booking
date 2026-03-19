using Microsoft.AspNetCore.Mvc;
using HotelBooking.Data;
using HotelBooking.Models;
using System.Linq;

public class AdminBookingsController : Controller
{
    private readonly AppDbContext _context;

    public AdminBookingsController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var bookings = _context.RoomBookings.ToList();
        return View(bookings);
    }

    [HttpPost]
    public IActionResult ChangeStatus(int id, string status)
    {
        var booking = _context.RoomBookings.Find(id);

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
        var booking = _context.RoomBookings.Find(id);

        if (booking != null)
        {
            _context.RoomBookings.Remove(booking);
            _context.SaveChanges();
        }

        return Ok();
    }
}