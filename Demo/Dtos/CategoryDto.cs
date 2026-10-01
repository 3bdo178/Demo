using System.ComponentModel.DataAnnotations;

namespace Demo.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
