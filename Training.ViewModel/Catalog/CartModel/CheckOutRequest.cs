using System.Collections.Generic;
using Training.Data.Entities;

namespace Training.ViewModel.Catalog.CartModel
{
    public class CheckOutRequest
    {
        public List<ViewCartRequest> carts { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsChecked { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
    }
}