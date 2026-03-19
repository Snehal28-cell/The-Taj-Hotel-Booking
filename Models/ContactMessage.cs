//using System.ComponentModel.DataAnnotations;

//namespace HotelBooking.Models
//{
//    public class ContactMessage
//    {
//        public int Id { get; set; }

//        [Required(ErrorMessage = "Name is required")]
//        public string Name { get; set; }

//        [Required(ErrorMessage = "Email is required")]
//        [EmailAddress(ErrorMessage = "Enter valid email")]
//        public string Email { get; set; }

//        [Required(ErrorMessage = "Subject is required")]
//        public string Subject { get; set; }

//        [Required(ErrorMessage = "Message is required")]
//        public string Message { get; set; }
//        public DateTime CreatedAt { get; set; } = DateTime.Now;

//        public string Status { get; set; } = "Pending";
//    }
//}


using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending";
    }
}