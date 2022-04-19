using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Data.EF;
using Training.ViewModel.Catalog.CartModel;
using Training.ViewModel.Catalog.OrderViewModel;
using Training.ViewModel.Common;

namespace Training.Service.Catalog.OrderService
{
    public class OrderService : IOrder
    {
        private readonly TrainingDbContext _context;

        public OrderService(TrainingDbContext context)
        {
            _context = context;
        }

        public Task<PageActionResult> CancelOrder(int OrderId)
        {
            throw new NotImplementedException();
        }

        public Task<PageActionResult> ConfirmOrder(int OrderId)
        {
            throw new NotImplementedException();
        }

        public async Task<PageResult<ListOrderView>> listOrder(PagingRequest request)
        {
            var GetListOrder = from order in _context.Orders
                               join trans in _context.Transactions
                               on order.Id equals trans.OrderId
                               select (new { order, trans });

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                GetListOrder = GetListOrder.Where(x => x.order.CustommerName.ToLower().Contains(request.Keyword.ToLower()) || x.order.CustommerPhone.Contains(request.Keyword) || x.order.Id == int.Parse(request.Keyword));
            }

            var totalCount = await GetListOrder.CountAsync();

            var data = await GetListOrder.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(x => new ListOrderView()
            {
                CustommerAddress = x.order.CustommerAdress,
                CustommerPhone = x.order.CustommerPhone,
                CustommerName = x.order.CustommerName,
                OrderId = x.order.Id,
                UserId = x.trans.UserId,
                TotalAmount = x.trans.TotalAmount,
                TotalQty = x.trans.TotalQuantity,
                create_time = x.trans.Created_time,
                CustommerEmail = x.order.CustommerEmail,
            }).ToListAsync();

            return new PageResult<ListOrderView>()
            {
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalCount,
            };
        }

        public async Task<OrderDetailView> OrderDetail(int OrderId)
        {
            var getInforOrder = from order in _context.Orders
                                join trans in _context.Transactions
                                on order.Id equals trans.OrderId
                                where trans.OrderId == OrderId
                                select (new { order, trans });

            var getListProduct = from product in _context.Products
                                 join orderDetail in _context.OrderDetails
                                 on product.Id equals orderDetail.ProductId
                                 where orderDetail.OrderId == OrderId
                                 select new { product, orderDetail };

            var listProduct = await getListProduct.Select(x => new ViewCartRequest()
            {
                Images = x.product.Thunbar,
                productName = x.product.Name,
                productId = x.product.Id,
                quantityProduct = x.orderDetail.QuantityProduct,
                priceProduct = x.orderDetail.PriceProduct,
                Sale = x.orderDetail.Sale,
                priceSaleProduct = x.orderDetail.PriceSaleProduct,
            }).ToListAsync();

            var result = await getInforOrder.Select(x => new OrderDetailView()
            {
                OrderId = x.order.Id,
                CustommerAddress = x.order.CustommerAdress,
                CustommerEmail = x.order.CustommerEmail,
                CustommerName = x.order.CustommerName,
                CustommerPhone = x.order.CustommerPhone,
                TotalAmount = x.trans.TotalAmount,
                TotalQty = x.trans.TotalQuantity,
                ListProducts = listProduct
            }).FirstOrDefaultAsync();

            return result;
        }

        public Task<OrderDetailView> PrintBill(int OrderId)
        {
            throw new NotImplementedException();
        }
    }
}