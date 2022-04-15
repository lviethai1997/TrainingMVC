using System.Threading.Tasks;
using Training.ViewModel.Catalog.CartModel;
using Training.ViewModel.Common;

namespace Training.Service.Catalog.CartService
{
    public interface ICart
    {
        Task<PageActionResult> AddToCart(AddCartRequest request);

        Task<PageActionResult> EditToCart(EditCartRequest request);

        Task<PageResult<ViewCartRequest>> GetCarts(int userId);

        Task<PageActionResult> DeleteProductInCart(int productId, int userId);
    }
}