using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required, MaxLength(100)]
        public string Position { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [MaxLength(20), Phone]
        public string? Phone { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
