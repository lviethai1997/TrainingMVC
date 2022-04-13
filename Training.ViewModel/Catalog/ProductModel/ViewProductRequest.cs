using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.ViewModel.Catalog.ProductModel
{
    public class ViewProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal PriceIn { get; set; }
        public decimal Sale { get; set; }
        public string Thunbar { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public int? ViewCount { get; set; }
        public int Hot { get; set; }
        public int Status { get; set; }
    }
}
