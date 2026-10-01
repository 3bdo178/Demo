using Demo.Data;
using Demo.Models;
using Demo.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repo.Implementation
{
    public class VehicleRepo : GenericRepo<Vehicle>, IVehicleRepo
    {
        private readonly AppDbContext Context;
        public VehicleRepo(AppDbContext context) : base(context)
        {
            Context = context;
        }

        public List<Vehicle> GetAllAvailableVehicles()
        {
            return Context.Vehicles.Include(v => v.Category).Where(v => v.Status == "Available").OrderByDescending(v => v.Year).ToList();
        }
        public Vehicle GetVehicleByIdWithSale(int Id)
        {
            return Context.Vehicles.Include(v => v.Sale).FirstOrDefault(v => v.Id == Id);
        }
    }
}
