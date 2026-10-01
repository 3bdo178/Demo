using Demo.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class AppDbContext : DbContext
    {
       public DbSet<Category> Categories { get; set; }
       public DbSet<Vehicle> Vehicles { get; set; }
       public DbSet<Customer> Customers { get; set; }
       public DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public AppDbContext(DbContextOptions opt) : base(opt) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(c=>c.Vehicles).WithOne(v=>v.Category).HasForeignKey(v=>v.CategoryId);
            modelBuilder.Entity<Customer>().HasMany(C=>C.Sales).WithOne(s=>s.Customer).HasForeignKey(s=>s.CustomerId);
            modelBuilder.Entity<Customer>().HasOne(C => C.CustomerProfile).WithOne(cp => cp.Customer).HasForeignKey<CustomerProfile>(cp => cp.CustomerId);
            modelBuilder.Entity<Employee>().HasMany(e => e.Sales).WithOne(s => s.Employee).HasForeignKey(s => s.EmployeeId);
            modelBuilder.Entity<Vehicle>().HasOne(v => v.Sale).WithOne(s => s.Vehicle).HasForeignKey<Sale>(s => s.VehicleId);
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(v => v.VIN).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(C=>C.Email).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(C => C.DriverLicenseNumber).IsUnique();
            modelBuilder.Entity<Vehicle>().Property(v => v.Price).HasPrecision(12, 2);
            modelBuilder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();
            modelBuilder.Entity<Sale>().Property(s => s.SalePrice).HasPrecision(12, 2);
            modelBuilder.Entity<Vehicle>().Property(v => v.Status).HasDefaultValue("Available");
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Seden",
                Description = "Comfortable passenger cars"
            }, new Category
            {
                Id = 2,
                Name = "SUV",
                Description = "Sport utility vehicles"

            }, new Category
            {
                Id = 3,
                Name = "HatchBack",
                Description = "Compact practical cars"
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = 1,
                Make = "Toyota",
                Model = "Corolla",
                Year = 2024,
                Color = "White",
                Price = 650000,
                MileAge = 12000,
                VIN = "VIN00000000000001",
                FuelType = "Petrol",
                Transmission = "Automatic",
                Status = "Available",
                CategoryId = 1,
            }, new Vehicle
            {
                Id = 2,
                Make = "Hyundai",
                Model = "Elantra",
                Year = 2023,
                Color = "Black",
                Price = 590000,
                MileAge = 18000,
                VIN = "VIN00000000000002",
                FuelType = "Petrol",
                Transmission = "Automatic",
                Status = "Available",
                CategoryId = 2
            }, new Vehicle
            {
                Id = 3,
                Make = "Kia",
                Model = "Sportage",
                Year = 2024,
                Color = "Gray",
                Price = 980000,
                MileAge = 9000,
                VIN = "VIN00000000000003",
                FuelType = "Petrol",
                Transmission = "Automatic",
                Status = "Available",
                CategoryId = 3
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 1,
                FullName = "Ahmed Hassan",
                Email = "ahmed.hassan@Example.com",
                Phone = "01010000001",
                DriverLicenseNumber = "DL100001"
            }, new Customer
            {
                Id = 2,
                FullName = "Mona Adel",
                Email = "mona.adel@example.com",
                Phone = "01010000002",
                DriverLicenseNumber = "DL100002",
            }, new Customer
            {
                Id = 3,
                FullName = "Omar Khaled",
                Email = "omar.khaled@exaple.com",
                Phone = "01010000003",
                DriverLicenseNumber = "DL100003"
            });
            modelBuilder.Entity<CustomerProfile>().HasData(new CustomerProfile
            {
                Id = 1,
                Address = "12 Nile St.",
                City = "Cairo",
                Nationality = "Egyptian",
                DateOfBirth = new DateTime(1992, 03 , 12),
                CustomerId = 1
            }, new CustomerProfile
            {
                Id = 2,
                Address = "25 Tahrir St.",
                City ="Giza",
                Nationality = "Egyptian",
                DateOfBirth = new DateTime(1995, 07, 24),
                CustomerId = 2
                
            }, new CustomerProfile
            {
                Id = 3,
                Address = "18 El Nasr St.",
                City = "Cairo",
                Nationality = "Egyptian",
                DateOfBirth = new DateTime(1988 , 11 , 05),
                CustomerId = 3
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                FullName = "Mostafa Nabil",
                Position = "Sales Manager",
                Email = "mostafa.nabil@autodrive.com",
                Phone = "01020000001",
                HireDate = new DateTime(2021, 01, 10)
            }, new Employee
            {
                Id = 2,
                FullName = "Aya Emad",
                Position = "Sales Consultant",
                Email = "aya.emad@autodrive.com",
                Phone = "2022-04-15",
                HireDate= new DateTime(2023 , 02 , 20)
            }, new Employee
            {
                Id= 3,
                FullName = "Hassan Ali",
                Position = "Sales Consultant",
                Email = "hassan.ali@autodrive.com",
                Phone = "01020000003",
                HireDate= new DateTime(2023 , 02 , 20)
            });
            modelBuilder.Entity<Sale>().HasData(new Sale
            {
                Id = 1,
                SaleDate = new DateTime(2026, 08, 15),
                Notes = "Completed Sale",
                PaymentMethod = "Bank Transfer",
                SalePrice = 1750000,
                CustomerId = 3,
                EmployeeId = 2,
                VehicleId = 1,
            }, new Sale
            {
                Id = 2,
                SaleDate = new DateTime(2026, 08, 22),
                PaymentMethod = "Bank Transfer",
                Notes = "Completed Sale",
                SalePrice = 1850000,
                CustomerId = 2,
                EmployeeId = 1,
                VehicleId = 3
            }, new Sale
            {
                Id = 3,
                SaleDate = new DateTime(2026 , 09 , 05),
                SalePrice = 510000,
                PaymentMethod = "Cash",
                Notes = "Completed Sale",
                CustomerId = 1,
                EmployeeId = 3,
                VehicleId = 2,
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
