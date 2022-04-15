using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data.Entities;

namespace Training.ViewModel.Catalog.CartModel
{
    public class EditCartRequest
    {
        public int userId { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
