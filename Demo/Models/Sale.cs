using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Sale
    {
        public int Id { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        [Required, Range(1, int.MaxValue)]
        public decimal SalePrice { get; set; }
        [Required, MaxLength(30)]
        public string PaymentMethod { get; set; }
        [MaxLength(300)]
        public string? Notes { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}
