using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.Services.ViewModels
{
    public class SubcategoryViewModel
    {
        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public string CategoryName { get; set; }
        public bool IsPublished { get; set; }
    }
}
