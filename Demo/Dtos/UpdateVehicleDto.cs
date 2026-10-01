using System.ComponentModel.DataAnnotations;

namespace Demo.Dtos
{
    public class UpdateVehicleDto
    {
        public int CategoryId { get; set; }
        [Required, Range(1, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
