using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.ViewModel.Catalog.CartModel
{
    public class AddCartRequest
    {
        public int productId { get; set; }
        public int userId { get; set; }
        public int productQuantity { get; set; }
    }
}

