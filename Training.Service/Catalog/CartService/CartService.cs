using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Training.Data.EF;
using Training.Data.Entities;
using Training.ViewModel.Catalog.CartModel;
using Training.ViewModel.Common;

namespace Training.Service.Catalog.CartService
{
    public class CartService : ICart
    {
        private readonly TrainingDbContext _context;

        public CartService(TrainingDbContext context)
        {
            _context = context;
        }

        public async Task<PageActionResult> AddToCart(AddCartRequest request)
        {
            var checkCart = await _context.Carts.Where(x => x.ProductId == request.productId && x.UserId == request.userId).FirstOrDefaultAsync();

            if (checkCart != null)
            {
                checkCart.QuantityProduct += request.productQuantity;

                _context.Carts.Update(checkCart);

                var resultUpdate = await _context.SaveChangesAsync();

                if (resultUpdate > 0)
                {
                    return new PageActionResult { IsSuccess = true, Message = "Đã thêm vào giỏ hàng" };
                }
                else
                {
                    return new PageActionResult { IsSuccess = false, Message = "Có lỗi đã xảy ra" };
                }
            }

            var Addcart = new Cart()
            {
                UserId = request.userId,
                ProductId = request.productId,
                QuantityProduct = request.productQuantity,
                PriceProduct = 0,
                Created_time = DateTime.Now,
                Updated_time = DateTime.Now
            };

            await _context.Carts.AddAsync(Addcart);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new PageActionResult { IsSuccess = true, Message = "Đã thêm vào giỏ hàng" };
            }
            else
            {
                return new PageActionResult { IsSuccess = false, Message = "Có lỗi đã xảy ra" };
            }
        }

        public async Task<PageActionResult> DeleteProductInCart(int productId, int userId)
        {
            var checkCart = await _context.Carts.Where(x => x.ProductId == productId && x.UserId == userId).FirstOrDefaultAsync();

            if (checkCart == null)
            {
                return new PageActionResult { IsSuccess = false, Message = "Không tồn tại sản phẩm trong giỏ hàng" };
            }

            _context.Remove(checkCart);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new PageActionResult { IsSuccess = true, Message = "Đã bỏ sản phẩm khỏi giỏ hàng" };
            }
            else
            {
                return new PageActionResult { IsSuccess = false, Message = "Có lỗi đã xảy ra" };
            }
        }

        public async Task<PageActionResult> EditToCart(int productId, int quantity, int userId)
        {
            var getCarsUser = await _context.Carts.Where(x => x.UserId == userId && x.ProductId == productId).FirstOrDefaultAsync();

            if (getCarsUser == null)
            {
                return new PageActionResult { IsSuccess = false, Message = "Không có sản phẩm nào trong giỏ hàng" };
            }

            getCarsUser.QuantityProduct = quantity;

            _context.Carts.Update(getCarsUser);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new PageActionResult { IsSuccess = true, Message = "Cập nhật giỏ hàng thành công" };
            }
            else
            {
                return new PageActionResult { IsSuccess = false, Message = "Có lỗi đã xảy ra" };
            }
        }

        public async Task<PageResult<ViewCartRequest>> GetCarts(int userId)
        {
            var getCart = from product in _context.Products
                          join cart in _context.Carts
                          on product.Id equals cart.ProductId
                          where cart.UserId == userId
                          select (new { product, cart });

            if (!getCart.Any())
            {
                return new PageResult<ViewCartRequest>
                {
                    PageActionResult =
                    new PageActionResult { IsSuccess = false, Message = "Không có sản phẩm nào trong giỏ hàng" }
                    ,
                    Items = null
                };
            }

            var result = await getCart.Select(x => new ViewCartRequest()
            {
                Images = x.product.Thunbar,
                productName = x.product.Name,
                productId = x.product.Id,
                quantityProduct = x.cart.QuantityProduct,
                priceProduct = x.product.Price,
            }).ToListAsync();

            return new PageResult<ViewCartRequest>
            {
                PageActionResult =
                    new PageActionResult { IsSuccess = true, Message = "OK" }
                    ,
                Items = result
            };
        }
    }
}