using Microsoft.AspNetCore.Mvc;
using HotelBooking.Data;
using HotelBooking.Models;

public class BookingController : Controller
{
    private readonly AppDbContext _context;

    public BookingController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Calendar()
    {
        return View();
    }

    public IActionResult TestPage()
    {
        return View();
    }

    // STEP 1: Show payment options
    public IActionResult PaymentOptions(int roomId, DateTime checkin, DateTime checkout)
    {
        var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
        ViewBag.RoomId = roomId;
        ViewBag.RoomType = room.Name;

        if (room == null)
        {
            return NotFound();
        }

        int nights = (checkout - checkin).Days;
        int totalAmount = nights * room.PricePerNight;

        ViewBag.RoomId = roomId;
        ViewBag.RoomName = room.Name;
        ViewBag.Price = room.PricePerNight;
        ViewBag.CheckIn = checkin;
        ViewBag.CheckOut = checkout;
        ViewBag.Nights = nights;
        ViewBag.TotalAmount = totalAmount;

        return View();
    }

    //public IActionResult PaymentOptions(int roomId, DateTime checkin, DateTime checkout)
    //{
    //    ViewBag.RoomId = roomId;

    //    return View("~/Views/Booking/PaymentOptions.cshtml");
    //}

    // STEP 2: Save booking after payment
    [HttpPost]
    public IActionResult PaymentSuccess(RoomBooking booking)
    {
        booking.BookingDate = DateTime.Now;

        _context.RoomBookings.Add(booking);
        _context.SaveChanges();

        return View();
    }
}