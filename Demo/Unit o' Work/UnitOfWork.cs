using Demo.Data;
using Demo.Models;
using Demo.Repo.Abstraction;

namespace Demo.Unit_o__Work
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepo Categories { get; }

        public IGenericRepo<Customer> Customers { get; }

        public IGenericRepo<CustomerProfile> CustomersProfiles { get; }

        public IGenericRepo<Employee> Employees { get; }

        public IGenericRepo<Sale> Sales { get; }

        public IVehicleRepo Vehicles { get; }
        private readonly AppDbContext _context;
        public UnitOfWork(ICategoryRepo categories,IGenericRepo<Customer> customers,IGenericRepo<CustomerProfile> customerprofiles, IGenericRepo<Employee> employees, IGenericRepo<Sale> sales, IVehicleRepo vehicle, AppDbContext context)
        {
            Categories = categories;
            Customers = customers;
            CustomersProfiles = customerprofiles;
            Employees = employees;
            Sales = sales;
            Vehicles = vehicle;
            _context = context;
        
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
