using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.ViewModel.Catalog.ProductCategoryModel
{
    public class ViewProductCategoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SaleCate { get; set; }
        public int ParentId { get; set; }
        public int Show { get; set; }
        public int Status { get; set; }
    }
}
