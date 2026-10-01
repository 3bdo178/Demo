using Demo.Models;

namespace Demo.Repo.Abstraction
{
    public interface ICategoryRepo : IGenericRepo<Category>
    {
        public List<Category> GetAllCategoriesWithVehicles();
    }
}
