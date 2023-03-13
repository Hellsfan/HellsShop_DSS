using HellsShop.Application.Models;

namespace HellsShop.Application.Services.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetByProductAsync(Product product);
    }
}
