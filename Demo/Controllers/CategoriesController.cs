using System.Numerics;
using Demo.Dtos;
using Demo.Models;
using Demo.Unit_o__Work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto dto)
        {
            if (dto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = new Category
            {
                Description = dto.Description,
                Name = dto.Name,
            };
            unitOfWork.Categories.Create(res);
            unitOfWork.Save();
            return Created();
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var res = unitOfWork.Categories.GetAllCategoriesWithVehicles();
            if (res == null || res.Count == 0)
            {
                return NotFound();
            }
            var dto = new List<CategoryDto>();
            foreach (var category in res) 
            {
                var c = new CategoryDto
                {
                    Name = category.Name,
                    Description = category.Description,
                    Id = category.Id
                };
                dto.Add(c);
            }
            return Ok(dto);
        }
    }
}
