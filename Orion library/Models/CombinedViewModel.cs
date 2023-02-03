using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orion_library.Models
{
    public class CombinedViewModel
    {
        public MyDbContext MyDbContext { get; set; }
        public PagedList.IPagedList IPagedList { get; set; }
    }
}