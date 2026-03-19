using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomBooking> RoomBookings { get; set; }
        public DbSet<SpaBooking> SpaBookings { get; set; }
        public DbSet<RestaurantBooking> RestaurantBookings { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
    }
}
