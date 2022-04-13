using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.ViewModel.Common
{
    public class PageResult<T>: PagedResultBase
    {
        public PageActionResult PageActionResult { get; set; }
        public List<T> Items { get; set; }
    }
}
