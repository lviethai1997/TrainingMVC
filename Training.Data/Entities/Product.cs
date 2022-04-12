using System;
using System.Collections.Generic;

namespace Training.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal PriceIn { get; set; }
        public decimal Sale { get; set; }
        public string Thunbar { get; set; }
        public string Images { get; set; }
        public int CategoryId { get; set; }
        public string Content { get; set; }
        public int Quantity { get; set; }
        public int? ViewCount { get; set; }
        public int Hot { get; set; }
        public int Status { get; set; }
        public DateTime Created_time { get; set; }
        public DateTime Updated_time { get; set; }

        public ProductCategory ProductCategory { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
        public IEnumerable<Cart> Carts { get; set; }
    }
}