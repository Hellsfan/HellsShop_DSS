using HellsShop.Application.Models;

namespace HellsShop.Application.Services.Interfaces
{
    public interface IPriceRepository : IRepository<Price>
    {
        Task<Price> GetByProductAsync(long? productId);
    }
}
