using Demo.Models;

namespace Demo.Repo.Abstraction
{
    public interface IVehicleRepo : IGenericRepo<Vehicle>
    {
        List<Vehicle> GetAllAvailableVehicles();
        Vehicle GetVehicleByIdWithSale(int Id);
    }
}
