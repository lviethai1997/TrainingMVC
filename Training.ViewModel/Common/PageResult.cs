﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.ViewModel.Common
{
    public class PageResult<T>
    {
        public PageActionResult PageActionResult { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
