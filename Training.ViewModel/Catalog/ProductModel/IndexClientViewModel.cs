using System.Collections.Generic;

namespace Training.ViewModel.Catalog.ProductModel
{
    public class IndexClientViewModel
    {
        public List<ViewProductRequest> FeaturedProducts { get; set; }
        public List<ViewProductRequest> SaleProducts { get; set; }
        public List<ViewProductRequest> TopViewProducts { get; set; }
        public List<ViewProductRequest> NewProducts { get; set; }
        public List<ViewProductRequest> TopSaleProducts { get; set; }
    }
}