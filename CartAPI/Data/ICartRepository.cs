using CartAPI.Models;
using System.Threading.Tasks;

namespace CartAPI.Data
{
    public interface ICartRepository
    {
        Task<Cart> GetCartAsync(string cardId);
        Task<Cart> UpdateCartAsync(Cart basket);
        Task<bool> DeleteCartAsync(string cartId);

    }
}
