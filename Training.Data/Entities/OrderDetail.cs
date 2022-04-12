using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data.Entities
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int QuantityProduct { get; set; }
        public decimal PriceProduct { get; set; }

        public Order order { get; set; }
        public Product product { get; set; }

    }
}
