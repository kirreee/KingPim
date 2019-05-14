using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.Services.Dtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public int SubcategoryId { get; set; }
        public bool IsProductPublished { get; set; }
    }

    public class UpdateProductDto
    {
        public string ProductName { get; set; }
        public int SubcategoryId { get; set; }
        public bool IsProductPublished { get; set; }
    }
}
