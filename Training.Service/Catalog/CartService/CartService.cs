using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Data.EF;
using Training.Data.Entities;
using Training.Service.Catalog.UserService;
using Training.ViewModel.Catalog.CartModel;
using Training.ViewModel.Catalog.UserModel;
using Training.ViewModel.Common;

namespace Training.Service.Catalog.CartService
{
    public class CartService : ICart
    {
        private readonly TrainingDbContext _context;
        private readonly IUserService _userService;

        public CartService(TrainingDbContext context, IUserService userService)
        {
            _userService = userService;
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

        public async Task<PageActionResult> CheckOut(CheckOutRequest request)
        {
            if (request.IsChecked == true)
            {
                if (string.IsNullOrEmpty(request.Password.Trim()))
                {
                    var findUser = await _context.Users.Where(x => x.Email == request.Email).FirstOrDefaultAsync();
                    if (findUser == null)
                    {
                        var CreateUser = await _userService.CreateUser(new CreateUserRequest()
                        {
                            Username = "Guest",
                            Email = request.Email,
                            Password = request.Password,
                            Address = request.Address,
                            Phone = request.Phone,
                            Name = request.FullName,
                            Role = 0,
                            Status = 0
                        });

                        if (CreateUser.IsSuccess != true)
                        {
                            return new PageActionResult { IsSuccess = false, Message = CreateUser.Message };
                        }
                    }
                    else
                    {
                        return new PageActionResult { IsSuccess = false, Message = "Tài khoản đã tồn tại! Vui lòng đăng nhập" };
                    }
                }
                else
                {
                    return new PageActionResult { IsSuccess = false, Message = "Vui lòng nhập mật khẩu nếu bạn muốn tạo tài khoản" };
                }
            }

            var findUserCheckOut = await _context.Users.Where(x => x.Id == request.UserId).FirstOrDefaultAsync();

            var CreateOder = await _context.Orders.AddAsync(new Order()
            {
                CustommerName = request.FullName,
                CustommerAdress = request.Address,
                CustommerEmail = request.Email,
                CustommerMessage = "OK",
                CustommerPhone = request.Phone,
                Status = 0,
                Created_time = DateTime.Now,
                UserId = findUserCheckOut == null ? 0 : findUserCheckOut.Id,
            });

            await _context.SaveChangesAsync();

            var findCart = from cart in _context.Carts
                           join
                           product in _context.Products
                           on cart.ProductId equals product.Id
                           where cart.UserId == findUserCheckOut.Id && product.Status == 0
                           select (new { cart, product });

            foreach (var item in findCart)
            {
                var CreateOrderDetail = await _context.OrderDetails.AddAsync(new OrderDetail()
                {
                    OrderId = CreateOder.Entity.Id,
                    ProductId = item.cart.ProductId,
                    QuantityProduct = item.cart.QuantityProduct,
                    PriceProduct = item.product.Price,
                    Sale = item.product.Sale,
                    PriceSaleProduct = item.product.Price - (item.product.Price * (item.product.Sale / 100))
                });
            }
            await _context.SaveChangesAsync();

            var CreateTrans = await _context.Transactions.AddAsync(new Transaction()
            {
                OrderId = CreateOder.Entity.Id,
                UserId = findUserCheckOut == null ? 0 : findUserCheckOut.Id,
                TotalAmount = _context.OrderDetails.Where(x => x.OrderId == CreateOder.Entity.Id).Sum(x => x.PriceSaleProduct),
                TotalQuantity = findCart.Sum(x => x.cart.QuantityProduct),
                Status = 0,
                Created_time = DateTime.Now,
                Updated_time = DateTime.Now,
            });

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new PageActionResult { IsSuccess = true, Message = "Chúc mừng bạn đã đặt hàng thành công!, chúng tôi sẽ giao hàng đến bạn trong thời gian ngắn nhất, Xin cảm ơn!" };
            }
            else
            {
                return new PageActionResult { IsSuccess = false, Message = "Có lỗi đã xảy ra, Vui lòng thử lại" };
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
            getCarsUser.Updated_time = DateTime.Now;

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
                priceSaleProduct = x.product.Price - (x.product.Price * (x.product.Sale / 100))
            }).ToListAsync();

            return new PageResult<ViewCartRequest>
            {
                PageActionResult =
                    new PageActionResult { IsSuccess = true, Message = "OK" }
                    ,
                Items = result
            };
        }

        public async Task<CheckOutRequest> GetInfoUser(int UserId)
        {
            var findUser = await _context.Users.FindAsync(UserId);

            if (findUser == null)
            {
                return null;
            }

            var carts = from cart in _context.Carts
                        join product in _context.Products
                        on cart.ProductId equals product.Id
                        where cart.UserId == UserId && product.Status == 0
                        select (new { cart, product });

            var cartRS = await carts.Select(x => new ViewCartRequest()
            {
                productName = x.product.Name,
                productId = x.product.Id,
                quantityProduct = x.cart.QuantityProduct,
                priceProduct = x.product.Price,
                priceSaleProduct = x.product.Price - (x.product.Price * (x.product.Sale / 100)),
            }).ToListAsync();

            var inforUser = new CheckOutRequest()
            {
                FullName = findUser.Name,
                Email = findUser.Email,
                Address = findUser.Address,
                Phone = findUser.Phone,
                carts = cartRS
            };

            return inforUser;
        }
    }
}