using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Make { get; set; }
        [Required,MaxLength(100)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required, MaxLength(50)]
        public string Color { get; set; }
        [Required, Range(1,int.MaxValue)]
        public decimal Price { get; set; }
        [Required, Range(0,int.MaxValue)]
        public int MileAge { get; set; }
        [Required, MaxLength(17)]
        public string VIN { get; set; }
        [MaxLength(30)]
        public string? Transmission { get; set; }
        [MaxLength(30)]
        public string? FuelType { get; set; }
        [Required]
        public string Status { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Sale Sale { get; set; }

    }
}
