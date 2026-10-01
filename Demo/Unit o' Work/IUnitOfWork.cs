using Demo.Data;
using Demo.Models;
using Demo.Repo.Abstraction;

namespace Demo.Unit_o__Work
{
    public interface IUnitOfWork
    {
        ICategoryRepo Categories { get; }
        IGenericRepo<Customer> Customers { get; }
        IGenericRepo<CustomerProfile> CustomersProfiles { get; }
        IGenericRepo<Employee> Employees { get; }
        IGenericRepo<Sale> Sales { get; }
        IVehicleRepo Vehicles { get; }
        int Save();
    }
}
