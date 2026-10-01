using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(20), Phone]
        public string Phone { get; set; }
        [Required, MaxLength(30)]
        public string DriverLicenseNumber { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public CustomerProfile CustomerProfile { get; set; }
    }
}
