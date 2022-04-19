namespace Training.ViewModel.Catalog.CartModel
{
    public class ViewCartRequest
    {
        public string Images { get; set; }
        public string productName { get; set; }
        public int productId { get; set; }
        public int quantityProduct { get; set; }
        public decimal priceProduct { get; set; }
        public decimal Sale { get; set; }
        public decimal priceSaleProduct { get; set; }
    }
}