using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.Services.Dtos
{
    public class CreateSubcategoryDto
    {
        public string SubcategoryName { get; set; }
        public int CategoryId { get; set; }
        public bool IsPublished { get; set; }
    }

    public class UpdateSubcategoryDto
    {
        public string SubcategoryName { get; set; }
        public int CategoryId { get; set; }
        public bool IsPublished { get; set; }
    }
}
