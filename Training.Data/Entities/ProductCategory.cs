using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SaleCate { get; set; }
        public int ParentId { get; set; }
        public string Banner { get; set; }
        public int Show { get; set; }
        public int Status { get; set; }
        public DateTime Created_time { get; set; }
        public DateTime Updated_time { get; set; }

        public IEnumerable<Product> products { get; set; }
    }
}
