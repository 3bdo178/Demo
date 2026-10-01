using Demo.Dtos;
using Demo.Models;
using Demo.Unit_o__Work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; }
        public VehiclesController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        [HttpPost]
        public IActionResult CreateVehicle(CreateVehicleDto dto)
        {
            if (dto == null || !ModelState.IsValid)
            {
                return BadRequest("please enter a valid vehicle");
            }
            var existingCategory = UnitOfWork.Categories.GetById(dto.CategoryId);
            if (existingCategory == null) {
            return BadRequest("Enter a valid category.");
            }
            var res = new Vehicle
            {
                CategoryId = dto.CategoryId,
                Color = dto.Color,
                FuelType = dto.FuelType,
                Make = dto.Make,
                MileAge = dto.MileAge,
                Model = dto.Model,
                Price = dto.Price,
                Status = dto.Status,
                Transmission = dto.Transmission,
                VIN = dto.VIN,
                Year = dto.Year
            };
            UnitOfWork.Vehicles.Create(res);
            UnitOfWork.Save();
            return Created();
        }
        [HttpGet]
        public IActionResult GetAllVehicles() 
        {
            var Vehicles = UnitOfWork.Vehicles.GetAllAvailableVehicles();
            if(Vehicles == null || Vehicles.Count == 0)
            {
                return NotFound("No Vehicels Found");
            }
            var res = new List<VehicleDto>();
            foreach(var v in Vehicles)
            {
                var V = new VehicleDto
                {
                    Id = v.Id,
                    CategoryName = v.Category.Name,
                    Color = v.Color,
                    FuelType = v.FuelType,
                    Make = v.Make,
                    MileAge = v.MileAge,
                    Model = v.Model,
                    Price = v.Price,
                    Status = v.Status,
                    Transmission = v.Transmission,
                    VIN = v.VIN,
                    Year = v.Year
                };
                res.Add(V);
            }
            return Ok(res);
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateVehicle(int Id, [FromBody] UpdateVehicleDto dto)
        {
            var vehicle = UnitOfWork.Vehicles.GetById(Id);
            if (vehicle == null)
            {
                return NotFound("The vehicle that you're looking for does NOT exist.");
            }
            var existingCategory = UnitOfWork.Categories.GetById(dto.CategoryId);
            if (existingCategory == null)
            {
                return BadRequest("Category doesn't exist");
            }
            vehicle.CategoryId = dto.CategoryId;
            vehicle.Price = dto.Price;
            UnitOfWork.Vehicles.Update(vehicle);
            UnitOfWork.Save();
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteVehicle(int Id) 
        {
           var res = UnitOfWork.Vehicles.GetVehicleByIdWithSale(Id);
            if(res == null)
            {
                return NotFound("The Id that you're looing for does NOT exist.");
            }
            if(res.Sale != null)
            {
                return BadRequest("The vehicle has been sold!");
            }
            UnitOfWork.Vehicles.Delete(res);
            UnitOfWork.Save();
            return NoContent();
        }
        
    }
}
