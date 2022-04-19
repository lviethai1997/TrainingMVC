using System;

namespace Training.ViewModel.Catalog.OrderViewModel
{
    public class ListOrderView
    {
        public string CustommerName { get; set; }
        public string CustommerPhone { get; set; }
        public string CustommerAddress { get; set; }
        public string CustommerEmail { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int TotalQty { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime create_time { get; set; }
    }
}