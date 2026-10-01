using Demo.Data;
using Demo.Models;
using Demo.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Demo.Repo.Implementation
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        private readonly AppDbContext Context;
        public CategoryRepo(AppDbContext context) : base(context)
        {
            Context = context;
        }

        public List<Category> GetAllCategoriesWithVehicles()
        {
            return Context.Categories.Include(c=>c.Vehicles).Where(c=>c.Vehicles.Count()!=0).ToList();
        }
    }
}
