using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.Services.Dtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public bool IsPublished { get; set; }
        public int CatalogId { get; set; }
    }

    public class UpdateCategoryDto
    {
        public string CategoryName { get; set; }
        public bool IsPublished { get; set; }
        public int CatalogId { get; set; }
    }
}
